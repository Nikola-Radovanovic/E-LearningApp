using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using E_LearningApp.Models;
using Newtonsoft.Json;

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
    }
}