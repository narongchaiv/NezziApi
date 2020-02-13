using NezziApi.Mapping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NezziApi.Interface
{
    public interface IEducationCategoryRepository
    {
        IEnumerable<EducationCategory> GetEducationCategory();

        IEnumerable<EducationCategory> GetEducationCategoryById(int id);

        //IEnumerable<EducationCategory> CreateEducationCategory(int id);
    }
}
