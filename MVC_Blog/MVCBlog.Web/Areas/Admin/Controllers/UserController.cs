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
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IToastNotification _toastNotification;
        private readonly IValidator<AppUser> _validator;
        private readonly SignInManager<AppUser> _signInManager; 
        private readonly IImageHelper _imageHelper;
        private readonly IUnitOfWork _unitOfWork;
        public UserController(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, IToastNotification toastNotification, IValidator<AppUser> validator, SignInManager<AppUser> signInManager, IImageHelper imageHelper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
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
            var users = await _userManager.Users.ToListAsync();
            var map = _mapper.Map<List<UserDto>>(users);

            foreach (var user in map)
            {
                var findUser = await _userManager.FindByIdAsync(user.Id.ToString());
                var role = string.Join("", await _userManager.GetRolesAsync(findUser));

                user.Role = role;
            }

            return View(map);
        }
        
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await _roleManager.Roles.ToListAsync();


            return View(new UserAddDto()
            {
                Roles = roles
            });
        }
        
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = _mapper.Map<AppUser>(userAddDto);
            var validation = await _validator.ValidateAsync(map);
            var roles = await _roleManager.Roles.ToListAsync();


            if (ModelState.IsValid)
            {
                map.UserName = userAddDto.Email;
                var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);

                if (result.Succeeded)
                {
                    var role = await _roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                    await _userManager.AddToRoleAsync(map, role.Name);
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
            var user = await _userManager.FindByIdAsync(userId.ToString());
            var roles = await _roleManager.Roles.ToListAsync();
            var map = _mapper.Map<UserUpdateDto>(user);
            map.Roles = roles;


            return View(map);
        }
       

        //[HttpPost]
        //public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        //{
        //    var user = await userService.GetAppUserByIdAsync(userUpdateDto.Id);

        //    if (user != null)
        //    {
        //        var roles = await userService.GetAllRolesAsync();
        //        if (ModelState.IsValid)
        //        {
        //            var map = mapper.Map(userUpdateDto, user);
        //            var validation = await validator.ValidateAsync(map);

        //            if (validation.IsValid)
        //            {
        //                user.UserName = userUpdateDto.Email;
        //                user.SecurityStamp = Guid.NewGuid().ToString();
        //                var result = await userService.UpdateUserAsync(userUpdateDto);
        //                if (result.Succeeded)
        //                {
        //                    toast.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "İşlem Başarılı" });
        //                    return RedirectToAction("Index", "User", new { Area = "Admin" });
        //                }
        //                else
        //                {
        //                    result.AddToIdentityModelState(this.ModelState);
        //                    return View(new UserUpdateDto { Roles = roles });
        //                }
        //            }
        //            else
        //            {
        //                validation.AddToModelState(this.ModelState);
        //                return View(new UserUpdateDto { Roles = roles });
        //            }
        //        }
        //    }
        //    return NotFound();
        //}

        [HttpGet]
        public async Task<IActionResult> Delete(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if(user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if(result.Succeeded)
                {
                    _toastNotification.AddSuccessToastMessage(ResultMessages.Messages.User.DeleteSuccess);
                    return RedirectToAction("Index", "User", new { area = "Admin" });
                }
                else
                {
                    _toastNotification.AddErrorToastMessage(ResultMessages.Messages.User.DeleteError);
                    foreach (var e in result.Errors)
                    {
                        ModelState.AddModelError("", e.Description);
                    }
                    return View();
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            UserProfileDto userProfileDto = _mapper.Map<UserProfileDto>(user);
            if (user.ImageId != Guid.Empty)
            {
                Image image = await _unitOfWork.GetRepository<Image>().GetAsync(i => i.Id == user.ImageId);
                userProfileDto.Image.FileName = image.FileName;
            }
         
            

            return View(userProfileDto);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDto userProfileDto)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                var isVerified = await _userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword);
                if (isVerified && userProfileDto.NewPassword != null && userProfileDto.Photo != null)
                {
                   IdentityResult result= await _userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
                    if (result.Succeeded)
                    {

                        await _userManager.UpdateSecurityStampAsync(user);
                        await _signInManager.SignOutAsync();
                        await _signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false);
                        _toastNotification.AddSuccessToastMessage(ResultMessages.Messages.User.ChangePasswordSuccess);

                        user.FirstName = userProfileDto.FirstName;
                        user.LastName = userProfileDto.LastName;
                        user.PhoneNumber = userProfileDto.PhoneNumber;

                        var imageUpload = await _imageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName}", userProfileDto.Photo, Entity.Enums.ImageType.User);
                        Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType, user.Email);
                        await _unitOfWork.GetRepository<Image>().AddAsync(image);

                        user.ImageId = image.Id;

                        await _userManager.UpdateAsync(user);

                        await _unitOfWork.SaveAsync();

                        return RedirectToAction("Profile", "User", new { Area = "Admin" });
                    }
                    else
                    {
                        result.AddToIdentityModelState(ModelState);
                        return View();
                    }

                }
                else if (isVerified)
                {
                    user.FirstName = userProfileDto.FirstName;
                    user.LastName = userProfileDto.LastName;
                    user.PhoneNumber = userProfileDto.PhoneNumber;
                    _toastNotification.AddSuccessToastMessage(ResultMessages.Messages.User.UpdateSuccess);

                    await _userManager.UpdateAsync(user);

                    return RedirectToAction("Profile", "User", new { Area = "Admin" });

                }
              
                else
                {
                    _toastNotification.AddErrorToastMessage(ResultMessages.Messages.User.UpdateError);
                    return View();
                }
                


            }

            return View();
         
        }


    }
}
