using AutoMapper;
using NezziApi.Mapping.Dtos;
using NezziApi.Interface;
using NezziApi.Mapping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NezziApi.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper mapper;
        public UserRepository(IMapper mapper, NezziDbContext context)
        {
            this.mapper = mapper;
        }
        public IEnumerable<UserDto> GetUser()
        {
            var employeeList = GetUserAllDetail().ToList();

            return mapper.Map<List<User>, List<UserDto>>(employeeList);
        }

        public IEnumerable<User> GetUserAllDetail()
        {
            var employeeList = new List<User>();
            var employee = new User
            {
                Id = 1,
                UserId = "11",
                Name = "Narongchai",
                Surname = "Viriyarojanakul",
                Username = "narongchai.v"
            };

            employeeList.Add(employee);

            return employeeList;
        }


    }
}
