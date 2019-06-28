namespace CleverStocker.Model
{
    /// <summary>
    /// 允许复制
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface ICopyable<TEntity>
    {
        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="entity"></param>
        void CopyTo(TEntity entity);
    }
}
