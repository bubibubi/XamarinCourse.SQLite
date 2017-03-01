using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.SQLite.iOS;

[assembly:Dependency(typeof(FileSystemAccess))]
namespace Xamarin.SQLite.iOS
{
    class FileSystemAccess : IFileSystemAccess
    {
        public void SaveText(string filename, string text)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            File.WriteAllText(filePath, text);
        }

        public string LoadText(string filename)
        {
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var filePath = Path.Combine(documentsPath, filename);
            return !File.Exists(filePath) ? null : File.ReadAllText(filePath);
        }

        public string DatabasesFolder
        {
            get
            {
                string libraryFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                    "..",
                    "Library");
                if (!Directory.Exists(libraryFolder))
                    Directory.CreateDirectory(libraryFolder);
                return libraryFolder;
            }
        }
    }
}