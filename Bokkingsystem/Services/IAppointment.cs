using BookingModels;

namespace Bokkingsystem.Services
{
    public interface IAppointment
    {
        Task<IEnumerable<Appointment>> GetAll();
        Task<Appointment> GetSingel(int appointmentId);
        Task<IEnumerable<Appointment>> GetAllByCustomerId(int customerId);
        Task<IEnumerable<Appointment>> GetAllByCompanyId(int companyId);

        Task<IEnumerable<Appointment>> GetAllByWeek(int year, int weekNum);
        Task<IEnumerable<Appointment>> GetAllByMonth(int year, int month, int companyId);

        Task<Appointment> Update(Appointment entity);
        Task<Appointment> Add(Appointment NewEntity);
        Task<Appointment> Delete(int id);

        Task<bool> AppointmentExist(int appointmentId);
        Task<bool> CompanyExist(int companyId);
        Task<bool> CustomerExist(int cusomterId);
    }
}
