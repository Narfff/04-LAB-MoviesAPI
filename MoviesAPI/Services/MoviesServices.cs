using MoviesAPI.Data;
using MoviesAPI.Views;
namespace MoviesAPI.Services
{
	public class MoviesServices
	{
		private AppDbContext _context;
		public MoviesServices(AppDbContext context)
		{
			_context = context;
		}
		public void AddMovie(MovieVM movieVM)
		{
			var newMovie = new Movie()
			{
				Name = movieVM.Name,
				Genre = movieVM.Genre,
				Year = movieVM.Year,
			};
			_context.Movies.Add(newMovie);
			_context.SaveChanges();
		}
		public List<Movie> GetAllMovies()
		{
			return _context.Movies.ToList();
		}
		public Movie GetMovieById(int id)
		{
			return _context.Movies.FirstOrDefault(x => x.Id == id);
		}
		public Movie UpdateMovieById(int id, MovieVM MovieVM)
		{
			var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
			if (movie != null)
			{
				movie.Name = MovieVM.Name;
				movie.Year = MovieVM.Year;
				movie.Genre = MovieVM.Genre;
				
				_context.SaveChanges();
			}
			return movie;
		}
		public void DeleteMovie(int id)
		{
			var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
			_context.Movies.Remove(movie);
			_context.SaveChanges();
		}
	}
}
