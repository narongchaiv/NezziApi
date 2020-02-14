using NezziApi.Mapping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NezziApi.Interface
{
    public interface IEducationCategoryRepository
    {
        IEnumerable<EducationCategory> GetEducationCategories();

        EducationCategory GetEducationCategory(int id);

        EducationCategory CreateEducationCategory(EducationCategory educationCategory);

        string UpdateEducationCategory(int id, EducationCategory educationCategory);

        string DeleteEducationCategory(int id);
    }
}
