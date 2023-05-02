using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MauiApp2.Services;
using MauiApp2.Model;
using System.Diagnostics;

namespace MauiApp2.ViewModel
{
    public partial class GalleryViewModel:BaseViewModel
    {
        public ObservableCollection<Sketches> Sketch { get; } = new();
        //public Command GetGalleryCommand { get; }

        GalleryService galleryService;
        public GalleryViewModel(GalleryService galleryService)
        {
            this.galleryService = galleryService;
            //GetGalleryCommand = new Command(async () => await GetGalleryAsync());
        }

        public async Task GetGalleryAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                var images = await galleryService.GetGallery();

                if (Sketch.Count != 0)
                    Sketch.Clear();

                foreach (var image in images)
                    Sketch.Add(image);
            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to get quests: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Erorr", ex.Message, "Ok");
            }

            finally { IsBusy = false; }
        }
    }
}
