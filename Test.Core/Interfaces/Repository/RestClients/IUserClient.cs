using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Core.Models.DTO;

namespace Test.Core.Interfaces.Repository.RestClients
{
    public interface IUserClient
    {
        Task<UserDto> GetUser(int id);
        Task<IEnumerable<UserDto>> GetUsers();
    }
}
