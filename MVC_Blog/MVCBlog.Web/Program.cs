using Microsoft.AspNetCore.Identity;
using MVCBlog.Data.Contexts;
using MVCBlog.Data.Extensions;
using MVCBlog.Entity.Entities.Identity;
using MVCBlog.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

#region Layer Extensions
//Extensions
builder.Services.AddDataLayer(builder.Configuration);
builder.Services.AddServiceLayer();
#endregion

builder.Services.AddSession();

#region Identity 

builder.Services
	.AddIdentity<AppUser, AppRole>(options =>
	{
		//In this function, password options can be set.
		options.Password.RequireNonAlphanumeric = false;
		options.Password.RequireLowercase = false;
		options.Password.RequireUppercase = false;
	})
	.AddRoleManager<RoleManager<AppRole>>()
	.AddEntityFrameworkStores<AppDbContext>()
	.AddDefaultTokenProviders();
#endregion

#region Cookie Settings
builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Auth/Login");
    config.LogoutPath = new PathString("/Admin/Auth/Logout");
    config.Cookie = new CookieBuilder
    {
        Name = "MVCBlog",
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        SecurePolicy = CookieSecurePolicy.SameAsRequest //Always 
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(7);
    config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");
});

#endregion



// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
	endpoints.MapAreaControllerRoute(
		name:"Admin",
		areaName:"Admin",
		pattern:"Admin/{controller=Home}/{action=Index}/{id?}");

	endpoints.MapDefaultControllerRoute();
});

app.Run();
