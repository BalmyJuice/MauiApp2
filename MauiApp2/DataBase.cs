using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2
{
    public class DataBase
    {
        //public const string DatabaseFilename = "TodoSQLite.db3";

        //public const SQLite.SQLiteOpenFlags Flags =
        //    // open the database in read/write mode
        //    SQLite.SQLiteOpenFlags.ReadWrite |
        //    // create the database if it doesn't exist
        //    SQLite.SQLiteOpenFlags.Create |
        //    // enable multi-threaded database access
        //    SQLite.SQLiteOpenFlags.SharedCache;

        //public static string DatabasePath =>
        //    Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        public const string DatabaseFilename = "brstudio.db";

        //public static string DatabasePath => Path.Combine( "Assets", DatabaseFilename);      
        //public static string DatabasePath => @"C:\Users\Swerch\source\repos\Aloha_\Aloha_\Assets\"+DatabaseFilename;
        public static string DatabasePath => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), DatabaseFilename);


        public const SQLite.SQLiteOpenFlags Flags = SQLite.SQLiteOpenFlags.ReadWrite | SQLite.SQLiteOpenFlags.Create | SQLite.SQLiteOpenFlags.SharedCache | SQLiteOpenFlags.FullMutex;




        [Table("Users")]
        public class Users
        {
            [PrimaryKey, AutoIncrement, Column("_Id")]
            public int Id { get; set; }

            public string Name { get; set; }
            [Unique]
            public string Email { get; set; }
            public string Password { get; set; }
            public string Age { get; set; }

            [Column("Sketch")]
            public string Sketch { get; set; }

            [Column("Phone")]
            public string Phone { get; set; }
        }
        public class Root
        {
            public List<DataBase> results { get; set; }
        }
    }

}
