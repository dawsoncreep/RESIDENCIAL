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
	public partial class GenerarEventoPage : ContentPage
	{
		public GenerarEventoPage ()
		{
			InitializeComponent ();
            this.BindingContext = new FotoClass();
		}
	}
}