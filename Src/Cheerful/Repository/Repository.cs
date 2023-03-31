using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

        public virtual void Add(T t) => _dbContext.Add(t);

        public virtual void AddRange(List<T> ts) => _dbContext.AddRange(ts);

        public virtual int Modify(T t, params string[] propertyNames)
        {
            var entry = _dbContext.Entry<T>(t);
            entry.State = EntityState.Unchanged;
            foreach (string proName in propertyNames)
            {
                entry.Property(proName).IsModified = true;
            }
            return _dbContext.SaveChanges();

        }

        public virtual int Modifys(List<T> ts, params string[] propertyNames)
        {
            foreach (var item in ts)
            {
                var entry = _dbContext.Entry<T>(item);
                entry.State = EntityState.Unchanged;
                foreach (string proName in propertyNames)
                {
                    entry.Property(proName).IsModified = true;
                }
            }
            return _dbContext.SaveChanges();
        }

        public virtual async Task<string> NewNo()
        {
            var property = typeof(T).GetProperties()
                .FirstOrDefault(x => x.GetCustomAttribute<BuildCodeAttribute>() != null) ?? throw new NullReferenceException();

            var objectCode = (property?.GetCustomAttribute<BuildCodeAttribute>()) ?? throw new NullReferenceException();

            var recentlyCode = await _dbContext.Set<T>()
                .Where(x => EF.Property<string>(x, property.Name) != null)
                .OrderByDescending(x => EF.Property<string>(x, property.Name))
                .Select(x => EF.Property<string>(x, property.Name))
                .FirstOrDefaultAsync();

            var sb = new StringBuilder(recentlyCode);

            var dateString = DateTime.Now.ToString("yyyyMMdd");
            int sequence = 0;

            if (!string.IsNullOrWhiteSpace(recentlyCode))
            {
                sb.Replace(objectCode.Prefix ?? "", "");
                sb.Replace(objectCode.Postfix ?? "", "");
                sequence = int.Parse(sb.ToString()[(sb.Length - objectCode.SequenceLength)..]) + 1;
            }

            return $"{objectCode.Prefix}{dateString}{sequence.ToString().PadLeft(objectCode.SequenceLength, '0')}{objectCode.Postfix}";
        }

        public virtual Task<Page<TResult>> Page<TResult>(int index, int size, Func<IQueryable<T>, IQueryable<TResult>> func)
        {
            var values = _dbContext.Set<T>().AsNoTracking();
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

        public virtual void Remove(T t) => _dbContext.Remove(t);
        public virtual void RemoveRange(List<T> ts) => _dbContext.RemoveRange(ts);

        public virtual int SaveChanges() => _dbContext.SaveChanges();

        public virtual Task<int> SaveChangesAsync() => _dbContext.SaveChangesAsync();

        public virtual IQueryable<T> Set() => _dbContext.Set<T>();
    }
}