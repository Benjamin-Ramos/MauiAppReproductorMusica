using MauiAppReproductor.PageModels;

namespace MauiAppReproductor.Pages;

public partial class HomePage : ContentPage
{
    public HomePage(HomePageModel pageModel)
    {
        InitializeComponent();
        BindingContext = pageModel;
        pageModel.MediaPlayer = mediaElement;
    }
}