using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos;
using Helper;

namespace BusinessLayer
{
    public class UserManager
    {
        MailHelper mailHelper;
        IRepository<User> userRepository;

        public UserManager(IRepository<User> _userRepository, MailHelper _mailHelper)
        {
            userRepository = _userRepository;
            mailHelper = _mailHelper;
        }

        public async Task<User> GetUser(int id)
        {
            return await userRepository.GetAsync(x => x.Id == id);
        }

         public async Task<List<User>> GetUsers()
        {
            return await userRepository.GetListAsync();
        }

        public async Task<User> Login(UserForLoginModel userModel)
        {
                User user = await userRepository.GetAsync(x => x.UserName == userModel.username.ToLower());

                if (user != null)
                {
                    if (VerifyPassword(userModel.password, user.PasswordHash, user.PasswordSalt))
                    {
                        return user;
                    }
                }
                return null;   
        }

        public async Task<User> Register(UserRegisterModel registerModel)
        {
            byte[] passwordSalt, passwordHash;

            CreatePasswordHash(registerModel.password, out passwordHash, out passwordSalt);

            var check = userRepository.Insert(new User{
                UserName = registerModel.username,
                Email = registerModel.email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            });

            if(check.Result > 0){
                User user = await userRepository.GetAsync(x=> x.Email == registerModel.email);

                string body = $"Merhaba {user.UserName} <br><br> Hesabýnýzý" +
                      $"aktifleþtirmek için <a target='_blank'>týklayýnýz</a>.";

                mailHelper.SendMail(body, user.Email, "Hesap Aktifleþtirme");
                return user;
            }
            return null;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512()){
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
                return true;
            }
        }
    }
}