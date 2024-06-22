namespace Bokkingsystem.Models.DTOs
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public DateTime BookedDate { get; set; }
    }
}
