using System;
using System.IO;
using SQLite;
using Xamarin.Forms;

namespace Xamarin.SQLite.Repository
{
    static class ConnectionFatory
    {
        public static SQLiteConnection CreateConnection()
        {
            string databasesFolder = DependencyService.Get<IFileSystemAccess>().DatabasesFolder;
            
            string databasePath = Path.Combine(databasesFolder, "Data.db3");
            return new SQLiteConnection(databasePath);
        }
    }
}
