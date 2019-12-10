using App_ConsultaCEP.Services.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace App_ConsultaCEP.Services
{
    class ViaCepService
    {
        public static string EnderecoUrl = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco ConsultaCep(string cep)
        {
            string NovoEnderecoUrl = String.Format(EnderecoUrl, cep);

            WebClient wc = new WebClient();
            var conteudo = wc.DownloadString(NovoEnderecoUrl);
            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            if (end.Cep == null)
                return null;

            return end;
        }
    }
}
