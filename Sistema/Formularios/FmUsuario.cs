using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Formularios
{
    public partial class FmUsuario : Form
    {
        public FmUsuario()
        {
            InitializeComponent();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Formularios.FmMenu x = new Formularios.FmMenu();
            x.Show(); this.Hide();
        }
    }
}
