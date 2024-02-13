using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBlog.Data.UnitOfWorks;
using MVCBlog.Entity.DTOs.Users;
using MVCBlog.Entity.Entities;
using MVCBlog.Entity.Entities.Identity;
using MVCBlog.Service.Extensions;
using MVCBlog.Service.Helpers.Images;
using MVCBlog.Service.Services.Abstractions;
using MVCBlog.Service.Services.Concretes;
using MVCBlog.Web.ResultMessages;
using NToastNotify;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace MVCBlog.Web.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IToastNotification _toastNotification;
        private readonly IValidator<AppUser> _validator;
        private readonly SignInManager<AppUser> _signInManager; 
        private readonly IImageHelper _imageHelper;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(UserManager<AppUser> userManager, IUserService userService, IMapper mapper, RoleManager<AppRole> roleManager, IToastNotification toastNotification, IValidator<AppUser> validator, SignInManager<AppUser> signInManager, IImageHelper imageHelper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _userService = userService;
            _mapper = mapper;
            _roleManager = roleManager;
            _toastNotification = toastNotification;
            _validator = validator;
            _signInManager = signInManager;
            _imageHelper = imageHelper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<UserDto> result = await _userService.GetAllUsersWithRoleAsync();
            return View(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await _userService.GetAllRolesAsync();
            return View(new UserAddDto { Roles = roles }); 
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = _mapper.Map<AppUser>(userAddDto);
            var validation = await _validator.ValidateAsync(map);
            var roles = await _userService.GetAllRolesAsync();


            if (ModelState.IsValid)
            {
                var result = await _userService.CreateUserAsync(userAddDto);

                if (result.Succeeded)
                {
                    _toastNotification.AddSuccessToastMessage(ResultMessages.Messages.User.AddSuccess);
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    _toastNotification.AddErrorToastMessage(ResultMessages.Messages.User.AddError);
                     result.AddToIdentityModelState(ModelState);
                     validation.AddToModelState(ModelState);
                    return View(new UserAddDto { Roles = roles });
                }
            }
            return View(new UserAddDto { Roles = roles });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await _userService.GetAppUserByIdAsync(userId);
            var roles = await _userService.GetAllRolesAsync();

            var map = _mapper.Map<UserUpdateDto>(user);
            map.Roles = roles;

            return View(map);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await _userService.GetAppUserByIdAsync(userUpdateDto.Id);

            if (user != null)
            {
                var roles = await _userService.GetAllRolesAsync();
                if (ModelState.IsValid)
                {
                    var map = _mapper.Map(userUpdateDto, user);
                    var validation = await _validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        user.UserName = userUpdateDto.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        var result = await _userService.UpdateUserAsync(userUpdateDto);
                        if (result.Succeeded)
                        {
                            _toastNotification.AddSuccessToastMessage(ResultMessages.Messages.User.UpdateSuccess);
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            _toastNotification.AddErrorToastMessage(ResultMessages.Messages.User.UpdateError);
                            result.AddToIdentityModelState(this.ModelState);
                            return View(new UserUpdateDto { Roles = roles });
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateDto { Roles = roles });
                    }
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid userId)
        {
            IdentityResult result  = await _userService.DeleteUserAsync(userId);

            if (result.Succeeded)
            {
                _toastNotification.AddSuccessToastMessage(Messages.User.DeleteSuccess);
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
                result.AddToIdentityModelState(ModelState);
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            return View(await _userService.GetUserProfileAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
        {

            if (ModelState.IsValid)
            {
                var result = await _userService.UserProfileUpdateAsync(userProfileDto);
                if (result)
                {
                    _toastNotification.AddSuccessToastMessage("Profil güncelleme işlemi tamamlandı", new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Profile", "User", new { Area = "Admin" });
                }
                else
                {
                    var profile = await _userService.GetUserProfileAsync();
                    _toastNotification.AddErrorToastMessage("Profil güncelleme işlemi tamamlanamadı", new ToastrOptions { Title = "İşlem Başarısız" });
                    return RedirectToAction("Profile", "User", new { Area = "Admin" });
                }
            }
            else
                return NotFound();
        }
    }
}
