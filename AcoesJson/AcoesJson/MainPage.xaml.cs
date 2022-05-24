using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;

namespace AcoesJson
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void btnPesquisar_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            string acao = edtAcao.Text;
            string dtInicial = dpkDateInicial.Date.ToString("yyyyMMdd");
            string dtFinal = dpkDateFinal.Date.ToString("yyyyMMdd");
            var json = await client.GetStringAsync($"https://www.okanebox.com.br/api/acoes/hist/{acao}/{dtInicial}/{dtFinal}/");

            List<acoes> acoes = JsonConvert.DeserializeObject<List<acoes>>(json);

            lstAcoes.ItemsSource = acoes;
        }
    }
}
