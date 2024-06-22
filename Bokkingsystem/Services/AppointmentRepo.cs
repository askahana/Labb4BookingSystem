using Bokkingsystem.Data;
using Bokkingsystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Bokkingsystem.Services
{
    public class AppointmentRepo: IAppointment
    {
        private BookingDbContext _db;
        public AppointmentRepo(BookingDbContext db)
        {
            _db = db;
        }

        public async Task<Appointment> Add(Appointment NewEntity)
        {
            var result = await _db.Appointments.AddAsync(NewEntity);
            await _db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> AppointmentExist(int appointmentId)
        {
            return await _db.Appointments.AnyAsync(a => a.AppointmentId == appointmentId);
        }

        public async Task<bool> CompanyExist(int companyId)
        {
            return await _db.Appointments.AnyAsync(a => a.CompanyId == companyId);
        }

        public async Task<bool> CustomerExist(int cusomterId)
        {
            return await _db.Appointments.AnyAsync(a => a.CustomerId == cusomterId);
        }

        public async Task<Appointment> Delete(int id)
        {
            var result = await _db.Appointments.FirstOrDefaultAsync(a => a.AppointmentId == id);
            if(result != null)
            {
                _db.Appointments.Remove(result);
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<Appointment>> GetAll()
        {
            return await _db.Appointments.Include(c=> c.Customer).Include(c=> c.Company).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllByCompanyId(int companyId)
        {
            return await _db.Appointments.Include(c => c.Customer).Include(c => c.Company).Where(a => a.CompanyId == companyId).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllByCustomerId(int customerId)
        {
            return await _db.Appointments.Include(c => c.Customer).Include(c => c.Company).Where(a => a.CustomerId == customerId).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllByMonth(int year, int month, int companyId)
        {
            DateTime firstDate = new DateTime(year, month, 1);
            DateTime lastDate = firstDate.AddMonths(1).AddDays(-1);
            return await _db.Appointments.Include(c => c.Customer)
                .Include(c => c.Company).
                Where(a=> a.BookedDate >= firstDate && a.BookedDate <= lastDate)
                .Where(a=> a.CompanyId == companyId).ToListAsync();
        }
        // Alla appointments by specific week
        public async Task<IEnumerable<Appointment>> GetAllByWeek(int year, int weekNum)
        {
            DateTime sunday = ISOWeek.ToDateTime(year, weekNum, 0);
            DateTime monday = sunday.AddDays(-6);

            return await _db.Appointments
                .Include(c => c.Customer).Include(c => c.Company).
                Where(a=> a.BookedDate >= monday && a.BookedDate <= sunday).ToListAsync();
        }
        // All Appointments by specific customerID and specific week
        public async Task<IEnumerable<Appointment>> GetAllByWeekAndCusomterID(int year, int weekNum, int customerId)
        {
            DateTime sunday = ISOWeek.ToDateTime(year, weekNum, 0);
            DateTime monday = sunday.AddDays(-6);

            return await _db.Appointments
                .Include(c => c.Customer).Include(c => c.Company).
                Where(a => a.BookedDate >= monday && a.BookedDate <= sunday && a.CustomerId == customerId).ToListAsync();
        }

        
        public async Task<Appointment> GetSingel(int appointmentId)
        {
            return await _db.Appointments.Where(a => a.AppointmentId == appointmentId).FirstOrDefaultAsync();
        }

        public async Task<Appointment> Update(Appointment entity)
        {
            var result = await _db.Appointments.FirstOrDefaultAsync
                (a => a.AppointmentId == entity.AppointmentId);
   
            if (result != null)
            {
                var history = new History
                {
                    AppointmentId = result.AppointmentId,
                    ModifiedDate = DateTime.Now,

            
                };
                
                result.BookedDate = entity.BookedDate;
                result.ModifiedDate = DateTime.Now;
                _db.Histories.Add(history);
                await _db.SaveChangesAsync();
                return result;
            }
            return null;
        }

        /*  var hisotry = await _db.Histories.FirstOrDefaultAsync
         (a => a.AppointmentId == entity.AppointmentId);
     hisotry.ModifiedDate = DateTime.Now;
     hisotry.AppointmentId = entity.AppointmentId;
     hisotry.Description = "Changed";
     await _db.SaveChangesAsync();*/
    }
}
