namespace MauiApp2.View;

public partial class Registration : ContentPage
{
	public Registration()
	{
		InitializeComponent();

	}

    private async void LogIn(object sender, EventArgs e)
    {
        // ������� ����� �������� AppShell
        var mainPage = new AppShell();

        // ������������� ����� �������� AppShell ��� ������� ��������
        Application.Current.MainPage = mainPage;

        // ���������� ����� PopToRootAsync, ����� ��������� �� �������������� ��������, ����������� � App
        await mainPage.Navigation.PopToRootAsync();

        //// ������� ����� ��������, �� ������� ����� �������
        //var mainPage = new MainPage();

        //// ������� NavigationPage � ����� ��������� ������
        //var navigationPage = new NavigationPage(mainPage);

        //// ������������� NavigationPage ��� ������� �������� AppShell
        //Application.Current.MainPage = new AppShell();

        //// ���������� ����� PushAsync, ����� ������� �� ��������, ������������ � NavigationPage
        //await ((Shell)Application.Current.MainPage).Navigation.PushAsync(navigationPage);

    }
}