using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCatalogue.Shared;
using MovieCatalogue.Api.Models;

namespace MovieCatalogue.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MovieController(IMovieRepository movieRepository,
            IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            _movieRepository = movieRepository;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        public IActionResult GetAllMovies()
        {
            return Ok(_movieRepository.GetAllMovies());
        }

        [HttpGet("{id}")]
        public IActionResult GetMovieById(int id)
        {
            return Ok(_movieRepository.GetMovieById(id));
        }

        [HttpGet("long")]
        public IActionResult GetLongMovieList()
        {
            return Ok(_movieRepository.GetLongMovieList());
        }

        [HttpGet("long/{startindex}/{count}")]
        public IActionResult GetTakeLongMovieList(int startIndex, int count)
        {
            return Ok(_movieRepository.GetTakeLongMovieList(startIndex, count));
        }

        [HttpPost]
        public IActionResult CreateMovie([FromBody] Movie movie)
        {
            if (movie == null)
                return BadRequest();

            if (movie.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string currentUrl = _httpContextAccessor.HttpContext.Request.Host.Value;
            var path = $"{_webHostEnvironment.WebRootPath}\\uploads\\{movie.ImageName}";
            var fileStream = System.IO.File.Create(path);
            fileStream.Write(movie.ImageContent, 0, movie.ImageContent.Length);
            fileStream.Close();
            movie.ImageName = $"https://{currentUrl}/uploads/{movie.ImageName}";

            var createdMovie = _movieRepository.AddMovie(movie);

            return Created("movie", createdMovie);
        }

        [HttpPut]
        public IActionResult UpdateMovie([FromBody] Movie movie)
        {
            if (movie == null)
                return BadRequest();

            if (movie.Name == string.Empty)
            {
                ModelState.AddModelError("Name/FirstName", "The name shouldn't be empty");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var personToUpdate = _movieRepository.GetMovieById(movie.Id);

            if (personToUpdate == null)
                return NotFound();

            _movieRepository.UpdateMovie(movie);

            return NoContent(); //success
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            if (id == 0)
                return BadRequest();

            var movieToDelete = _movieRepository.GetMovieById(id);
            if (movieToDelete == null)
                return NotFound();

            _movieRepository.DeleteMovie(id);

            return NoContent();//success
        }
    }
}
