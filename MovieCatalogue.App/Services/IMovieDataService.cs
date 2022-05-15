using MovieCatalogue.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MovieCatalogue.App.Services
{
    public interface IMovieDataService
    {
        Task<IEnumerable<Movie>> GetAllMovies();
        Task<Movie> GetMovieDetails(int Id);
        Task<Movie> AddMovie(Movie movie);
        Task UpdateMovie(Movie movie);
        Task DeleteMovie(Movie movie);
    }
}
