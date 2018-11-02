using System;
using System.Linq;
using System.Collections.Generic;
using AgendaCelulas.BD;
using AgendaCelulas.Models;
using Xamarin.Forms;

namespace AgendaCelulas.Pages
{
    public partial class HomePage : ContentPage
    {
        private AcessoBanco acessoBanco;
        public List<Celula> Lista { get; set; }

        public HomePage()
        {
            InitializeComponent();

            acessoBanco = new AcessoBanco();
            ConsultarCelulas();
        }

        private void ConsultarCelulas()
        {
            Lista = acessoBanco.BuscarTodas();
            ListaCelulas.ItemsSource = Lista;
        }

        private void OpenPageCelula(Object sender, EventArgs eventArgs)
        {
            Navigation.PushAsync(new CelulaPage());
        }

        public void OnMore(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Navigation.PushAsync(new DetalhePage(mi.CommandParameter as Celula));
        }

        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Celula cel = mi.CommandParameter as Celula;
            DisplayAlert("Notificação", "Deseja excluir Celula: " + cel.Nome, "Excluir", "Cancelar");
            acessoBanco.Excluir(cel);
            ConsultarCelulas();
        }

        public void OnUpdate(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Navigation.PushAsync(new CelulaPage(mi.CommandParameter as Celula));
        }

        public void SaveCel(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CelulaPage());
        }

        public void Pesquisar(object sender, TextChangedEventArgs e)
        {
            ListaCelulas.ItemsSource = Lista.Where(a=> a.Nome.Contains(e.NewTextValue)).ToList();
        }
    }
}
