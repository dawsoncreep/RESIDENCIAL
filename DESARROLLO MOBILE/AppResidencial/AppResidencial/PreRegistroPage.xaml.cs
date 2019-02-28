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
	public partial class PreRegistroPage : ContentPage
	{
		public PreRegistroPage ()
		{
			InitializeComponent ();
            btnGenerarRegistro.Clicked += BtnGenerarRegistro_Clicked;
		}

        private void BtnGenerarRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GenerarPreRegistrpPage());
        }
    }
}