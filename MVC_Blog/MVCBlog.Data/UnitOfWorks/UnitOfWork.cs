using MVCBlog.Data.Contexts;
using MVCBlog.Data.Repositories.Abstractions;
using MVCBlog.Data.Repositories.Concretes;

namespace MVCBlog.Data.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext context)
        {
			_context = context;
        }
        public async ValueTask DisposeAsync()
		{
			await _context.DisposeAsync();
		}
		public int Save()
		{
			return _context.SaveChanges();
		}
		public async Task<int> SaveAsync()
		{
			return await _context.SaveChangesAsync();
		}
		IRepository<T> IUnitOfWork.GetRepository<T>()
		{
			return new Repository<T>(_context);
		}
	}
}
