using System;
using System.IO;
using AgendaCelulas.BD;
using Xamarin.Forms;

[assembly: Dependency(typeof(AgendaCelulas.iOS.DBPath))]
namespace AgendaCelulas.iOS
{
     public class DBPath : IDatabasePath
        {
            public string GetPath()
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                return Path.Combine(path, "bancoDados.db3");
            }
        }
}
