using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using E_LearningApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace E_LearningApp.Controllers
{
    public class CoursesController : Controller
    {
        // GET Courses
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

        // CREATE Course
        public ViewResult CreateCourse() => View();
        [HttpPost]
        public async Task<IActionResult> CreateCourse(Course course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            Course returnedCourse = new Course();

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44367/api/Courses", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    returnedCourse = JsonConvert.DeserializeObject<Course>(apiResponse);
                }
            }

            return View(returnedCourse);
        }

    }
}