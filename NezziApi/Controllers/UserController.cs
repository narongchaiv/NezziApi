using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using NezziApi.Mapping.Dtos;
using NezziApi.Interface;
using NezziApi.Mapping.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NezziApi.Controllers
{
    [Route("/api/user")]
    public class UserController : Controller
    {
        //private readonly IMapper mapper;
        private readonly IUserRepository repository;
        //private readonly IUnitOfWork unitOfWork;

        public UserController(IUserRepository repository)
        
        {
            this.repository = repository;
        }
        //[HttpGet]
        //public async Task<IEnumerable<EmployeeDto>> GetEmployee()
        //{
        //    var employees = await repository.GetEmployee();
        //    return employees;
        //}

        [HttpGet]
        public IEnumerable<UserDto> GetUser()
        {
            var employees = repository.GetUser();
            return employees;
        }

        [HttpGet("getall")]
        public IEnumerable<User> GetEmployeeAllDetail()
        {
            var employees = repository.GetUserAllDetail();
            return employees;
        }
        //// GET: Employee
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: Employee/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Employee/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Employee/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Employee/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Employee/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Employee/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Employee/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}