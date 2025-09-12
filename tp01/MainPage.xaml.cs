// Leonardo de Lima Pedroso - 3026655

using System;
using Microsoft.Maui.Controls;

namespace tp01
{
    public partial class MainPage : ContentPage
    {
        const string VALID_ID = "admin";
        const string VALID_PASS = "senha@dmin";

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OkButton_Clicked(object sender, EventArgs e)
        {
            string id = IdEntry.Text?.Trim() ?? string.Empty;
            string pass = PassEntry.Text ?? string.Empty;

            if (string.IsNullOrEmpty(id))
            {
                await DisplayAlert("Aviso", "Digite o ID.", "OK");
                IdEntry.Focus();
                return;
            }

            if (string.IsNullOrEmpty(pass))
            {
                await DisplayAlert("Aviso", "Digite a senha.", "OK");
                PassEntry.Focus();
                return;
            }

            if (id == VALID_ID && pass == VALID_PASS)
            {
                await DisplayAlert("Sucesso", "Login sucedido!", "OK");
            }
            else
            {
                await DisplayAlert("Erro", "Login não autorizado!", "OK");
                PassEntry.Text = string.Empty;
                PassEntry.Focus();
            }
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            IdEntry.Text = string.Empty;
            PassEntry.Text = string.Empty;
            IdEntry.Focus();
        }

        private async void CreditsButton_Clicked(object sender, EventArgs e)
        {
            string autores = "Autor: Leonardo de Lima Pedroso - CB3026655";
            await DisplayAlert("Créditos", autores, "OK");
        }
    }
}
