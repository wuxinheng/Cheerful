namespace Cheerful
{
    /// <summary>
    /// 管线阀门基础实现
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class PipeLineService<TContext> : IPipeLineService<TContext>
    {
        public IPipeLineService<TContext>? NextService { get; set; }

        public virtual void Invoke(TContext context)
        {
            NextService?.Invoke(context);
        }
    }
}
