using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserManager
    {
        IRepository<User> userRepository;

        public UserManager(IRepository<User> _userRepository)
        {
            userRepository = _userRepository;
        }

        public async Task<User> GetUser(int id)
        {
            return await userRepository.GetAsync(x => x.Id == id);
        }

        


    }
}

