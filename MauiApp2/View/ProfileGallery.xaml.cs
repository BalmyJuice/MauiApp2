namespace MauiApp2.View;

using static MauiApp2.DataBaseRepository;
using static MauiApp2.DataBase;

public partial class ProfileGallery : ContentPage
{
	public IList<Collection> Collections { get; set; }
    string[] sketches;
	public ProfileGallery(string[] words)
	{
		InitializeComponent();
        sketches= words;
	}

    protected override void OnAppearing()
    {

        //TodoItemDatabase db = new TodoItemDatabase();
        Collections = new List<Collection>();
        for (int i = 0; i < sketches.Length; i++)
        {
            Collections.Add(new Collection()
            {
                Image = sketches[i]
            });
        }

        //var result = await db.GetItemsAsync();
        //for (int i = 0;i < result.Count; i++)
        //{
        //    Collections.Add(new Collection()
        //    {
        //        Image = result.Sketch
        //    });
        //}

        BindingContext = this;

        base.OnAppearing();
    }

    private void OnDelete(object sender, EventArgs e)
    {
        ImageButton button = sender as ImageButton;
        if (button != null)
        {

            string source = button.Source.ToString();
            source = source.Substring(source.IndexOf(' ') + 1);
            List<string> sketchesList = sketches.ToList();

            // удаляем заданный элемент
            sketchesList.Remove(source);

            // конвертируем список обратно в массив
            sketches = sketchesList.ToArray();
            Collections = new List<Collection>();
            for (int i = 0; i < sketches.Length; i++)
            {
                Collections.Add(new Collection()
                {
                    Image = sketches[i]
                });
            }
        }

        base.OnAppearing();
    }
}