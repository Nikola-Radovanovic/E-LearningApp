using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using E_LearningApp.Models;
using Newtonsoft.Json;

namespace E_LearningApp.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> AllUsers()
        {
            List<User> usersList = new List<User>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44367/api/Users"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    usersList = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                }
            }

            return View("Index", usersList);
        }
    }
}