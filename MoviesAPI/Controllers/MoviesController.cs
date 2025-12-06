using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Services;
using MoviesAPI.Views;

namespace MoviesAPI.Controllers
{
	public class MoviesController : Controller
	{
		public MoviesServices _movieService { get; set; }
		public MoviesController(MoviesServices movieService)
		{
			_movieService = movieService;
		}
		[HttpPost]
		public IActionResult AddMovie([FromBody] MovieVM movie)
		{
			_movieService.AddMovie(movie);
			return Ok();
		}
		[HttpGet]
		public IActionResult GetAllMovies()
		{
			var allMovies = _movieService.GetAllMovies();
			return Ok(allMovies);
		}
		[HttpGet("id")]
		public IActionResult GetMovieById([FromQuery] int id)
		{
			var movie = _movieService.GetMovieById(id);
			return Ok(movie);
		}
		[HttpPut("id")]
		public IActionResult UpdateMovieById([FromQuery] int id,
		[FromBody] MovieVM movieVM)
		{
			var updatedMovie = _movieService.UpdateMovieById(id, movieVM);
			return Ok(updatedMovie);
		}
		[HttpDelete("id")]
		public IActionResult DeleteMovie([FromQuery] int id)
		{
			_movieService.DeleteMovie(id);
			return Ok();
		}
	}
}
