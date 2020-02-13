using AutoMapper;
using NezziApi.Interface;
using NezziApi.Mapping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NezziApi.Persistence.Repository
{
    public class EducationCategoryRepository : IEducationCategoryRepository
    {
        private readonly IMapper mapper;
        private readonly NezziDbContext context;
        public EducationCategoryRepository(IMapper mapper, NezziDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public IEnumerable<EducationCategory> GetEducationCategory()
        {
            var categories = context.EducationCategories.ToList();

            return categories;
        }

        public IEnumerable<EducationCategory> GetEducationCategoryById(int id)
        {
            var category = context.EducationCategories.Where(c => c.Id == id);
            return category;
        }
    }
}
