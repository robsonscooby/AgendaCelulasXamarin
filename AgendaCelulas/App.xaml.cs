using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AgendaCelulas
{
    public partial class App : Application
    {
        public static string _UltimoAcesso;
        public App()
        {
            InitializeComponent();
            InformacaoSistema();

            MainPage = new MainPage();
        }

        public void InformacaoSistema()
        {
            string Key = "dataInstalacao";
            IDictionary<string, object> properties = Application.Current.Properties;
            if (properties.ContainsKey(Key))
            {
                Key = "UltimoAcesso";
                if (properties.ContainsKey(Key))
                {
                    _UltimoAcesso = properties[Key] as string;
                }
            }
            Application.Current.Properties[Key] = string.Format("{0} as {1}", DateTime.Now.ToString("D"), DateTime.Now.ToString("T"));
            Application.Current.SavePropertiesAsync();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
