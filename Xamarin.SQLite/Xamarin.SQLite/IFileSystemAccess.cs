using System;

namespace Xamarin.SQLite
{
    public interface IFileSystemAccess
    {
        void SaveText(string fileName, string text);
        string LoadText(string fileName);
        string DatabasesFolder { get; }
    }
}
