using NezziApi.Mapping.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NezziApi.Interface
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetCategory();

        IQueryable<Category> GetCategoryById(int id);

    }
}
