using MVCBlog.Data.Extensions;
using MVCBlog.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Extensions
builder.Services.AddDataLayer(builder.Configuration);
builder.Services.AddServiceLayer();


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

app.UseRouting();

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
