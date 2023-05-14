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
                // ������� ����� �������� AppShell
                var mainPage = new AppShell();

                // ������������� ����� �������� AppShell ��� ������� ��������
                Application.Current.MainPage = mainPage;

                // ���������� ����� PopToRootAsync, ����� ��������� �� �������������� ��������, ����������� � App
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
        // ������� ����� �������� AppShell
        var reg = new Registration();

        // ������������� ����� �������� AppShell ��� ������� ��������
        Application.Current.MainPage = reg;

        // ���������� ����� PopToRootAsync, ����� ��������� �� �������������� ��������, ����������� � App
        await reg.Navigation.PopToRootAsync();
    }
}