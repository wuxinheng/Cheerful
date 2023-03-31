using Microsoft.EntityFrameworkCore;

using System.Reflection;
using System.Text;

namespace Cheerful.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T t);

        void AddRange(List<T> ts);

        /// <summary>
        /// 更新对象指定字段
        /// </summary>
        /// <param name="t">实体</param>
        /// <param name="propertyNames">建议使用nameof</param>
        /// <returns></returns>
        int Modify(T t, params string[] propertyNames);

        /// <summary>
        /// 更新对象集合指定字段
        /// </summary>
        /// <param name="ts">实体集合</param>
        /// <param name="propertyNames">建议使用nameof</param>
        /// <returns></returns>
        int Modifys(List<T> ts, params string[] propertyNames);

        /// <summary>
        /// 获取一个新的编号
        /// </summary>
        /// <typeparam name="TEntity">实体</typeparam>
        /// <returns></returns>
        Task<string> NewNo();

        /// <summary>
        /// 查询分页数据
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="func">index、size、</param>
        /// <returns></returns>
        Task<Page<TResult>> Page<TResult>(int index, int size, Func<IQueryable<T>, IQueryable<TResult>> func);

        void Remove(T t);

        void RemoveRange(List<T> ts);

        int SaveChanges();

        Task<int> SaveChangesAsync();

        IQueryable<T> Set();
    }
}
