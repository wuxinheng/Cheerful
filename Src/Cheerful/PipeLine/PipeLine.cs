namespace Cheerful
{
    /// <summary>
    /// 管线实现
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class PipeLine<TContext> : IPipeLine<TContext>
    {
        public IPipeLineService<TContext>? Service { get; set; }

        public void Add<TPipeLineService>() where TPipeLineService : IPipeLineService<TContext>
        {
            var instance = Activator.CreateInstance(typeof(TPipeLineService)) as IPipeLineService<TContext>;

            if (Service is null)
            {
                Service = instance;
            }
            else
            {
                SetNextService(Service, instance);
            }
        }

        public virtual void Invoke(TContext context)
        {
            Service?.Invoke(context);
        }

        public void SetNextService(IPipeLineService<TContext>? service, IPipeLineService<TContext>? nextService)
        {
            if (service?.NextService is null)
            {
                service!.NextService = nextService;
            }
            else
            {
                SetNextService(service.NextService, nextService);
            }
        }
    }
}