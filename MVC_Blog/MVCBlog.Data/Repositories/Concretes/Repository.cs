using Microsoft.EntityFrameworkCore;
using MVCBlog.Core.Entities;
using MVCBlog.Data.Contexts;
using MVCBlog.Data.Repositories.Abstractions;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace MVCBlog.Data.Repositories.Concretes
{
	public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()
	{
		private readonly AppDbContext dbContext; 

		public Repository(AppDbContext dbContext)
        {
			this.dbContext = dbContext;
		}

		private DbSet<T> Table { get => dbContext.Set<T>(); }

		//Task = void, Task is used for async methods
		public async Task AddAsync(T entity) => await Table.AddAsync(entity);
		public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate) => await Table.AnyAsync(predicate);
		public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null) => await Table.CountAsync(predicate);
		public async Task DeleteAsync(T entity)
		{
			await Task.Run(() => Table.Remove(entity));
		}
		public async Task<List<T>> GetAllAsync(Expression<Func<T,bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
											//First parameter is used to filter the data, second parameter is used to include related entities.
		{
			IQueryable<T> query = Table;
			if(predicate != null)
				query = query.Where(predicate);
			if(includeProperties.Any())
			{
				foreach(var includeProperty in includeProperties)
				{
					query = query.Include(includeProperty);
				}
			}
			return await query.ToListAsync();
		}
		public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
		{
			//Arrange predicate
			IQueryable<T> query = Table;
			query = query.Where(predicate);

			//Arrange includings
			if (includeProperties.Any())
				foreach( var includeProperty in includeProperties)
					query = query.Include(includeProperty);

			return await query.SingleAsync();
		}
		public async Task<T> GetByGuidAsync(Guid guid) => await Table.FindAsync(guid);
		public async Task UpdateAsync(T entity) // There is no async Update method default, but Task.Run is used.
		{
			await Task.Run(() => Table.Update(entity));			
		}
	}
}
