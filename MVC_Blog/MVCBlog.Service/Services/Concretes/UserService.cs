using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVCBlog.Data.UnitOfWorks;
using MVCBlog.Entity.DTOs.Users;
using MVCBlog.Entity.Entities;
using MVCBlog.Entity.Entities.Identity;
using MVCBlog.Entity.Enums;
using MVCBlog.Service.Extensions;
using MVCBlog.Service.Helpers.Images;
using MVCBlog.Service.Services.Abstractions;
using System.Security.Claims;

namespace MVCBlog.Service.Services.Concretes
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IImageHelper _imageHelper;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public UserService(IUnitOfWork unitOfWork, IImageHelper imageHelper, IHttpContextAccessor httpContextAccessor, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _imageHelper = imageHelper;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
            _user = _httpContextAccessor.HttpContext.User;

        }
        public async Task<List<UserDto>> GetAllUsersWithRoleAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var map = _mapper.Map<List<UserDto>>(users);

            foreach (var user in map)
            {
                var findUser = await _userManager.FindByIdAsync(user.Id.ToString());
                var role = string.Join("", await _userManager.GetRolesAsync(findUser));

                user.Role = role;
            }

            return map;
        }
        public async Task<List<AppRole>> GetAllRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }
        public async Task<IdentityResult> CreateUserAsync(UserAddDto userAddDto)
        {
            var map = _mapper.Map<AppUser>(userAddDto);
            map.UserName = userAddDto.Email;
            var result = await _userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);

            if (result.Succeeded)
            {
                var role = await _roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                await _userManager.AddToRoleAsync(map, role.Name);
                return result;
            }
            else
                return result;

        }
        public async Task<AppUser> GetAppUserByIdAsync(Guid userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }
        public async Task<string> GetUserRoleAsync(AppUser user)
        {
            return string.Join("", await _userManager.GetRolesAsync(user));
        }
        public async Task<IdentityResult> UpdateUserAsync(UserUpdateDto userUpdateDto)
        {
            var user = await GetAppUserByIdAsync(userUpdateDto.Id);
            var userRole = await GetUserRoleAsync(user);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                await _userManager.RemoveFromRoleAsync(user, userRole);
                var findRole = await _roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                await _userManager.AddToRoleAsync(user, findRole.Name);
                return result;
            }
            else
                return result;
        }
        public async Task<IdentityResult> DeleteUserAsync(Guid userId)
        {
            var user = await GetAppUserByIdAsync(userId);
            var result = await _userManager.DeleteAsync(user);
            return result;
        }
        public async Task<UserProfileDto> GetUserProfileAsync()
        {
            var userId = _user.GetLoggedInUserId();
            var user = await GetAppUserByIdAsync(userId);
            UserProfileDto userProfileDto = _mapper.Map<UserProfileDto>(user);

            if (user.ImageId != Guid.Empty)
            {
                Image image = await _unitOfWork.GetRepository<Image>().GetAsync(i => i.Id == user.ImageId);
                userProfileDto.Image.FileName = image.FileName;
            }
            return userProfileDto;
        }

        private async Task<Guid> UploadImageForUser(UserProfileDto userProfileDto)
        {
            var userEmail = _user.GetLoggedInEmail();

            var imageUpload = await _imageHelper.Upload($"{userProfileDto.FirstName}{userProfileDto.LastName}", userProfileDto.Photo, ImageType.User);
            Image image = new(imageUpload.FullName, userProfileDto.Photo.ContentType, userEmail);
            await _unitOfWork.GetRepository<Image>().AddAsync(image);

            return image.Id;
        }
        public async Task<bool> UserProfileUpdateAsync(UserProfileDto userProfileDto)
        {
            var userId = _user.GetLoggedInUserId();
            var user = await GetAppUserByIdAsync(userId);
            var usersCurrentImageId = user.ImageId;

            var isVerified = await _userManager.CheckPasswordAsync(user, userProfileDto.CurrentPassword);
            if (isVerified && userProfileDto.NewPassword != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, userProfileDto.CurrentPassword, userProfileDto.NewPassword);
                if (result.Succeeded)
                {
                    await _userManager.UpdateSecurityStampAsync(user);
                    await _signInManager.SignOutAsync();
                    await _signInManager.PasswordSignInAsync(user, userProfileDto.NewPassword, true, false);

                    _mapper.Map(userProfileDto, user);

                    if (userProfileDto.Photo != null)
                        user.ImageId = await UploadImageForUser(userProfileDto);

                    await _userManager.UpdateAsync(user);
                    await _unitOfWork.SaveAsync();

                    return true;
                }
                else
                    return false;
            }
            else if (isVerified)
            {
                await _userManager.UpdateSecurityStampAsync(user);
                _mapper.Map(userProfileDto, user);

                if (userProfileDto.Photo != null)
                    user.ImageId = await UploadImageForUser(userProfileDto);
                else
                    user.ImageId = usersCurrentImageId;

                await _userManager.UpdateAsync(user);
                await _unitOfWork.SaveAsync();
                return true;
            }
            else
                return false;
        }
    }
}
