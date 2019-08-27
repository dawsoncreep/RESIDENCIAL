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
	public partial class PersonalPage : ContentPage
	{
		public PersonalPage ()
		{
			InitializeComponent ();
            btnGenerarPersonal.Clicked += BtnGenerarPersonal_Clicked;
		}

        private void BtnGenerarPersonal_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GenerarPersonalPage());
        }
    }
}