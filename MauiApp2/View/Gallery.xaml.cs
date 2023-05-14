using MauiApp2.ViewModel;
using SQLite;
using static MauiApp2.DataBaseRepository;
using static MauiApp2.DataBase;


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

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Sketches selectedModel)
        {
            // Выбран элемент MyModel, выполнить нужные действия
            string message = $"Выбран элемент {selectedModel.Id}";
            DisplayAlert("Сообщение", message, "OK");
        }
    }

    public static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);
    private async void qwe(object sender, EventArgs e)
    {
        string useremail = Preferences.Get("UserEmail", defaultValue: string.Empty);
        var todoItemDatabase = new DataBaseRepository.TodoItemDatabase();
        var emailData = await todoItemDatabase.GetEmailDataAsync(useremail);
        string sketch = "";
        List<string> items = new List<string>();

        ImageButton button = sender as ImageButton;
        if (button != null)
        {

            string sk = String.Concat(sketch, emailData.Sketch);
            string source = button.Source.ToString();
            source = source.Substring(source.IndexOf(' ') + 1);
            if (sk.Contains(source))
            {
                await DisplayAlert("Оповещение", "Эскиз уже добавлен", "OK");
            }
            else
            {
                sk = String.Concat(sk, " ", source);
                //await DisplayAlert("Сообщение", $"Источник изображения: {sk}", "OK");
                using (var connection = new SQLiteConnection(DatabasePath))
                {
                    //connection.Open();
                    //sk = null;
                    string sql = "UPDATE Users SET Sketch = @sk WHERE Email = @useremail";
                    SQLiteCommand command = connection.CreateCommand(sql, sk, useremail);
                    command.ExecuteNonQuery();
                }
            }
            

            //await DisplayAlert("Сообщение", $"Источник изображения: {sk}", "OK");
        }
        TodoItemDatabase db = new TodoItemDatabase();
        var result = await db.GetItemsAsync();
    }
}