using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Core.Models.DTO;

namespace Test.Core.Interfaces.Service.RestServices
{
    public interface IUserService
    {
        Task<UserDto> GetUser(int id);
        Task<IEnumerable<UserDto>> GetUsers();
    }
}
