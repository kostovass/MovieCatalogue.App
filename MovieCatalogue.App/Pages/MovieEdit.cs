using Microsoft.AspNetCore.Components;
using MovieCatalogue.App.Services;
using MovieCatalogue.Shared;

namespace MovieCatalogue.App.Pages
{
    public partial class MovieEdit
    {
        [Inject]
        public IMovieDataService MovieDataService { get; set; }

        [Parameter]
        public string Id { get; set; }

        public Movie movie { get; set; } = new Movie();
    }
}
