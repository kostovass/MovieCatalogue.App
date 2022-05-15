using Microsoft.AspNetCore.Components;
using MovieCatalogue.App.Services;
using MovieCatalogue.Shared;

namespace MovieCatalogue.App.Pages
{
    public partial class MovieOverview
    {
		public IEnumerable<Movie> Movies{ get; set; }
        [Inject]
        public IMovieDataService MovieDataService { get; set; }

		//[Inject]
		//public HttpClient HttpClient { get; set; }
		protected async override Task OnInitializedAsync()
        {
            Movies = (await MovieDataService.GetAllMovies()).ToList();

        }

        
	}
}
