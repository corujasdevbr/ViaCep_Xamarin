using App_ConsultarCep.Models;
using Newtonsoft.Json;
using System.Net;

namespace App_ConsultarCep.Services
{
    public class ViaCepService
    {
        private static string enderecoViaCep = "https://viacep.com.br/ws/{0}/json/";

        public static EnderecoModel BuscarCep(string cep)
        {
            string urlApi = string.Format(enderecoViaCep, cep);

            WebClient wc = new WebClient();
            string conteudo = wc.DownloadString(urlApi);

            EnderecoModel endereco = JsonConvert.DeserializeObject<EnderecoModel>(conteudo);

            if (endereco.Cep == null) return null;

            return endereco;
        }
    }
}
