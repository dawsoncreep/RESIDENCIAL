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
	public partial class VisitasPage : ContentPage
	{
		public VisitasPage ()
		{
			InitializeComponent ();
            btnPreferentes.Clicked += BtnPreferentes_Clicked;
            btnPreRegistro.Clicked += BtnPreRegistro_Clicked;
            btnPersonal.Clicked += BtnPersonal_Clicked;
            btnEventos.Clicked += BtnEventos_Clicked;
		}

        private void BtnEventos_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EventosPage());
        }

        private void BtnPersonal_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PersonalPage());
        }

        private void BtnPreRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PreRegistroPage());
        }

        private void BtnPreferentes_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PreferentesPage());
        }
    }
}