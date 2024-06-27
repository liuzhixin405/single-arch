namespace Project.Base.IService
{
    public interface ICommOperate<TEntity> where TEntity : class
    {
        DateTime CurrentTime { get; }
    }
}
