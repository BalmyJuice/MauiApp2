namespace MauiApp2.View;

public partial class Registration : ContentPage
{
	public Registration()
	{
		InitializeComponent();

	}

    private async void LogIn(object sender, EventArgs e)
    {
        // Создаем новую страницу AppShell
        var mainPage = new AppShell();

        // Устанавливаем новую страницу AppShell как главную страницу
        Application.Current.MainPage = mainPage;

        // Используем метод PopToRootAsync, чтобы вернуться на первоначальную страницу, прописанную в App
        await mainPage.Navigation.PopToRootAsync();

        //// Создаем новую страницу, на которую нужно перейти
        //var mainPage = new MainPage();

        //// Создаем NavigationPage с новой страницей внутри
        //var navigationPage = new NavigationPage(mainPage);

        //// Устанавливаем NavigationPage как главную страницу AppShell
        //Application.Current.MainPage = new AppShell();

        //// Используем метод PushAsync, чтобы перейти на страницу, содержащуюся в NavigationPage
        //await ((Shell)Application.Current.MainPage).Navigation.PushAsync(navigationPage);

    }
}