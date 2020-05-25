using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using E_LearningApp.Models;
using Newtonsoft.Json;
using E_LearningApp.ViewModels;

namespace E_LearningApp.Controllers
{
    public class SchoolsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> AllSchools()
        {
            SchoolsViewModel viewModel = new SchoolsViewModel
            {
                Schools = new School(),
                Courses = new Course()
            };

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44367/api/Schools"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    viewModel = JsonConvert.DeserializeObject<SchoolsViewModel>(apiResponse);
                }
            }

            //create return View("Schools", viewModel);

            return RedirectToAction();
        }
    }
}