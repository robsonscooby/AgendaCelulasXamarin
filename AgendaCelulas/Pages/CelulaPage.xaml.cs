using System;
using System.Collections.Generic;
using AgendaCelulas.BD;
using AgendaCelulas.Models;
using AgendaCelulas.Services;
using Xamarin.Forms;

namespace AgendaCelulas.Pages
{
    public partial class CelulaPage : ContentPage
    {
        Celula celula;

        public CelulaPage(Celula c = null)
        {
            InitializeComponent();

            if(c != null)
            {
                lbTitulo.Text = "Alterar Celula";
                btSalvar.Text = "Salvar";
                celula = new Celula();
                celula = c;
                txtNome.Text = celula.Nome;
                txtCep.Text = celula.Cep;
                txtEndereco.Text = celula.Endereco;
                txtDescricao.Text = celula.Descricao;
            }
            else
            {
                lbTitulo.Text = "Cadastar Celula";
                btSalvar.Text = "Cadastar";
            }
        }

        private void Salvar(Object sender, EventArgs eventArgs)
        {
            AcessoBanco acessoBanco = new AcessoBanco();
            if (celula == null)
            {
                celula = new Celula
                {
                    Nome = txtNome.Text,
                    Cep = txtCep.Text,
                    Endereco = txtEndereco.Text,
                    Descricao = txtDescricao.Text
                };
                acessoBanco.Cadastrar(celula);
            }
            else{
                celula.Nome = txtNome.Text;
                celula.Cep = txtCep.Text;
                celula.Endereco = txtEndereco.Text;
                celula.Descricao = txtDescricao.Text;
                acessoBanco.atualizar(celula);
            }

            App.Current.MainPage = new MainPage();
        }

        private void BuscarCep(object sender, EventArgs e)
        {
            string cep = txtCep.Text.Trim();
            if (isValidCep(cep))
            {
                try
                {
                    Endereco end = ConsultaCep.BuscarEnderecoViaCep(cep);

                    if (end != null)
                    {
                        txtEndereco.Text = string.Format("{0},{1},{2},{3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("Error", "Endereço não encontrado!", "OK");
                    }


                }
                catch (Exception ex)
                {
                    DisplayAlert("Error", ex.Message, "OK");
                }
            }
        }

        private bool isValidCep(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O cep deve conter 8 caracteres.", "OK");

                valido = false;
            }

            int NovoCep = 0;
            if (!int.TryParse(cep, out NovoCep))
            {
                DisplayAlert("ERRO", "CEP inválido! O cep deve conter apenas números.", "OK");
                valido = false;
            }

            return valido;
        }
    }
}
