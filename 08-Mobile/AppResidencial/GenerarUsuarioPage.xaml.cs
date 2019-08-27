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
	public partial class GenerarUsuarioPage : ContentPage
	{
		public GenerarUsuarioPage ()
		{
			InitializeComponent ();
            this.BindingContext = new FotoClass();
		}
	}
}