using MovieCatalogue.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieCatalogue.App.Services
{
    public class MovieDataService : IMovieDataService
    {
        private readonly HttpClient _httpClient;
        public MovieDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<Movie> AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Movie>>
                    (await _httpClient.GetStreamAsync($"api/movie"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Movie> GetMovieDetails(int Id)
        {
            return await JsonSerializer.DeserializeAsync<Movie>
                (await _httpClient.GetStreamAsync($"api/movie/{Id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public Task UpdateMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
