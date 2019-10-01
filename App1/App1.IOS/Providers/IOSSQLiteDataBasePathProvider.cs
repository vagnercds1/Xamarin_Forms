using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using App1.Infra;
using Blank.Providers;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(IOSSQLiteDataBasePathProvider))]
namespace Blank.Providers
{ 
    sealed class IOSSQLiteDataBasePathProvider : ISQLiteDataBasePathProvider
    {
        public IOSSQLiteDataBasePathProvider()
        {

        } 
         
        public string GetDataBasePath(string nomeBase)
        {
            var dataBaseFolderPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "...", "Library");

            if (!Directory.Exists(dataBaseFolderPath))
                Directory.CreateDirectory(dataBaseFolderPath);

            return Path.Combine(dataBaseFolderPath, nomeBase+".db3");
        }
    }
}