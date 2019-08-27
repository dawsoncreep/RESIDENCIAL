using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppResidencial.Servicios;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace AppResidencial
{
    class FotoClass : BindableObject
    {
        public static readonly BindableProperty RutaFotoProperty = BindableProperty.Create(
                         "RutaFoto",
                         typeof(string),
                         typeof(FotoClass),
                         default(string));

        public string RutaFoto
        {
            get
            {
                return (string)GetValue(RutaFotoProperty);
            }
            set
            {
                SetValue(RutaFotoProperty, value);
            }
        }

        private MediaFile Foto;

        public Command m_seleccionarFotoComand;

        public Command SeleccionarFotoComand
        {
            get
            {
                return (m_seleccionarFotoComand ?? (m_seleccionarFotoComand = new Command(async () => await SeleccionarFotoAsync())));
            }
        }

        public async Task<bool> SeleccionarFotoAsync()
        {
            int nErrores = 0;
            try
            {
                Foto = await ServicioFoto.Instancia.SeleccionarFoto();
                if (Foto != null)
                {
                    RutaFoto = Foto.Path;
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                nErrores++;
            }
            return (nErrores == 0);
        }

        public FotoClass()
        {

        }
    }
}
