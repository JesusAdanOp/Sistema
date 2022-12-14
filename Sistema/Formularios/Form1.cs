using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Sistema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Clases.Conexion c;
        Clases.Usuarios CU;
       

        private void button2_Click(object sender, EventArgs e)
        {
            ingresar();
        }

        private void ingresar()
        {
            Clases.Usuarios u = new Clases.Usuarios(txtUser.Text, txtPass.Text);
            DataSet ds = new DataSet();
            c = new Clases.Conexion(u.Consultar());
            ds = c.Consultar();
            if (ds.Tables["Tabla"].Rows.Count > 0)
            {
                Formularios.FmMenu x = new Formularios.FmMenu();
                x.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Usuario o contraseña incorrecta", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Focus();
            }


        }
    }
}
