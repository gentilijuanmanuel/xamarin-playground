using System;
using System.IO;
using Foundation;
using SQLite.Net;
using TestingSQLite.Core.DependencyService;
using TestingSQLite.Core.iOS.DependencyService;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace TestingSQLite.Core.iOS.DependencyService
{
    public class DatabaseService : IDBInterface
    {
        public SQLiteConnection CreateConnection()
        {
            var sqliteFilename = "Employee.db";

            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if(!Directory.Exists(libFolder))
                Directory.CreateDirectory(libFolder);

            string path = Path.Combine(libFolder, sqliteFilename);

            if(!File.Exists(path))
            {
                var existingDb = NSBundle.MainBundle.PathForResource("ExampleDB", "db");
                File.Copy(existingDb, path);
            }

            var iOSPlatform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLiteConnection(iOSPlatform, path);

            return connection;
        }
    }
}
