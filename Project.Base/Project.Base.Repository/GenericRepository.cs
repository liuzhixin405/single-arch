using Microsoft.EntityFrameworkCore;
using Project.Base.IRepository;
using Project.Base.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Base.Repository
{
    public class GenericRepository<T,ID,Context> : IRepository<T,ID> where T: class,IEntity<ID> where Context: DbContext
    {
        private readonly Context _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }


        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }

        public async Task<ApiResult> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return new ApiResult() { Success = true };
        }

        public async Task<ApiResult> UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return new ApiResult() { Success = true};
        }

        public async Task<ApiResult> DeleteAsync(Expression<Func<T, bool>> filter)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(filter);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                return new ApiResult { Success = true, Status = 200};
            }
            return new ApiResult { Success = false, Message = "Entity not found" };
        }

        public async Task<PagedResult<T>> GetPagedAsync(PagingParameters<T> pagingParameters)
        {
            IQueryable<T> query = _dbSet;

            if (pagingParameters.Filter != null)
            {
                query = query.Where(pagingParameters.Filter);
            }

            if (pagingParameters.OrderBy != null)
            {
                query = pagingParameters.OrderBy(query);
            }

            var totalCount = await query.CountAsync();
            var items = await query.Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                                   .Take(pagingParameters.PageSize)
                                   .ToListAsync();

            return new PagedResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageSize = pagingParameters.PageSize,
                PageNumber = pagingParameters.PageNumber
            };
        }
    }
}
