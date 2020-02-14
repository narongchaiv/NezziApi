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
        public IEnumerable<EducationCategory> GetEducationCategories()
        {
            var categories = context.EducationCategories.ToList();

            return categories;
        }

        public EducationCategory GetEducationCategory(int id)
        {
            var category = context.EducationCategories.SingleOrDefault(e => e.Id == id);
            return category;
        }

        public EducationCategory CreateEducationCategory(EducationCategory educationCategory)
        {
            context.EducationCategories.Add(educationCategory);
            context.SaveChanges();

            return educationCategory;
        }

        public string UpdateEducationCategory(int id, EducationCategory educationCategory)
        {
            var educationCategoryInDb = context.EducationCategories.SingleOrDefault(e => e.Id == id);

            if (educationCategoryInDb != null)
            {
                educationCategoryInDb.Name = educationCategory.Name;
                educationCategoryInDb.Priority = educationCategory.Priority;
                context.SaveChanges();

                return "Success";
            }
            return "Fail";
        }

        public string DeleteEducationCategory(int id)
        {
            var educationCategoryInDb = context.EducationCategories.SingleOrDefault(e => e.Id == id);

            if (educationCategoryInDb != null)
            {
                context.Remove(educationCategoryInDb);
                context.SaveChanges();
                return "Success";
            }
            return "Fail";
        }
    }
}
