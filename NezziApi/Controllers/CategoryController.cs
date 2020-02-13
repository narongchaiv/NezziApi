using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NezziApi.Interface;
using NezziApi.Mapping.Model;

namespace NezziApi.Controllers
{
    [Route("/api/category")]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository repository;
        public CategoryController(ICategoryRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IQueryable<Category> GetCategory()
        {
            var categories = repository.GetCategory();
            return categories;
        }

        [HttpGet("{id}")]
        public IQueryable<Category> GetCategoryById(int id)
        {
            var category = repository.GetCategoryById(id);
            return category;
        }
    }
}