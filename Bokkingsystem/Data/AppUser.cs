
using Bokkingsystem.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Bokkingsystem.Data
{
    public class AppUser : IdentityUser
    {
        public string Role { get; set; }
        public string CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
