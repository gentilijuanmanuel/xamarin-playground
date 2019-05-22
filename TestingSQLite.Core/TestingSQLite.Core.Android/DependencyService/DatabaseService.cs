using System;
using System.IO;
using SQLite.Net;
using TestingSQLite.Core.DependencyService;
using TestingSQLite.Core.Droid.DependencyService;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace TestingSQLite.Core.Droid.DependencyService
{
    public class DatabaseService : IDBInterface
    {
        public SQLiteConnection CreateConnection()
        {
            var sqliteFilename = "ExampleDB.db";
            string documentsDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsDirectoryPath, sqliteFilename);

            if(!File.Exists(path))
            {
                using(var binaryReader = new BinaryReader(Android.App.Application.Context.Assets.Open(sqliteFilename)))
                {
                    using(var binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            binaryWriter.Write(buffer, 0, length);
                        }
                    }
                }
            }

            var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, path);

            return connection;
        }

        private void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int length = 256;
            byte[] buffer = new byte[length];
            int bytesRead = readStream.Read(buffer, 0, length);
            while(bytesRead >= 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}
