using System.Security.AccessControl;

namespace MauiApp2.View;

public partial class Request : ContentPage
{
	public Request()
	{
		InitializeComponent();
	}

    void OnMasters(object sender, EventArgs args)
    {
        Navigation.PushModalAsync(new Masters());
    }

    void OnDate(object sender, EventArgs args)
    {
        Navigation.PushModalAsync(new Date());
    }

    void OnSketches(object sender, EventArgs args)
    {
        Navigation.PushModalAsync(new ChooseSketch());
    }
}