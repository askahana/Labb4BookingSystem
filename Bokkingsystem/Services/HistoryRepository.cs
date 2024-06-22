using Bokkingsystem.Data;
using Bokkingsystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bokkingsystem.Services
{
    public class HistoryRepository: IHisotry
    {
        private BookingDbContext _context;
        public HistoryRepository(BookingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<History>> GetAll()
        {
            return await _context.Histories.ToListAsync();
        }
    }
}
