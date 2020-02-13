using AutoMapper;
using NezziApi.Interface;
using NezziApi.Mapping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NezziApi.Persistence.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMapper mapper;
        private readonly NezziDbContext context;
        public CategoryRepository(IMapper mapper, NezziDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }
        public IQueryable<Category> GetCategory()
        {
            var categories = context.Category;

            return categories;
        }

        public IQueryable<Category> GetCategoryById(int id)
        {
            var category = context.Category.Where(c => c.Id == id);
            return category;
        }
    }
}
