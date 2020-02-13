using Microsoft.EntityFrameworkCore;
using NezziApi.Mapping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NezziApi.Persistence
{
    public class NezziDbContext : DbContext
    {
        public NezziDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<EducationCategory> EducationCategory { get; set; }
    }
}
