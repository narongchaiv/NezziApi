﻿using Moq;
using NezziApi.Controllers;
using NezziApi.Interface;
using NezziApi.Mapping.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NezziApi.UnitTests
{
    [TestFixture]
    public class TestCategoryController
    {
        private Mock<IEducationCategoryRepository> _repository;
        private EducationCategory eduCategory;
        List<EducationCategory> educationCategories;
        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IEducationCategoryRepository>();
            eduCategory = new EducationCategory
            {
                Id = 1,
                Priority = 1,
                Name = "Programming"
            };

            educationCategories = new List<EducationCategory>();

            educationCategories.Add(eduCategory);

            _repository.Setup(r => r.GetEducationCategories()).Returns(educationCategories);
        }

        [Test]
        public void GetCategory_GetAllCategory_ReturnCategoryList()
        {
            var controller = new EducationCategoryController(_repository.Object);

            var result = controller.GetEducationCategories();

            Assert.AreEqual(result, educationCategories);
        }

        [Test]
        public void GetCategory_GetCategoryById_ReturnCategoryObject()
        {
            var category = new EducationCategory
            {
                Id = 1,
                Priority = 1,
                Name = "Programming"
            };

            educationCategories.Add(category);

            var category1 = new EducationCategory
            {
                Id = 2,
                Priority = 2,
                Name = "Business"
            };

            educationCategories.Add(category1);

            _repository.Setup(r => r.GetEducationCategory(1)).Returns(educationCategories.SingleOrDefault(c=>c.Id == 1));

            var controller = new EducationCategoryController(_repository.Object);

            var result = controller.GetEducationCategory(1);

            Assert.AreEqual(result, educationCategories.SingleOrDefault(c => c.Id == 1));
        }
    }
}
