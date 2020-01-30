using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebEye.Controls.WinForms.StreamPlayerControl;
using BusinessLayer;

namespace caseta
{
    public partial class Frm_IngresoVisita : Form
    {
        private readonly ExternalProcessor externalProcessor;
        private readonly LocationProcessor locationProcessor;
        private readonly PictureProcessor pictureProcessor;
        public Frm_IngresoVisita()
        {
            InitializeComponent();
            externalProcessor = new ExternalProcessor();
            locationProcessor = new LocationProcessor();
            var items = externalProcessor.GetExternalTypes();
            foreach (var item in items)
            {
                Cbx_RType.Items.Add(item);
            }
            Cbx_RType.ValueMember = "id";
            Cbx_RType.DisplayMember = "Description";
            
            
        }

        private void Frm_IngresoVisita_Load(object sender, EventArgs e)
        {
            SPC_PLacaT.StartPlay(new Uri(ConfigurationManager.AppSettings["PlacaTrasera"]));
            SPC_PlacaDelantera.StartPlay(new Uri(ConfigurationManager.AppSettings["PlacaDelantera"]));
            SPC_Rostro.StartPlay(new Uri(ConfigurationManager.AppSettings["Rostro"]));
            SPC_Credencial.StartPlay(new Uri(ConfigurationManager.AppSettings["Credencial"]));
            AutoCompleteStringCollection Collection = new AutoCompleteStringCollection();
            Collection.AddRange(locationProcessor.GetLocationsString());
            Cbbx_Domicilio.AutoCompleteCustomSource = Collection;
        }

        private void Btn_PAcceso_Click(object sender, EventArgs e)
        {            
            if (Cbx_RType.Text != "Personal")
            {
                Bitmap rostro = SPC_Rostro.GetCurrentFrame();
                Bitmap placaT = SPC_PLacaT.GetCurrentFrame();
                Bitmap placaD = SPC_PlacaDelantera.GetCurrentFrame();
                Bitmap credencial = SPC_Credencial.GetCurrentFrame();
                credencial.Save(ConfigurationManager.AppSettings["PicturePath"] + Tbx_PLacas.Text + "-Credencial.jpg");
                rostro.Save(ConfigurationManager.AppSettings["PicturePath"] + Tbx_PLacas.Text + "-Rostro.jpg");
                placaT.Save(ConfigurationManager.AppSettings["PicturePath"] + Tbx_PLacas.Text + "-PlacaT.jpg");
                placaD.Save(ConfigurationManager.AppSettings["PicturePath"] + Tbx_PLacas.Text + "-PlacaD.jpg");
                
            }
            
        }
    }
}
