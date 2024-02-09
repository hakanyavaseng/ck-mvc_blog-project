using Microsoft.Extensions.DependencyInjection;
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
			return services;
		}
	}
}
