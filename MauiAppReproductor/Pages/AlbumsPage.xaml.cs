using MauiAppReproductor.PageModels;

namespace MauiAppReproductor.Pages;

public partial class AlbumsPage : ContentPage
{
	public AlbumsPage(AlbumsPageModel pageModel)
	{
		InitializeComponent();
        BindingContext = pageModel;
    }
}