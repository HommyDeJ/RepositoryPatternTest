using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternTest.Interfaces;
using RepositoryPatternTest.Model;

namespace RepositoryPatternTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
        public CategoriesController(ICategoryRepository repository)
        {
            _repository = repository;
        }

        // GET api/values
        [HttpGet]
        public async Task<Category> Get()
        {
            var category = new Category
            {
                Description = "Primera categoría - jejeje",
                Name = "Soy Pepe"
            };

            await _repository.Create(category);

            var coolestCategory = await _repository.GetCoolestCategory();

            return coolestCategory;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
