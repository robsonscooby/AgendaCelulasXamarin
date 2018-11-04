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
        private const string Favorite = "favorite";
        private const string FavoriteT = "favoriteT";
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

        public async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            Celula cel = mi.CommandParameter as Celula;

            var result = await DisplayAlert("Notificação", "Deseja excluir Celula: " + cel.Nome, "Ok", "Cancelar");
            if(result)
            {
                acessoBanco.Excluir(cel);
                ConsultarCelulas();
            }
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
            ListaCelulas.ItemsSource = Lista.Where(a=> a.Nome.ToLower().Contains(e.NewTextValue.ToLower())).ToList();
        }

        public void Favorito(object sender, EventArgs e)
        {
            var mi = ((Button)sender);
            Celula cel = mi.CommandParameter as Celula;
            if (cel.Favorito.Equals(Favorite))
            {
                cel.Favorito = FavoriteT;
            }
            else 
            {
                cel.Favorito = Favorite;
            }
            acessoBanco.atualizar(cel);
            ConsultarCelulas();
        }

        public void FiltroFavorito(object sender, ToggledEventArgs toggled)
        {
            if(toggled.Value)
            {
                ListaCelulas.ItemsSource = Lista.Where(a => a.Favorito.Equals(FavoriteT)).ToList();
            }
            else{
                ListaCelulas.ItemsSource = Lista;
            }
        }
    }
}
