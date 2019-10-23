using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;


using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppResidencial
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GenerarRegistroPage : ContentPage
	{
		public GenerarRegistroPage ()
		{
			InitializeComponent ();
            this.BindingContext = new FotoClass();
            btnGuardar.Clicked += BtnGuardar_Clicked;

         

        }

        private void BtnGuardar_Clicked(object sender, EventArgs e)
        {
            Model.Domain.Location location = new Model.Domain.Location()
            {
                Description = InLoca.Text
            };

            Model.Domain.ExternalType externalType = new Model.Domain.ExternalType()
            {
                Description = "Visitante"
            };
    
            Model.Domain.External res = new Model.Domain.External()
            {
                Name = InNombre.Text,
                FirstName = InApPat.Text,
                LastName = InApMat.Text,
                LicensePlate = InPlacas.Text,
                ExternalType = externalType,
                Image = ImFoto.Source.ToString(),
                Location = location


            };

            var postResult1 = AppService.AppCommon.AppRestRequest.DoResourceServerPOST("api/eventtype/InsertUpdate", res);

        }
    }
}