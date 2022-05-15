using System.Threading.Tasks;
using MovieCatalogue.Shared;

namespace MovieCatalogue.Api.Models
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int Id);
        Movie AddMovie(Movie movie);
        Movie UpdateMovie(Movie movie);
        void DeleteMovie(int Id);
        IEnumerable<Movie> GetLongMovieList();
        IEnumerable<Movie> GetTakeLongMovieList(int request, int count);
    }
}