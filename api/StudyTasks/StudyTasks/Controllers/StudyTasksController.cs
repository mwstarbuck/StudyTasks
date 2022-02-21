using Microsoft.AspNetCore.Mvc;
using StudyTasks.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudyTasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyTasksController : ControllerBase
    {
        private readonly IProvideStudyTasks _studyTaskProvider;

        public StudyTasksController(IProvideStudyTasks studyTaskProvider)
        {
            _studyTaskProvider = studyTaskProvider;
        }
        // GET: api/<StudyTasksController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var voc = _studyTaskProvider.GetVocabulary();
            return voc;;
        }

        // GET api/<StudyTasksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudyTasksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudyTasksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudyTasksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
