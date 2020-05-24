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
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<Category>> Get() =>
            _categoryService.Get();

        [HttpGet("{id:length(24)}", Name = "GetCategory")]
        public ActionResult<Category> Get(string id)
        {
            var getCategory = _categoryService.Get(id);

            if (getCategory == null)
            {
                return NotFound();
            }

            return getCategory;
        }

        [HttpPost]
        public ActionResult<Category> Create(Category category)
        {
            _categoryService.Create(category);

            return CreatedAtRoute("GetCategory", new { id = category.Id.ToString() }, category);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Category category)
        {
            var updateCategory = _categoryService.Get(id);

            if (updateCategory == null)
            {
                return NotFound();
            }

            _categoryService.Update(id, category);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var deleteCategory = _categoryService.Get(id);

            if (deleteCategory == null)
            {
                return NotFound();
            }

            _categoryService.Remove(deleteCategory.Id);

            return NoContent();
        }
    }
}