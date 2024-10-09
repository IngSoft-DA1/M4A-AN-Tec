namespace Repository;

public interface IRepository <T>
{
    T Add(T oneElement);
    
    T? Find(Func<T, bool> filter);

    IList<T> FindAll();

    T? Update(T updatedEntity);

    void Delete(int id);
}