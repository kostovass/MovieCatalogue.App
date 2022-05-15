using Microsoft.AspNetCore.Components;
using MovieCatalogue.Shared;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieCatalogue.App.Services;

namespace MovieCatalogue.App.Pages
{
    public partial class MovieDetail
    {
        [Parameter]
		public string Id { get; set; }
		public Movie Movie { get; set; } = new Movie();
		public IEnumerable<Movie> Movies { get; set; }

		[Inject]
		public IMovieDataService MovieDataService { get; set; }
		protected async override Task OnInitializedAsync()
		{
			Movies = (IEnumerable<Movie>)await MovieDataService.GetMovieDetails(int.Parse(Id));
		}

	}
}
