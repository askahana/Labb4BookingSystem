using Bokkingsystem.Data;
using Bokkingsystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bokkingsystem.Services
{
    public class CustomerRepo: IBooking<Customer>
    {
        private BookingDbContext _db;
        public CustomerRepo(BookingDbContext db)
        {
            _db = db;   
        }

        public Task<Customer> Add(Customer NewEntity)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<Customer> GetSingel(int id)
        {
            return await _db.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        }

        public Task<Customer> Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
