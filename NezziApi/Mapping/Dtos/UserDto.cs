using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NezziApi.Mapping.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
    }
}
