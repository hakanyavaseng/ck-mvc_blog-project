using Microsoft.Extensions.DependencyInjection;
using MVCBlog.Service.Services.Abstractions;
using MVCBlog.Service.Services.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCBlog.Service.Extensions
{
	public static class ServiceLayerExtensions
	{
		public static IServiceCollection AddServiceLayer(this IServiceCollection services)
		{
			services.AddScoped<IArticleService, ArticleService>();
			return services;
		}
	}
}
