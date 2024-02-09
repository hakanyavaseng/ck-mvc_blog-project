using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MVCBlog.Data.Contexts;
using MVCBlog.Data.Repositories.Abstractions;
using MVCBlog.Data.Repositories.Concretes;
using MVCBlog.Data.UnitOfWorks;

namespace MVCBlog.Data.Extensions
{
	public static class DataLayerExtensions
	{
		public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration) 
		{
			// Add generic repository
			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

			// Add unit of work
			services.AddScoped<IUnitOfWork, UnitOfWork>();

			// Add DbContext
			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

			return services;
		}
	}
}
