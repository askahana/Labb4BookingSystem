namespace Bokkingsystem.Models.Entities
{
    public class History
    {
        public int HistoryId { get; set; }
        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Description { get; set; }
    }
}
