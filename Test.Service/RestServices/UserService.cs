using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Core.Interfaces.Repository.RestClients;
using Test.Core.Interfaces.Service.RestServices;
using Test.Core.Models.DTO;

namespace Test.Service.RestServices
{
    public class UserService : IUserService
    {
        #region Properties
        private readonly IUserClient _userClient;
        #endregion

        public UserService(IUserClient userClient)
        {
            _userClient = userClient;
        }

        public async Task<UserDto> GetUser(int id)
        {
            return await _userClient.GetUser(id);
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _userClient.GetUsers();
        }
    }
}
