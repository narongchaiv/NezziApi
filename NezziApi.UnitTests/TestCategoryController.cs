using Moq;
using NezziApi.Controllers;
using NezziApi.Interface;
using NezziApi.Mapping.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NezziApi.UnitTests
{
    [TestFixture]
    public class TestCategoryController
    {
        private Mock<ICategoryRepository> _repository;
        [SetUp]
        public void Setup()
        {
            _repository = new Mock<ICategoryRepository>();
        }

        [Test]
        public void GetCategory_GetAllCategory_ReturnCategoryList()
        {
            var category = new Category
            {
                Id = 1,
                Priority = 1,
                Name = "Programming"
            };

            List<Category> categories = new List<Category>();
            categories.Add(category);

            var category1 = new Category
            {
                Id = 2,
                Priority = 2,
                Name = "Business"
            };

            categories.Add(category1);

            _repository.Setup(r => r.GetCategory()).Returns(categories);

            var controller = new CategoryController(_repository.Object);

            var result = controller.GetCategory();

            Assert.AreEqual(result, categories);
        }

        [Test]
        public void GetCategory_GetCategoryById_ReturnCategoryObject()
        {
            var category = new Category
            {
                Id = 1,
                Priority = 1,
                Name = "Programming"
            };

            List<Category> categories = new List<Category>();
            categories.Add(category);

            var category1 = new Category
            {
                Id = 2,
                Priority = 2,
                Name = "Business"
            };

            categories.Add(category1);

            _repository.Setup(r => r.GetCategoryById(1)).Returns(categories.Find(c => c.Id.Equals(1)));

            var controller = new CategoryController(_repository.Object);

            var result = controller.GetCategoryById(1);

            Assert.AreEqual(result, categories.Find(c => c.Id.Equals(1)));
        }
    }
}
