using DataAccessLayer;
using Entities;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UserManager
    {
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