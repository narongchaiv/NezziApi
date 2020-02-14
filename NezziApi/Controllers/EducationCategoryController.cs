using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using NezziApi.Interface;
using NezziApi.Mapping.Model;

namespace NezziApi.Controllers
{
    [Route("/api/educationcategory")]
    public class EducationCategoryController : Controller
    {
        private readonly IEducationCategoryRepository repository;
        public EducationCategoryController(IEducationCategoryRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<EducationCategory> GetEducationCategories()
        {
            var categories = repository.GetEducationCategories();
            return categories;
        }

        [HttpGet("{id}")]
        public IActionResult GetEducationCategory(int id)
        {
            var category = repository.GetEducationCategory(id);

            if (category == null)
               return NotFound();

            return Ok(category);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateEducationCategory([FromBody]EducationCategory educationCategory)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            educationCategory = repository.CreateEducationCategory(educationCategory);
            return CreatedAtAction(nameof(GetEducationCategory), new { id = educationCategory.Id }, educationCategory);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateEducationCategory(int id, [FromBody]EducationCategory educationCategory)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(repository.UpdateEducationCategory(id, educationCategory));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEducationCategory(int id)
        {
            return Ok(repository.DeleteEducationCategory(id));
        }

    }
}