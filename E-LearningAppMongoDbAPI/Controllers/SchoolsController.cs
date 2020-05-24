using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_LearningAppMongoDbAPI.Models;
using E_LearningAppMongoDbAPI.Services;

namespace E_LearningAppMongoDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly SchoolService _schoolService;

        public SchoolsController(SchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public ActionResult<List<School>> Get() =>
            _schoolService.Get();

        [HttpGet("{id:length(24)}", Name = "GetSchool")]
        public ActionResult<School> Get(string id)
        {
            var getSchool = _schoolService.Get(id);

            if (getSchool == null)
            {
                return NotFound();
            }

            return getSchool;
        }

        [HttpPost]
        public ActionResult<School> Create(School school)
        {
            _schoolService.Create(school);

            return CreatedAtRoute("GetSchool", new { id = school.Id.ToString() }, school);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, School school)
        {
            var updateSchool = _schoolService.Get(id);

            if (updateSchool == null)
            {
                return NotFound();
            }

            _schoolService.Update(id, school);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var deleteSchool = _schoolService.Get(id);

            if (deleteSchool == null)
            {
                return NotFound();
            }

            _schoolService.Remove(deleteSchool.Id);

            return NoContent();
        }
    }
}