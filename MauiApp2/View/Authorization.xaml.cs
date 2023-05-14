using static MauiApp2.DataBaseRepository;

namespace MauiApp2.View;

public partial class Authorization : ContentPage
{
	public Authorization()
	{
		InitializeComponent();
	}

    private async void LogIn(object sender, EventArgs e)
    {


        //TodoItemDatabase db = new TodoItemDatabase();

        var todoItemDatabase = new DataBaseRepository.TodoItemDatabase();
        var emailData = await todoItemDatabase.GetEmailDataAsync(Email.Text);
        if (emailData != null)
        {
            if (string.Equals(emailData.Password, Password.Text))
            {
                Preferences.Set("UserEmail", Email.Text);
                // —оздаем новую страницу AppShell
                var mainPage = new AppShell();

                // ”станавливаем новую страницу AppShell как главную страницу
                Application.Current.MainPage = mainPage;

                // »спользуем метод PopToRootAsync, чтобы вернутьс€ на первоначальную страницу, прописанную в App
                await mainPage.Navigation.PopToRootAsync();
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("failure", "Invalid Password", "Ok");
            }
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("failure", "Invalid Username", "Ok");
        }
    }

    private async void OnReg(object sender, EventArgs e)
    {
        // —оздаем новую страницу AppShell
        var reg = new Registration();

        // ”станавливаем новую страницу AppShell как главную страницу
        Application.Current.MainPage = reg;

        // »спользуем метод PopToRootAsync, чтобы вернутьс€ на первоначальную страницу, прописанную в App
        await reg.Navigation.PopToRootAsync();
    }
}