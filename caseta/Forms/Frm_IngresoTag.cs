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
    public partial class Frm_IngresoTag : Form
    {
        public Frm_IngresoTag()
        {
            InitializeComponent();
            SPC_PlacaTrasera.StartPlay(new Uri(ConfigurationManager.AppSettings["PlacaTrasera"]));
            SPC_PlacaDelantera.StartPlay(new Uri(ConfigurationManager.AppSettings["Rostro"]));
        }
    }
}
