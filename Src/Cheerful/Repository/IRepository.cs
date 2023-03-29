namespace Cheerful.Repository
{
    public interface IRepository<T> where T : class
    {
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
        Task<Page<TResult>> Page<TResult>(Func<int, int, IQueryable<T>, IQueryable<TResult>> func);
    }
}
