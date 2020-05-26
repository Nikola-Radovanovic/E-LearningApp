using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using E_LearningApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace E_LearningApp.Controllers
{
    public class SchoolsController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> AllSchools()
        {
            List<School> schoolsList = new List<School>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44367/api/Schools"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    schoolsList = JsonConvert.DeserializeObject<List<School>>(apiResponse);
                }
            }

            return View(schoolsList);
        }
        // CREATE Course
        public ViewResult CreateSchool() => View();
        [HttpPost]
        public async Task<IActionResult> CreateSchool(School school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            School returnedSchool = new School();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(school),Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44367/api/Schools", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    returnedSchool = JsonConvert.DeserializeObject<School>(apiResponse);
                }
            }

            return View(returnedSchool);
        }
    }
}