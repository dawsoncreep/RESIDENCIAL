using caseta.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caseta
{
    public partial class Frm_Menu : Form
    {
        public Frm_Menu()
        {
            InitializeComponent();
        }

        private void Btn_VCheckIn_Click(object sender, EventArgs e)
        {
            Frm_IngresoVisita frm;
            foreach (Form item in Application.OpenForms)
            {
                if (item.GetType() == typeof(Frm_IngresoVisita))
                {
                    frm = (Frm_IngresoVisita)item;
                    item.BringToFront();
                    return;
                }
            }
            frm = new Frm_IngresoVisita();
            frm.Show();
        }

        private void Btn_Salidas_Click(object sender, EventArgs e)
        {
            Frm_ControlSalida frm;
            foreach (Form item in Application.OpenForms)
            {
                if (item.GetType() == typeof(Frm_ControlSalida))
                {
                    frm = (Frm_ControlSalida)item;
                    item.BringToFront();
                    return;
                }
            }
            frm = new Frm_ControlSalida();
            frm.Show();
        }

        private void Btn_Revision_Click(object sender, EventArgs e)
        {
            Frm_ControlEntrada frm;
            foreach (Form item in Application.OpenForms)
            {
                if (item.GetType() == typeof(Frm_ControlEntrada))
                {
                    frm = (Frm_ControlEntrada)item;
                    item.BringToFront();
                    return;
                }
            }
            frm = new Frm_ControlEntrada();
            frm.Show();
        }
    }
}
