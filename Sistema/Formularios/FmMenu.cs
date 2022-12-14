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
    public partial class FmMenu : Form
    {
        public FmMenu()
        {
            InitializeComponent();
        }

        private void oToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Roles
            Formularios.flRoles x = new Formularios.flRoles();
            x.Show();

        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Usuarios
            Formularios.FmUsuario x = new Formularios.FmUsuario();
            x.Show(); 
        }

        private void FmMenu_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void datosGeneralesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Datos_generales x = new Datos_generales();
            x.Show();
        }
    }
}
