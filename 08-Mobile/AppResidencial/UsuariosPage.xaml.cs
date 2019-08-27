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
	public partial class UsuariosPage : ContentPage
	{
		public UsuariosPage ()
		{
			InitializeComponent ();
            btnGenerarUsuario.Clicked += BtnGenerarUsuario_Clicked;
		}

        private void BtnGenerarUsuario_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new GenerarUsuarioPage());
        }
    }
}