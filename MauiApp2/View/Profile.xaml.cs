namespace MauiApp2.View;

public partial class Profile : ContentPage
{
	public Profile()
	{
		InitializeComponent();
	}

    private async void LogOut(object sender, EventArgs e)
    {
        // —оздаем новую страницу AppShell
        var reg = new Registration();

        // ”станавливаем новую страницу AppShell как главную страницу
        Application.Current.MainPage = reg;

        // »спользуем метод PopToRootAsync, чтобы вернутьс€ на первоначальную страницу, прописанную в App
        await reg.Navigation.PopToRootAsync();
    }
}