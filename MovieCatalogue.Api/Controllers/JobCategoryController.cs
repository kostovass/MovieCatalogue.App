using Microsoft.AspNetCore.Mvc;
using MovieCatalogue.Api.Models;
using MovieCatalogue.Shared;

namespace MovieCatalogue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobCategoryController
    {
        private readonly IJobCategoryRepository _jobCategoryRepository;

        public JobCategoryController(IJobCategoryRepository jobCategoryRepository)
        {
            _jobCategoryRepository = jobCategoryRepository;
        }


        // GET: api/<controller>
        [HttpGet]
        public IActionResult GetJobCategories()
        {
            return Ok(_jobCategoryRepository.GetAllJobCategories());
        }

        private IActionResult Ok(IEnumerable<JobCategory> enumerable)
        {
            throw new NotImplementedException();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult GetJobCategoryById(int id)
        {
            return Ok(_jobCategoryRepository.GetJobCategoryById(id));
        }

        private IActionResult Ok(JobCategory jobCategory)
        {
            throw new NotImplementedException();
        }
    }
}
