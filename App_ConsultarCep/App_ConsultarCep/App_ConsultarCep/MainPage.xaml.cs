using App_ConsultarCep.Models;
using App_ConsultarCep.Services;
using System;
using System.ComponentModel;
using System.Threading;
using Xamarin.Forms;

namespace App_ConsultarCep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BuscarCep(object sender, EventArgs args)
        {
            //Validações
            string cep = txtCep.Text.Trim();

            if (isValidCep(cep))
            {
                try
                {
                    //Lógica do programa
                    EnderecoModel endereco = ViaCepService.BuscarCep(cep);

                    if (endereco != null)
                    {
                        lblLogradouro.Text = $"Endereço: {endereco.Logradouro},{endereco.Bairro}, {endereco.Localidade}, {endereco.Uf}";
                    }
                    else
                    {
                        DisplayAlert("Erro crítico", "Cep não encontrado", "Ok");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("Erro crítico", ex.Message, "Ok");
                }
            }
        }

        private bool isValidCep(string cep)
        {
            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "O cep deve conter 8 caracteres", "Ok");
                return false;
            }

            return true;
        }
    }
}
