using BookingModels;
using Microsoft.EntityFrameworkCore;

namespace Bokkingsystem.Data
{
    public class BookingDbContext:DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> Options): base(Options) { }
      
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<History> Histories { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyId = 1,
                CompanyName = "Saftfabriken"
            }) ;
            modelBuilder.Entity<Company>().HasData(new Company
            {
                CompanyId = 2,
                CompanyName = "Pommesfabriken"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                FirstName = "Andreas",
                LastName = "Andersson",
                Email = "andre@mail.se",
                UserName = "Andreas",
                Password = "1234"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 2,
                FirstName = "Bengt",
                LastName = "Bengtsson",
                Email = "benben@mail.se",
                UserName = "benben",
                Password = "1234"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 3,
                FirstName = "Carl",
                LastName = "Carlsson",
                Email = "carl@mail.se",
                UserName = "carlycarl",
                Password = "1234"
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentId = 1,
                CustomerId = 1,
                CompanyId = 1,
                BookedDate = new DateTime(2024, 04,23, 14,30,0),
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentId = 2,
                CustomerId = 1,
                CompanyId = 1,
                BookedDate = new DateTime(2024, 04, 25, 13,00,0),
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentId = 3,
                CustomerId = 1,
                CompanyId = 1,
                BookedDate = new DateTime(2024, 04, 29, 13,00,0),
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentId = 4,
                CustomerId = 1,
                CompanyId = 1,
                BookedDate = new DateTime(2024, 05, 21, 14,30,0),
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment
            {
                AppointmentId = 5,
                CustomerId = 2,
                CompanyId = 1,
                BookedDate = new DateTime(2024, 05, 22, 11,15,0),
                CreatedDate = DateTime.Now,
                ModifiedDate = null,
            });

        }

    }
}
