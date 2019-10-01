using App1.Droid.Providers;
using App1.Infra;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DroidSQLiteDataBasePathProvider))]
namespace App1.Droid.Providers
{
    sealed class DroidSQLiteDataBasePathProvider : ISQLiteDataBasePathProvider
    {
        public string GetDataBasePath(string nomeBase) => Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal),  nomeBase+".db3");
         
    }
}