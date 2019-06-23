namespace CleverStocker.Services
{
    /// <summary>
    /// 服务基类
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class ServiceBase<TEntity> : IService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceBase{TEntity}"/> class.
        /// </summary>
        public ServiceBase()
        {
        }
    }
}
