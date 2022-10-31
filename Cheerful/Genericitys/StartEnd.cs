namespace Cheerful
{

    /// <summary>
    /// 开始结束: <typeparamref name="T"/> 可以满足不同的场景
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStartEnd<T>
    {

        /// <summary>
        /// 开始
        /// </summary>
        T? Start { get; set; }

        /// <summary>
        /// 结束
        /// </summary>
        T? End { get; set; }
    }

    /// <summary>
    /// <see href="IStartEnd"/> 实现
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class StartEnd<T> : IStartEnd<T>
    {
        public T? Start { get; set; }
        public T? End { get; set; }
    }
}
