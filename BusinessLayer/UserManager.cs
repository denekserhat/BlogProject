<<<<<<< HEAD
﻿using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
=======
using DataAccessLayer;
using Entities;
>>>>>>> master
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserManager
    {
<<<<<<< HEAD
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
=======
         IRepository<User> userManager;
         //Photos
   

        public UserManager(IRepository<User> um)
        {
        userManager = um;
        }

        public async Task<User> Get(int id) {
            return await userManager.GetAsync(x => x.Id == id);
        }

    }
}
>>>>>>> master
