﻿using System;
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

        public ViewResult GetCourse() => View();
        [HttpGet]
        public async Task<IActionResult> GetCourse(string id)
        {
            Course course = new Course();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44367/api/Courses/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    course = JsonConvert.DeserializeObject<Course>(apiResponse);
                }
            }
            return View(course);
        }

        // CREATE Course
        public ViewResult CreateCourse() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
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
            return RedirectToAction("AllCourses", "Courses", returnedCourse);
        }


        //UPDATE Course
        public async Task<IActionResult> UpdateCourse(string id)
        {
            Course course = new Course();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44367/api/Courses/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    course = JsonConvert.DeserializeObject<Course>(apiResponse);
                }
            }
            return View(course);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateCourse(Course course)
        {
            Course returnedCourse = new Course();

            using (var httpClient = new HttpClient())
            {
                var content = new MultipartFormDataContent
                {
                    { new StringContent(course.Id.ToString()), "Id" },
                    { new StringContent(course.Name), "Name" },
                    { new StringContent(course.Link), "Link" },
                    { new StringContent(course.Description), "Description" }
                };

                using (var response = await httpClient.PutAsync("https://localhost:44367/api/Courses/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    returnedCourse = JsonConvert.DeserializeObject<Course>(apiResponse);
                }
            }
            return RedirectToAction("AllCourses", "Courses", returnedCourse);
        }



        //public async Task<IActionResult> UpdateCourse(string id)
        //{
        //    Course course = new Course();

        //    using (var httpClient = new HttpClient())
        //    {
        //        using (var response = await httpClient.GetAsync("https://localhost:44367/api/Courses" + id))
        //        {
        //            string apiResponse = await response.Content.ReadAsStringAsync();
        //            course = JsonConvert.DeserializeObject<Course>(apiResponse);
        //        }
        //    }
        //    return View(course);
        //}

        //[HttpPut]
        //public async Task<IActionResult> UpdateCourse(string id, Course course)
        //{
        //    using (var httpClient = new HttpClient())
        //    {
        //        var request = new HttpRequestMessage
        //        {
        //            RequestUri = new Uri("https://localhost:44367/api/Courses" + id),
        //            Method = new HttpMethod("Patch"),
        //            Content = new StringContent("[{ \"op\": \"replace\", \"path\": \"Name\", \"value\": \"" + course.Name +
        //            "\"},{ \"op\": \"replace\", \"path\":\"Link\", \"value\": \"" +
        //            course.Link + "\"}]", Encoding.UTF8, "application/json")
        //        };

        //        var response = await httpClient.SendAsync(request);
        //    }
        //    return RedirectToAction("AllCourses");
        //}


        //DELETE Course
        public ViewResult DeleteCourse() => View();
        [HttpDelete]
        public async Task<IActionResult> DeleteCourse(string id)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44367/api/Courses/" + id ))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("AllCourses", "Courses");
        }
    }
}