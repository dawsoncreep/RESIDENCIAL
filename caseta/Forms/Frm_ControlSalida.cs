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

namespace caseta.Forms
{
    public partial class Frm_ControlSalida : Form
    {
        public Frm_ControlSalida()
        {
            InitializeComponent();
            

            //SPC_PLacaT.StartPlay(new Uri(ConfigurationManager.AppSettings["PlacaTrasera"]));
            //SPC_PlacaDelantera.StartPlay(new Uri(ConfigurationManager.AppSettings["PlacaDelantera"]));
            //SPC_Rostro.StartPlay(new Uri(ConfigurationManager.AppSettings["Rostro"]));
            //SPC_Credencial.StartPlay(new Uri(ConfigurationManager.AppSettings["Credencial"]));
        }

        private void MItem_SalidaVisita_Click(object sender, EventArgs e)
        {
            Frm_Salida frm;
            foreach (Form item in Application.OpenForms)
            {
                if (item.GetType() == typeof(Frm_Salida))
                {
                    frm = (Frm_Salida)item;
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    return;
                }
            }
            frm = new Frm_Salida() { MdiParent = this };
            frm.Show();
        }
    }
}
