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
	config.LoginPath = "/Admin/Auth/Login"; //This is the automatic redirection path when the user is not authorized and tries to access an authorized page.
	config.LogoutPath = "/Admin/Auth/Logout";
	config.Cookie = new CookieBuilder
	{
		Name = "MVCBlog",
		HttpOnly = true,
		SameSite = SameSiteMode.Strict, // This is a security feature that prevents the browser from sending the cookie along with cross-site requests.
		SecurePolicy = CookieSecurePolicy.SameAsRequest // In production, this should be set to Always because it requires HTTPS to work.
	};
	config.SlidingExpiration = true; //If this is true, the cookie will be refreshed every time the user visits the site.
	config.ExpireTimeSpan = TimeSpan.FromDays(1); // This cookie will expire after 1 day.
	config.AccessDeniedPath = "/Admin/Auth/AccessDenied";
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
