using MVCBlog.Core.Entities;
using MVCBlog.Data.Repositories.Abstractions;

namespace MVCBlog.Data.UnitOfWorks
{
	public interface IUnitOfWork : IAsyncDisposable
	{
		IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();
		Task<int> SaveAsync();
		int Save();
	}
}
