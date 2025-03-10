using MauiAppReproductor.Models;
using MauiAppReproductor.PageModels;

namespace MauiAppReproductor.Pages;

public partial class AlbumDetailPage : ContentPage
{
	public AlbumDetailPage(AlbumDetailPageModel pageModel, Album album)
	{
		InitializeComponent();
        BindingContext = pageModel;
		pageModel.Initialize(album);
    }
}