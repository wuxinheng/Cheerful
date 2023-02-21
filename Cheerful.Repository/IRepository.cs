using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cheerful.Repository
{
    public interface IRepository<T> where T : DbContext
    {
        // 获取最新编号
        public Task<string> GetObjectNewCode<TEntity>() where TEntity : class;
        // 筛选后排序并分页
        Task<Page<TResult>> Page<TResult>(int index, int size, Func<IQueryable<T>, IQueryable<TResult>> func);
    }
}
