using NezziApi.Mapping.Dtos;
using NezziApi.Mapping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NezziApi.Interface
{
    public interface IUserRepository
    {
        //Task<IEnumerable<EmployeeDto>> GetEmployee();

        IEnumerable<UserDto> GetUser();

        IEnumerable<User> GetUserAllDetail();
    }
}
