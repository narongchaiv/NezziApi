using NUnit.Framework;
using Moq;
using AutoMapper;
using System.Collections.Generic;
using NezziApi.Mapping.Dtos;
using NezziApi.Mapping.Model;
using NezziApi.Interface;
using NezziApi.Controllers;

namespace GSBWayPointNUnit.UnitTests
{
    [TestFixture]
    public class TestUserController
    {
        private Mock<IUserRepository> _repository;
        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IUserRepository>();
        }

        [Test]
        public void GetEmployee_GetEmployeeCommonCondition_ReturnEmployeeDtoList()
        {
            var employeeDto = new UserDto
            {
                Id = 2,
                UserId="11",
                Fullname="Narongchai Viriyarojanakul",
                Username = "narongchai.v"
            };

            var employeeDtos = new List<UserDto>();

            employeeDtos.Add(employeeDto);

            _repository.Setup(r => r.GetUser()).Returns(employeeDtos);

            var controller = new UserController(_repository.Object);

            var result = controller.GetUser();

            Assert.AreEqual(result, employeeDtos);
        }

        [Test]
        public void GetEmployeeAllDetail_GetEmployeeAllCommonCondition_ReturnEmployeeList()
        {
            var employee = new User
            {
                Id = 1,
                UserId = "11",
                Name = "Narongchai",
                Surname = "Viriyarojanakul",
                Username = "narongchai.v"
            };

            var employees = new List<User>();

            _repository.Setup(r => r.GetUserAllDetail()).Returns(employees);

            var controller = new UserController(_repository.Object);

            var result = controller.GetEmployeeAllDetail();

            Assert.AreEqual(result, employees);
        }
    }
}