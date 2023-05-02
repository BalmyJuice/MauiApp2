using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using MauiApp2.Model;
using Newtonsoft.Json;

namespace MauiApp2.Services
{
    public class GalleryService
    {
        List<Sketches> galleryList = new();

        public async Task<List<Sketches>> GetGallery()
        {
            try
            {
                string path = "Gallery.json";
                var stream = await FileSystem.OpenAppPackageFileAsync(path);
                var strm = new StreamReader(stream);
                string response = await strm.ReadToEndAsync();

                galleryList = JsonConvert.DeserializeObject<List<Sketches>>(response);

                return galleryList;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to read json: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Erorr", ex.Message, "Ok");
                return null;
            }
        }
    }
}
