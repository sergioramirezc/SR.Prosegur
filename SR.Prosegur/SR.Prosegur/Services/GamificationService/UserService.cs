using SR.Prosegur.Models;
using SR.Prosegur.Models.Common;
using SR.Prosegur.Services.RequestProvider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SR.Prosegur.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IRequestProvider _requestProvider;

        public UserService(IRequestProvider requestProvider)
        {
            this._requestProvider = requestProvider;
        }

        public async Task<IEnumerable<UserModel>> GetUsers(int size = 20)
        {
            try
            {
                string uri = String.Format(Constants.BaseEndpoint + string.Format(Constants.UserPath, size));
                var response = await _requestProvider.GetAsync<IEnumerable<UserModel>>(uri);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
