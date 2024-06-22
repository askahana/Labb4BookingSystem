

using Bokkingsystem.Models.Entities;

namespace Bokkingsystem.Services
{
    public interface IHisotry
    {
        Task<IEnumerable<History>> GetAll();
    }
}
