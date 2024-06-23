using Bokkingsystem.Data;
using System.ComponentModel.DataAnnotations;

namespace Bokkingsystem.Models.Entities
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        [Required(ErrorMessage = "Company name is required.")]
        [StringLength(30)]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //  public AppUser AppUser { get; set; }
        // public string AppUserId { get; set; }
        public string Role { get; set; } = "company";
    }
}
