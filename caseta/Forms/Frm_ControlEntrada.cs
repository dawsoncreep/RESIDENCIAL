using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caseta.Forms
{
    public partial class Frm_ControlEntrada : Form
    {
        public Frm_ControlEntrada()
        {
            InitializeComponent();
        }

        private void Menu_IngresoTag_Click(object sender, EventArgs e)
        {
            Frm_IngresoTag frm;
            foreach (Form item in Application.OpenForms)
            {
                if (item.GetType() == typeof(Frm_IngresoTag))
                {
                    frm = (Frm_IngresoTag)item;
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    return;
                }
            }
            frm = new Frm_IngresoTag() { MdiParent = this };
            frm.Show();
        }

        private void Menu_IngresoVisita_Click(object sender, EventArgs e)
        {
            Frm_IngresoVisita frm;
            foreach (Form item in Application.OpenForms)
            {
                if (item.GetType() == typeof(Frm_IngresoVisita))
                {
                    frm = (Frm_IngresoVisita)item;
                    frm.WindowState = FormWindowState.Normal;
                    frm.BringToFront();
                    return;
                }
            }
            frm = new Frm_IngresoVisita() { MdiParent = this };
            frm.Show();
        }
    }
}
