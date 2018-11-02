using System;
using AgendaCelulas.Models;
using SQLite;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;

namespace AgendaCelulas.BD
{
    public class AcessoBanco
    {
        static SQLiteConnection _conexao;

        public AcessoBanco()
        {
            if (_conexao == null)
            {
                string path = DependencyService.Get<IDatabasePath>().GetPath();
                _conexao = new SQLiteConnection(path);
                _conexao.CreateTable<Celula>();
            }
        }

        public List<Celula> BuscarTodas()
        {
            return _conexao.Table<Celula>().ToList();
        }

        public Celula Pesquisar(string nome)
        {
            return _conexao.Table<Celula>().Where(a => a.Nome.Contains(nome)).FirstOrDefault();
        }

        public Celula Buscar(int id)
        {
            return _conexao.Table<Celula>().Where(a=>a.id==id).FirstOrDefault();
        }

        public void Cadastrar(Celula celula)
        {
            _conexao.Insert(celula);
        }

        public void atualizar(Celula celula)
        {
            _conexao.Update(celula);
        }

        public void Excluir(Celula celula)
        {
            _conexao.Delete(celula);
        }
    }
}
