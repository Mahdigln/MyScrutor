namespace MyScrutor.Services.Generic
{
    public interface IRepository<T>
    {
        void Save(T entity);
    }
}
