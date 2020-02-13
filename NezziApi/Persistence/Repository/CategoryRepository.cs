using AutoMapper;
using NezziApi.Interface;
using NezziApi.Mapping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NezziApi.Persistence.Repository
{
    public class CategoryRepository : IEducationCategoryRepository
    {
        private readonly IMapper mapper;
        private readonly NezziDbContext context;
        public CategoryRepository(IMapper mapper, NezziDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public IEnumerable<EducationCategory> GetCategory()
        {
            var categories = context.EducationCategory.ToList();

            return categories;
        }

        public IEnumerable<EducationCategory> GetCategoryById(int id)
        {
            var category = context.EducationCategory.Where(c => c.Id == id);
            return category;
        }
    }
}
