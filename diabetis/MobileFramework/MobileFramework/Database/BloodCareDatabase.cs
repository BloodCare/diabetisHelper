using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MobileFramework.ReminderPlugin;

namespace MobileFramework.Database
{
    public class BloodCareDatabase
    {
        SQLiteConnection connection { get; }
        public static string Root { get; set; } = string.Empty;
        public BloodCareDatabase()
        {
            var location = "bloodcaredatabase.db3";
            connection = new SQLiteConnection(System.IO.Path.Combine(Root, location));
            connection.CreateTable<Reminder>();
        }
        internal T GetItem<T>(int id) where T : IBusinessEntity, new()
        {
            return (from i in connection.Table<T>()
                    where i.Id == id
                    select i).FirstOrDefault();
        }

        internal IEnumerable<T> GetItems<T>() where T : IBusinessEntity, new()
        {
            
            return (from i in connection.Table<T>()
                    select i);

        }
        internal int DeleteItem<T>(T item) where T : IBusinessEntity, new()
        {
            return connection.Delete(item);
        }
        internal void SaveItems<T>(IEnumerable<T> items) where T : IBusinessEntity, new()
        {
            connection.BeginTransaction();
            foreach (T item in items)
            {
                SaveItem(item);

            }
            connection.Commit();
        }
        internal int SaveItem<T>(T item) where T : IBusinessEntity
        {
            if (item.Id != 0)
            {
                connection.Update(item);
                return item.Id;
            }
            return connection.Insert(item);
        }

    }
}
