using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace Cheerful.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class, new()
    {
        public readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<string> NewBusinessCode()
        {
            var property = typeof(T).GetProperties().Where(x => x.GetCustomAttribute(typeof(BuildCodeAttribute), true) is BuildCodeAttribute).FirstOrDefault();
           await _dbContext.Set<T>().OrderBy(x => EF.Property<string>(x, property!.Name)).Select(x => EF.Property<string>(x, property!.Name)).FirstOrDefaultAsync();
            return "";
        }

        //public async Task<string> GetObjectNewCode<TEntity>() where TEntity : class
        //{
        //    var property = typeof(TEntity).GetProperties().Where(x => x.GetCustomAttribute(typeof(ObjectCodeAttribute), true) is ObjectCodeAttribute).FirstOrDefault();
        //    if (property == null)
        //    {
        //        throw new ArgumentNullException("实体中找不到使用ObjectCodeAttribute的属性");
        //    }

        //    var objectCode = property?.GetCustomAttribute(typeof(ObjectCodeAttribute), true) as ObjectCodeAttribute;
        //    if (objectCode == null)
        //    {
        //        throw new ArgumentNullException("ObjectCodeAttribute 转换错误");
        //    }

        //    using (DbContext db = new T())
        //    {
        //        var dateString = DateTime.Now.ToString("YYYYMMdd");
        //        int sequence = 0;
        //        var recentlyCode = await db.Set<TEntity>().OrderBy(x => EF.Property<string>(x, property!.Name)).Select(x => EF.Property<string>(x, property!.Name)).FirstOrDefaultAsync();
        //        if (!string.IsNullOrWhiteSpace(recentlyCode))
        //        {
        //            sequence = int.Parse(recentlyCode.Substring(7, 2)) + 1;
        //        }

        //        return $"{objectCode.Prefix}{dateString}{sequence.ToString().PadLeft(objectCode.SequenceLength, '0')}{objectCode.Postfix}";
        //    }

        //}

        public Task<Page<TResult>> Page<TResult>(int index, int size, Func<IQueryable<T>, IQueryable<TResult>> func)
        {
            using DbContext db = new T();
            var values = db.Set<T>().AsNoTracking();
            var data = func.Invoke(values);

            Page<TResult> page = new()
            {
                Data = data.Take(index).Skip(size).ToList(),
                Index = index,
                Total = data.Count(),
                TotalPgae = data.Count() / size
            };
            return Task.FromResult(page);
        }

        public virtual Task<Page<TResult>> Page<TResult>(Func<int, int, IQueryable<T>, IQueryable<TResult>> func)
        {
            throw new NotImplementedException();
        }
    }

    
    
}