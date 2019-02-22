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
        public HomePage()
        {
            InitializeComponent();
            btnVisitas.Clicked += BtnVisitas_Clicked;
           
        }

        private void BtnVisitas_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VisitasPage());
        }
    }
}