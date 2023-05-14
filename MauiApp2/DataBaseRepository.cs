//using CloudKit;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MauiApp2.DataBase;

namespace MauiApp2
{
    public class DataBaseRepository
    {

        public class TodoItemDatabase
        {
            SQLiteAsyncConnection Database = new SQLiteAsyncConnection(MauiApp2.DataBase.DatabasePath, Flags);

            public TodoItemDatabase()
            {
            }

            public async Task Init()
            {
                //if (Database == null)
                //    return;


                //Database = Database.DatabasePath =="" ? Database: new SQLiteAsyncConnection(Database.DatabasePath, Flags);

                //if(Database == null)
                //{
                //    Database = new SQLiteAsyncConnection(Database.DatabasePath);
                //}
                try
                {
                    string path = MauiApp2.DataBase.DatabasePath;
                    var result = await this.Database.CreateTableAsync<Users>();
                }
                catch (Exception ex)
                {
                    var result = ex.Message;

                }



                //var a = Database.DatabasePath;
                //var result = await Database.CreateTableAsync<Tour>();
            }
            public async Task<List<Users>> GetItemsAsync()
            {
                //await Init();


                return await Database.Table<Users>().ToListAsync();
            }


            public async Task<Users> GetItemAsync(int id)
            {
                //await Init();
                return await Database.Table<Users>().Where(i => i.Id == id).FirstOrDefaultAsync();
            }

            public async Task<int> SaveItemAsync(Users item)
            {
                //await Init();
                if (item.Id != 0)
                    return await Database.UpdateAsync(item);
                else
                    return await Database.InsertAsync(item);
            }

            public async Task<int> DeleteItemAsync(Users item)
            {
                await Init();
                return await Database.DeleteAsync(item);
            }

            public Task<Users> GetLoginDataAsync(string userName)
            {
                return Database.Table<Users>()
                                .Where(i => i.Name == userName)
                                .FirstOrDefaultAsync();
            }

            public Task<Users> GetEmailDataAsync(string userEmail)
            {
                return Database.Table<Users>()
                                .Where(i => i.Email == userEmail)
                                .FirstOrDefaultAsync();
            }
        }
        //SQLiteConnection database;
        //public DataBaseRepository(string databasePath)
        //{
        //    database = new SQLiteConnection(databasePath);
        //    database.CreateTable<DataBase>();
        //}
        //public IEnumerable<DataBase> GetItems()
        //{
        //    return database.Table<DataBase>().ToList();
        //}
        //public DataBase GetItem(int id)
        //{
        //    return database.Get<DataBase>(id);
        //}
        //public int DeleteItem(int id)
        //{
        //    return database.Delete<DataBase>(id);
        //}
        //public int SaveItem(DataBase item)
        //{
        //    if (item.Id != 0)
        //    {
        //        database.Update(item);
        //        return item.Id;
        //    }
        //    else
        //    {
        //        return database.Insert(item);
        //    }
        //}
    }
}
