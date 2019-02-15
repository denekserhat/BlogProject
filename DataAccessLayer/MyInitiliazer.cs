using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class MyInitiliazer
    {
        private readonly BlogContext context;

        public MyInitiliazer(BlogContext _context)
        {
            context = _context;
        }

        public void Seed()
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash("password", out passwordHash, out passwordSalt);

            User user = new User
            {
                FirstName = "fatih",
                LastName = "arslan",
                UserName = "fatiharslan",
                Email = "fatih@gmail.com",
                ActivatedGuid = Guid.NewGuid(),
                IsActive = true,
                IsAdmin = true,
                Photourl = "StandartUser.png",
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                OnCreated = DateTime.Now,
                OnModified = DateTime.Now.AddHours(1),
                ModifiedUsername = "fatiharslan"

            };

            context.Users.Add(user);
            context.SaveChanges();
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
    }

}
