using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCBlog.Data.UnitOfWorks;
using MVCBlog.Entity.DTOs.Users;
using MVCBlog.Entity.Entities;
using MVCBlog.Entity.Entities.Identity;

namespace MVCBlog.Web.Areas.Admin.ViewComponents
{
    public class DashboardHeaderViewComponent : ViewComponent
    {


        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public DashboardHeaderViewComponent(UserManager<AppUser> userManager,IMapper mapper,IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var loggedInUser = await _userManager.GetUserAsync(HttpContext.User);
            var map = _mapper.Map<UserProfileDto>(loggedInUser);
            Image image = await _unitOfWork.GetRepository<Image>().GetByGuidAsync(map.Image.Id);
            
            var role = string.Join("",await _userManager.GetRolesAsync(loggedInUser));
            map.Role = role;
            map.Image = image;           

            return View(map);
        }

    }
}
