namespace MauiApp2.View;

public partial class Profile : ContentPage
{
	public Profile()
	{
		InitializeComponent();
	}

    private async void LogOut(object sender, EventArgs e)
    {
        // ������� ����� �������� AppShell
        var reg = new Registration();

        // ������������� ����� �������� AppShell ��� ������� ��������
        Application.Current.MainPage = reg;

        // ���������� ����� PopToRootAsync, ����� ��������� �� �������������� ��������, ����������� � App
        await reg.Navigation.PopToRootAsync();
    }
}