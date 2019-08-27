using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppResidencial
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
        int i;
        public HomePage()
        {
            InitializeComponent();
            btnVisitas.Clicked += BtnVisitas_Clicked;
            btnVisitasCoto.Clicked += BtnVisitasCoto_Clicked;
            btnComunicacion.Clicked += BtnComunicacion_Clicked;
            btnBoletines.Clicked += BtnBoletines_Clicked;
            btnUsuario.Clicked += BtnUsuario_Clicked1;
            btnConfiguracion.Clicked += BtnConfiguracion_Clicked;
            
            btnRecibirVisitas.Clicked += BtnRecibirVisitas_ClickedAsync;  
        }

        private void BtnUsuario_Clicked1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UsuariosPage());
        }

        private async void BtnRecibirVisitas_ClickedAsync(object sender, EventArgs e)
        {
            if (btnRecibirVisitas.BackgroundColor.Equals(Color.FromHex("#4bbc27")))
            {
                var ans = await DisplayAlert("Pregunta?", "Desea dejar de recibir visitas", "Si", "No");
                if (ans == true)
                {
                    btnRecibirVisitas.BackgroundColor = Color.FromHex("#c71b1b");
                    btnRecibirVisitas.Text = "NO Recibir Visitas";
                    btnRecibirVisitas.Image = "cerrado.png";
                }
            }
            else if (btnRecibirVisitas.BackgroundColor.Equals(Color.FromHex("#c71b1b")))
            {
                var ans = await DisplayAlert("Pregunta?", "Desea recibir visitas", "Si", "No");
                if (ans == true)
                {
                    btnRecibirVisitas.BackgroundColor = Color.FromHex("#4bbc27");
                    btnRecibirVisitas.Text = "Recibinedo Visitas";
                    btnRecibirVisitas.Image = "abierto.png";
                }
            }
           
        }

        private void BtnPanico_Clicked(object sender, EventArgs e)
        {
            i++;

            if(i==3)
            {
                DisplayAlert("Alerta", "Boton de panico activado", "Aceptar");
                i=0;
            }
           
        }

        private void BtnConfiguracion_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConfiguracionPage());
        }

       

        private void BtnBoletines_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new BoletinesPage());
        }

        private void BtnComunicacion_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CamaraAccesoPage());
        }

        private void BtnVisitasCoto_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VisitasCotoPage());
        }

        private void BtnVisitas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VisitasPage());
        }

       
    }
}