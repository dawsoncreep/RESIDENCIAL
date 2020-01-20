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
        public Frm_IngresoVisita()
        {
            InitializeComponent();
            externalProcessor = new ExternalProcessor();
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
        }
    }
}
