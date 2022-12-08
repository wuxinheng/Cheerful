namespace Cheerful.PipeLine
{
    /// <summary>
    /// 管线阀门接口
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IPipeLineService<TContext>
    {
        /// <summary>
        /// 下个执行的阀门服务
        /// </summary>
        public IPipeLineService<TContext>? NextService { get; set; }

        /// <summary>
        /// 执行NextService服务,从而达到链式效果
        /// </summary>
        /// <param name="context"></param>
        public void Invoke(TContext context);
    }
}