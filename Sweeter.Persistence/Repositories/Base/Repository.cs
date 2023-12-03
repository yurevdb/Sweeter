namespace Sweeter.Server.Persistence;

public interface Repository<T>
{
    Task Insert(T entity);

    Task Update(T entity);

    Task Delete(T entity);

    Task<IEnumerable<T>> GetAll();
}
