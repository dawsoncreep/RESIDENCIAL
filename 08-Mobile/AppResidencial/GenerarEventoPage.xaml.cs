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
            btnCancelar.Clicked += BtnCancelar_Clicked;
            btnGuardar.Clicked += BtnGuardar_Clicked;
		}

        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {

            Model.Domain.Location location = new Model.Domain.Location()
            {
                Description = InLoc.Text
            };

            Model.Domain.Event evento = new Model.Domain.Event()
            {
             Description = InDesc.Text,
             DateStart = dpstart.Date + tpStart.Time,
             DateEnd = dpEnd.Date + tpEnd.Time,
             Location = location
              
            };

            var postResult = AppService.AppCommon.AppRestRequest.DoResourceServerPOST("api/eventtype/InsertUpdate", evento);
        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}