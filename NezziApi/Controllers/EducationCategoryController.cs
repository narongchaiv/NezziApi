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
    public class EducationCategoryController : Controller
    {
        private readonly IEducationCategoryRepository repository;
        public EducationCategoryController(IEducationCategoryRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<EducationCategory> GetEducationCategory()
        {
            var categories = repository.GetEducationCategory();
            return categories;
        }

        [HttpGet("{id}")]
        public IEnumerable<EducationCategory> GetEducationCategoryById(int id)
        {
            var category = repository.GetEducationCategoryById(id);
            return category;
        }
    }
}