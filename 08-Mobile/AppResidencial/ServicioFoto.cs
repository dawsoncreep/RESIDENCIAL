using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppResidencial.Servicios
{
    class ServicioFoto
    {
        public ServicioFoto()
        {
            CrossMedia.Current.Initialize();
        }

        private static ServicioFoto m_Instancia;

        public static ServicioFoto Instancia
        {
            get
            {
                if (m_Instancia == null)
                {
                    m_Instancia = new ServicioFoto();
                }

                return m_Instancia;
            }
        }

        public async Task<MediaFile> SeleccionarFoto()
        {
            MediaFile foto = null;
            try
            {

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    return null;
                }
                else
                {
                    foto = await CrossMedia.Current.PickPhotoAsync();
                }

            }
            catch (TaskCanceledException)
            {
                foto = null;
            }
            return foto;
        }
    }
}
