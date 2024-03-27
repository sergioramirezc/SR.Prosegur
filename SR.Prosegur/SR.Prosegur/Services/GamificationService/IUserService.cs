using SR.Prosegur.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SR.Prosegur.Services.UserService
{
    public interface IUserService
    {
        public Task<IEnumerable<UserModel>> GetUsers(int size = 20);
    }
}
