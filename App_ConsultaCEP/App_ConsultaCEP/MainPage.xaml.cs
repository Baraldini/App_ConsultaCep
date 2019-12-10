using App_ConsultaCEP.Services;
using App_ConsultaCEP.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App_ConsultaCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs e)
        {
            string cep = CEP.Text.Trim();
            if (isValidCep(cep))
            {
                try
                {
                    Endereco end = ViaCepService.ConsultaCep(cep);

                    if (end != null)
                    {
                        RESULTADO.Text = String.Format("Rua: {0} \n Bairro: {1} \n Cidade {2} \n UF: {3}", end.Logradouro, end.Bairro, end.Localidade, end.Uf);
                    } else
                    {
                        DisplayAlert("ERRO CRÍTICO", "O endereço não foi encontrado para o CEP informado" + cep, "Fechar");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "Fechar");
                }
            }
        }

        private bool isValidCep(string cep)
        {
            bool valid = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "o CEP precisa ter 8 dígitos", "Ok");
                valid = false;
            }

            int novoCep = 0;

            if (!int.TryParse(cep, out novoCep))
            {
                DisplayAlert("ERRO", "o campo CEP só aceita valores numéricos", "Ok");
                valid = false;
            }
            return true;
        }
    }
}
