using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingModels.DTOs
{
   public class AppointmentDto
   {
        public int AppointmentId { get; set; }
        public int CustomerId { get; set; }
        public int CompanyId { get; set; }
        public DateTime BookedDate { get; set; }
   }
}
