using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using E_LearningApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_LearningApp.Controllers
{
    public class CoursesController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> AllCourses()
        {
            List<Course> coursesList = new List<Course>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44367/api/Courses"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    coursesList = JsonConvert.DeserializeObject<List<Course>>(apiResponse);
                }
            }

            return View(coursesList);
        }
    }
}