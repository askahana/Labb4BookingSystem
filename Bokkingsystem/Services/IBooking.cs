namespace Bokkingsystem.Services
{
    public interface IBooking<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingel(int id);
        Task<T> Update(T entity);
        Task<T> Add(T NewEntity);
        Task<T> Delete(int id);
    }
}
