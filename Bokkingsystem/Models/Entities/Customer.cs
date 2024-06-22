using Bokkingsystem.Data;
using System.ComponentModel.DataAnnotations;

namespace Bokkingsystem.Models.Entities
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Firstname is required.")]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lastname is required.")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(10)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Role { get; set; } = "Customer";
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public ICollection<Appointment> Appointment { get; set; }

    }
}
