using MauiAppReproductor.PageModels;

namespace MauiAppReproductor.Pages;
public partial class InfoPage : ContentPage
{
    public InfoPage(InfoPageModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}