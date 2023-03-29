using Microsoft.EntityFrameworkCore;

using System.Reflection;
using System.Text;

namespace Cheerful.Repository
{
    public class Repository<T> : IRepository<T>
        where T : class, new()
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void Add(T t)
        {
            _dbContext.Add(t);
        }
        public virtual int SaveChanges() => _dbContext.SaveChanges();
        public virtual Task<int> SaveChangesAsync() => _dbContext.SaveChangesAsync();

        public virtual async Task<string> NewNo()
        {
            var property = typeof(T).GetProperties().Where(x => x.GetCustomAttribute(typeof(BuildCodeAttribute), true) is BuildCodeAttribute).FirstOrDefault();
            if (property is null)
            {
                throw new ArgumentNullException("实体中找不到使用ObjectCodeAttribute的属性");
            }

            var objectCode = property?.GetCustomAttribute(typeof(BuildCodeAttribute), true) as BuildCodeAttribute;
            if (objectCode is null)
            {
                throw new ArgumentNullException("ObjectCodeAttribute 转换错误");
            }


            var dateString = DateTime.Now.ToString("yyyyMMdd");
            int sequence = 0;
            var recentlyCode = await _dbContext.Set<T>()
                .Where(x => EF.Property<string>(x, property!.Name) != null)
                .OrderByDescending(x => EF.Property<string>(x, property!.Name))
                .Select(x => EF.Property<string>(x, property!.Name))
                .FirstOrDefaultAsync();
            var sb=new StringBuilder(recentlyCode);
            if (!string.IsNullOrWhiteSpace(recentlyCode))
            {
                sb.Replace(objectCode!.Prefix,"");
                sb.Replace(objectCode!.Postfix,"");

                sequence = int.Parse(recentlyCode.PadLeft(objectCode.SequenceLength)) + 1;
            }

            return $"{objectCode.Prefix}{dateString}{sequence.ToString().PadLeft(objectCode.SequenceLength, '0')}{objectCode.Postfix}";


        }

        //public Task<Page<TResult>> Page<TResult>(int index, int size, Func<IQueryable<T>, IQueryable<TResult>> func)
        //{
        //    using DbContext db = new T();
        //    var values = db.Set<T>().AsNoTracking();
        //    var data = func.Invoke(values);

        //    Page<TResult> page = new()
        //    {
        //        Data = data.Take(index).Skip(size).ToList(),
        //        Index = index,
        //        Total = data.Count(),
        //        TotalPgae = data.Count() / size
        //    };
        //    return Task.FromResult(page);
        //}

        public virtual Task<Page<TResult>> Page<TResult>(Func<int, int, IQueryable<T>, IQueryable<TResult>> func)
        {
            throw new NotImplementedException();
        }
    }



}