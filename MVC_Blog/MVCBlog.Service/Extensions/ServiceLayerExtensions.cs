using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MVCBlog.Service.FluentValidations;
using MVCBlog.Service.Services.Abstractions;
using MVCBlog.Service.Services.Concretes;
using System.Reflection;

namespace MVCBlog.Service.Extensions
{
    public static class ServiceLayerExtensions
	{
		public static IServiceCollection AddServiceLayer(this IServiceCollection services)
		{
			var assembly = Assembly.GetExecutingAssembly();
			services.AddScoped<IArticleService, ArticleService>();
			services.AddScoped<ICategoryService, CategoryService>();
			services.AddAutoMapper(assembly);


			//TODO : Refactor deprecated method with FluentValidation's document
			services.AddControllersWithViews().AddFluentValidation(opt =>
			{
				opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
				opt.DisableDataAnnotationsValidation = true;
				opt.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("tr"); // Error mesaages in Turkish
			});

			//It is used to get the logged in user's information
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
          


            return services;
		}
	}
}
