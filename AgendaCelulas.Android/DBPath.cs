using System;
using System.IO;
using AgendaCelulas.BD;
using Xamarin.Forms;

[assembly: Dependency(typeof(AgendaCelulas.Droid.DBPath))]
namespace AgendaCelulas.Droid
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
