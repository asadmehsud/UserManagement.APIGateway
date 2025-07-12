using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UserManagement.APIGateway.Data.Entities;
using UserManagement.APIGateway.Data.Entities.Enum;

namespace UserManagement.APIGateway.Data
{
    public class UserManagementDbContext(DbContextOptions<UserManagementDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData
                (
                new User
                {
                    Id = new Guid("44e59eb2-dcf3-4824-9b91-9e82c7a757d4"),
                    Address = "DDA",
                    City = "Dikhan",
                    Country = "Pakistan",
                    Contact = "03429765706",
                    Email = "asad@gmail.com",
                    FirstName = "Asad",
                    LastName = "Khan",
                    Image = "image",
                    Otp = "123",
                    Role = Role.Admin,
                    UserName = "asad_1",
                    PasswordHash = [],
                    PasswordSalt = []
                },
                new User { Id = new Guid("937f789f-5bdf-43d0-8e62-912743264f85"), Address = "Tank Ada", City = "Dikhan", Country = "Pakistan", Contact = "03457788900", Email = "ali@gmail.com", FirstName = "Ali", LastName = "Khan", Image = "image", Otp = "009", Role = Role.User, UserName = "ali_2", PasswordHash = [], PasswordSalt = [] },
                new User { Id = new Guid("73bcf899-bee3-4f95-8f7d-bbdaa1aa53ff"), Address = "Haji Abad", City = "FaisalAbad", Country = "Pakistan", Contact = "03334566430", Email = "faizan@gmail.com", FirstName = "Faizan", LastName = "Ahmed", Image = "image", Otp = "111", Role = Role.Admin, UserName = "fazan_0", PasswordHash = [], PasswordSalt = [] },
                new User { Id = new Guid("c7601d97-7cf8-4057-a53f-6500209e6083"), Address = "Korangi", City = "Karachi", Country = "Pakistan", Contact = "03001002001", Email = "alya@gmail.com", FirstName = "Alya", LastName = "Khan", Image = "image", Otp = "333", Role = Role.User, UserName = "alya_9", PasswordHash = [], PasswordSalt = [] }
                );
        }
        //private void CreatePassword(string password, out byte[] passwordhash, out byte[] passwordsalt)
        //{
        //    var hmac = new HMACSHA512();
        //    passwordsalt = hmac.Key;
        //    passwordhash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        //}
    }
}
