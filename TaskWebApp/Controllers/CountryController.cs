﻿using TaskEFConsoleApp.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskWebApp.Repositories;

namespace TaskWebApp.Controllers
{
    public class CountryController : Controller
    {
        private CountryRepository _repository;
        public CountryController(CountryRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var countries = _repository.GetAll().ToList();

            return View(countries);
        }
    }
}
