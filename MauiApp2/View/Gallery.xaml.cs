using MauiApp2.ViewModel;

namespace MauiApp2.View;
[XamlCompilation(XamlCompilationOptions.Compile)]

public partial class Gallery : ContentPage
{
	public Gallery(GalleryViewModel galleryViewModel)
	{
		InitializeComponent();
		BindingContext = galleryViewModel;
        _ = galleryViewModel.GetGalleryAsync();
    }
}