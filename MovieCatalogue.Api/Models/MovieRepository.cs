using System;
using System.Collections.Generic;
using System.Linq;
using MovieCatalogue.Shared;
using MovieCatalogue.Api.Controllers;

namespace MovieCatalogue.Api.Models
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _appDbContext;

        public MovieRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return _appDbContext.Movies;
        }

        public Movie GetMovieById(int Id)
        {
            return _appDbContext.Movies.FirstOrDefault(c => c.Id == Id);
        }

        public IEnumerable<Movie> GetLongMovieList()
        {
            var Movies = new List<Movie>();
            for (int i = 0; i < 1000; i++)
            {
                var movie = new Movie()
                {
                    Id = i,
                    Name = RandomString(10)
                };
                Movie.AddMovie(movie);
            }
            return Movies;
        }

        public IEnumerable<Movie> GetTakeLongMovieList(int request, int count)
        {
            var Movies = new List<Movie>();
            for (int i = 0; i < count; i++)
            {
                var movies = new Movie()
                {
                    Id = i,
                    Name = RandomString(10),
                };
                Movies.Add(movies);
            }
            return Movies;
        }

        private Random random = new Random();

        private string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public Movie AddMovie(Movie movie)
        {
            var addedEntity = _appDbContext.Movies.Add(movie);
            _appDbContext.SaveChanges();
            return addedEntity.Entity;
        }

        public Movie UpdateMovie(Movie movie)
        {
            var foundMovie = _appDbContext.Movies.FirstOrDefault(e => e.Id == movie.Id);

            if (foundMovie != null)
            {
                foundMovie.Id = movie.Id;
                foundMovie.Name = movie.Name;

                _appDbContext.SaveChanges();

                return foundMovie;
            }

            return null;
        }

        public void DeleteMovie(int movieId)
        {
            var foundMovie = _appDbContext.Movies.FirstOrDefault(m => m.Id == movieId);
            if (foundMovie == null) return;

            _appDbContext.Movies.Remove(foundMovie);
            _appDbContext.SaveChanges();
        }
    }
}
