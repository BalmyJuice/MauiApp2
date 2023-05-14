using static MauiApp2.DataBaseRepository;

namespace MauiApp2.View;

public partial class Profile : ContentPage
{
    public Profile()
    {
        InitializeComponent();

    }

    protected async override void OnAppearing()
    {

        base.OnAppearing();

        string useremail = Preferences.Get("UserEmail", defaultValue: string.Empty);

        var todoItemDatabase = new DataBaseRepository.TodoItemDatabase();
        var emailData = await todoItemDatabase.GetEmailDataAsync(useremail);

        Age.Text = $"{emailData.Age} лет";
        Name.Text = $"{emailData.Name}";
        Card.Text = $"{emailData.Id}";
    }


    private async void LogOut(object sender, EventArgs e)
    {
        // Создаем новую страницу AppShell
        var reg = new Registration();

        // Устанавливаем новую страницу AppShell как главную страницу
        Application.Current.MainPage = reg;

        // Используем метод PopToRootAsync, чтобы вернуться на первоначальную страницу, прописанную в App
        await reg.Navigation.PopToRootAsync();
    }

    private async void OnSketches(object sender, EventArgs e)
    {

        string useremail = Preferences.Get("UserEmail", defaultValue: string.Empty);
        var todoItemDatabase = new DataBaseRepository.TodoItemDatabase();
        var emailData = await todoItemDatabase.GetEmailDataAsync(useremail);

        string sketches = emailData.Sketch;
        string[] words = new string[] { "empty.png" };
        if (sketches != null)
        {
            words = sketches.Split(' ');
            List<string> myList = new List<string>(words);
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i] == "")
                {
                    myList.RemoveAt(i);
                }
            }
            words = myList.ToArray();
            await Navigation.PushModalAsync(new ProfileGallery(words));
        }
        else
        {
            await Navigation.PushModalAsync(new ProfileGallery(words));
        }
    }
}