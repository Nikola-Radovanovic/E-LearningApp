using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using E_LearningAppMongoDbAPI.Models;
using E_LearningAppMongoDbAPI.Services;

namespace E_LearningAppMongoDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : Controller
    {
        private readonly CourseService _courseService;

        public CoursesController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public ActionResult<List<Course>> Get() =>
            _courseService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCourse")]
        public ActionResult<Course> Get(string id)
        {
            var getCourse = _courseService.Get(id);

            if (getCourse == null)
            {
                return NotFound();
            }

            return getCourse;
        }

        [HttpPost]
        public ActionResult<Course> Create(Course course)
        {
            _courseService.Create(course);

            return CreatedAtRoute("GetCourse", new { id = course.Id.ToString() }, course);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update([FromForm] string id, Course course)
        {
            var updateCourse = _courseService.Get(id);

            if (updateCourse == null)
            {
                return NotFound();
            }

            _courseService.Update(id, course);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var deleteCourse = _courseService.Get(id);

            if (deleteCourse == null)
            {
                return NotFound();
            }

            _courseService.Remove(deleteCourse.Id);

            return NoContent();
        }
    }
}