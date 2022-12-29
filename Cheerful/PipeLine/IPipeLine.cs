namespace Cheerful
{
    /// <summary>
    /// 管线接口
    /// </summary>
    /// <typeparam name="TContext">上下文</typeparam>
    public interface IPipeLine<TContext>
    {
        /// <summary>
        /// 管线阀门服务
        /// </summary>
        public IPipeLineService<TContext>? Service { set; get; }

        /// <summary>
        /// 新增阀门
        /// </summary>
        /// <typeparam name="TPipeLineService">阀门服务实现</typeparam>
        void Add<TPipeLineService>() where TPipeLineService : IPipeLineService<TContext>;

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="context"></param>
        void Invoke(TContext context);

        /// <summary>
        /// 设置当前阀门对象的下一阀门服务
        /// </summary>
        /// <param name="service">当前阀门</param>
        /// <param name="nextService">下个阀门</param>
        void SetNextService(IPipeLineService<TContext>? service, IPipeLineService<TContext>? nextService);
    }
}