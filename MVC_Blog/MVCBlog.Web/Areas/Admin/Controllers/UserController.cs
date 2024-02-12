using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCBlog.Entity.DTOs.Users;
using MVCBlog.Entity.Entities.Identity;
using MVCBlog.Service.Extensions;
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
        public UserController(UserManager<AppUser> userManager, IMapper mapper, RoleManager<AppRole> roleManager, IToastNotification toastNotification, IValidator<AppUser> validator)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
            _toastNotification = toastNotification;
            _validator = validator;
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

    }
}
