using BookingModels;

namespace Bokkingsystem.Services
{
    public interface IHisotry
    {
        Task<IEnumerable<History>> GetAll();
    }
}
