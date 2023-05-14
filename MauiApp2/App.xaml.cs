namespace MauiApp2;

public partial class App : Application
{

    //public const string DATABASE_NAME = "DataBase.db";
    //public static DataBaseRepository database;

    //public static DataBaseRepository Database
    //{
    //    get
    //    {
    //        if (database == null)
    //        {
    //            string dbPath = Path.Combine(
    //                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME);
    //            database = new DataBaseRepository(dbPath);
    //        }

    //        //if (database == null)
    //        //{
    //        //    database = new DataBaseRepository(
    //        //        Path.Combine(
    //        //            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DATABASE_NAME));
    //        //}
    //        return database;
    //    }
    //}
    public App()
	{
		InitializeComponent();

		MainPage = new Registration();
    }

    protected override async void OnStart()
    {
        base.OnStart();

        await Task.Run(async () =>
        {
            var todoItemDatabase = new DataBaseRepository.TodoItemDatabase();
            await todoItemDatabase.Init();
        });

        }
        //protected override void OnSleep()
        //{
        //}
        //protected override void OnResume()
        //{
        //}
    }
