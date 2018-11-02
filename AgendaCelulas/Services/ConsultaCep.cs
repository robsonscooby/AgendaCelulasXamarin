using System;
using System.Net;
using AgendaCelulas.Models;
using Newtonsoft.Json;

namespace AgendaCelulas.Services
{
    public class ConsultaCep
    {
        private static string EnderecoURL = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCep(string cep)
        {
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            WebClient wc = new WebClient();
            string retorno = wc.DownloadString(NovoEnderecoURL);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(retorno);

            if (end.cep == null) return null;

            return end;
        }
    }
}
