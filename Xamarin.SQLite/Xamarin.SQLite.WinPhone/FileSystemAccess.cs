using System;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using Xamarin.SQLite.WinPhone;

[assembly: Dependency(typeof(FileSystemAccess))]
namespace Xamarin.SQLite.WinPhone
{
    class FileSystemAccess : IFileSystemAccess
    {
        public void SaveText(string filename, string text)
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            StorageFile storageFile = storageFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting)
                .AsTask().Result;
            FileIO.WriteTextAsync(storageFile, text)
                .AsTask().Wait();
        }
        public string LoadText(string filename)
        {
            try
            {
                StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
                StorageFile storageFile = storageFolder.GetFileAsync(filename)
                    .AsTask().Result;
                string text = FileIO.ReadTextAsync(storageFile)
                    .AsTask().Result;
                return text;
            }
            catch
            {
                return null;
            }
        }
        public string DatabasesFolder
        {
            get
            {
                return ApplicationData.Current.LocalFolder.Path;
            }
        }
    }
}