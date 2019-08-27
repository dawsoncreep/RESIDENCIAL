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
	public partial class EventosPage : ContentPage
	{
		public EventosPage ()
		{
			InitializeComponent ();
            btnGenerarEvento.Clicked += BtnGenerarEvento_Clicked;
		}

        private void BtnGenerarEvento_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GenerarEventoPage());
        }
    }
}