using Microsoft.AspNetCore.Components;
using MovieCatalogue.App.Services;
using MovieCatalogue.Shared;

namespace MovieCatalogue.App.Components
{
    public partial class AddMovieDialog
    {
        public Movie movie { get; set; } =
           new Movie { Id = 1 };

        [Inject]
        public IMovieDataService MovieDataService { get; set; }

        public bool ShowDialog { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        public void Show()
        {
            ResetDialog();
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        private void ResetDialog()
        {
            Movie = new Movie { Id = 1 };
        }

        protected async Task HandleValidSubmit()
        {
            await MovieDataService.AddMovie(Movie);
            ShowDialog = false;

            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}
