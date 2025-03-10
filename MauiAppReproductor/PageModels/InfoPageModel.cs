using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Input;
using Microsoft.Maui.ApplicationModel;

namespace MauiAppReproductor.PageModels
{
    public partial class InfoPageModel : ObservableObject
    {
        [ObservableProperty]
        private string description = "Soy Benjamin Ramos, desarrollador de la aplicación Sonora. Actualmente estoy estudiando Desarrollo de Aplicaciones Multiplataforma en el IES Luis Vives.";

        [ObservableProperty]
        private string gitHubLink = "https://github.com/Benjamin-Ramos";

        [ObservableProperty]
        private string appDescription = "Esta aplicación se llama 'Sonora'. Está diseñada para ofrecer una experiencia de reproducción de música en múltiples plataformas.";

        public ICommand OpenGitHubCommand { get; }

        public InfoPageModel()
        {
            OpenGitHubCommand = new RelayCommand(OpenGitHub);
        }

        private async void OpenGitHub()
        {
            if (Uri.IsWellFormedUriString(GitHubLink, UriKind.Absolute))
            {
                await Launcher.OpenAsync(GitHubLink);
            }
        }
    }
}
