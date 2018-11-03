using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AgendaCelulas.Pages
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
            InformacaoSistema();
        }

        public void InformacaoSistema()
        {
            IDictionary<string, object> properties = Application.Current.Properties;
            txtInstalacao.Text = properties["dataInstalacao"] as string;

            if (App._UltimoAcesso != null)
            {
                txtAcesso.Text = App._UltimoAcesso;
            }
            else
            {
               lbAcesso.IsVisible = false;
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            InformacaoSistema();
        }
    }
}
