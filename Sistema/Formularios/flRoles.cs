using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportAppServer;
using CrystalDecisions.Shared;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Globalization;

namespace Sistema.Formularios
{
    public partial class flRoles : Form
    {

        Clases.Conexion c;
        //Search
        Clases.roles g;

        public flRoles()
        {
            InitializeComponent();
        }

        private void flRoles_Load(object sender, EventArgs e)
        {
            cargarfolio();
        }

        void cargarfolio()
        {
            g = new Clases.roles();
            DataSet ds = new DataSet();
            c = new Clases.Conexion(g.consecutivo());
            ds = c.Consultar();
            g = new Clases.roles();

            if (ds.Tables["Tabla"].Rows.Count > 0)
            {
                txtID.Text = ds.Tables["Tabla"].Rows[0]["folio"].ToString();// trsyutyfiyfiycviyciyc
                //txtNombre.Text = ds.Tables["Tabla"].Rows[0]["NOMBRE"].ToString();
                /* TXTCHO_MODELO.Text = ds.Tables["Tabla"].Rows[0]["CHO_MODELO"].ToString();
                 TXTCHO_TELEFONO.Text = ds.Tables["Tabla"].Rows[0]["CHO_TELEFONO"].ToString();
                 TXTCHO_COLOR.Text = ds.Tables["Tabla"].Rows[0]["CHO_COLOR"].ToString();*/
                // TXTLOT_LOTE.Select(TXTLOT_LOTE.Text.Length, 0);


            }

        }

        private void toolSave_Click(object sender, EventArgs e)
        {
            graba();
        }

        
        private void graba()
        {
            Clases.roles B = new Clases.roles(byte.Parse(txtID.Text));
            DataSet ds = new DataSet();
            c = new Clases.Conexion(B.CONSULTARI());
            ds = c.Consultar();
            g = new Clases.roles(byte.Parse(txtID.Text), txtNombre.Text);

            if (ds.Tables["Tabla"].Rows.Count > 0)
                c = new Clases.Conexion(g.modificar());
            else
                c = new Clases.Conexion(g.GRABAR());
            MessageBox.Show(c.EJECUTAR());
        }

        
        private void toolSearch_Click(object sender, EventArgs e)
        {
            try
            {
                g = new Clases.roles();
                Clases.Conexion con = new Clases.Conexion();
                if (con.Execute(g.consultageneral(), 0) == true)
                {
                    if (con.FieldValue != "")
                    {
                        txtID.Text = con.FieldValue;
                        consultar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void consultar()
        {
            if (!(txtID.Text == ""))
            {
                try
                {
                    Clases.roles B = new Clases.roles(byte.Parse(txtID.Text));
                    DataSet ds = new DataSet();
                    c = new Clases.Conexion(B.CONSULTARI());
                    ds = c.Consultar();
                    if (ds.Tables["Tabla"].Rows.Count > 0)
                    {
                        txtID.Text = ds.Tables["Tabla"].Rows[0]["ID"].ToString();
                        txtNombre.Text = ds.Tables["Tabla"].Rows[0]["NOMBRE"].ToString();
                        /* TXTCHO_MODELO.Text = ds.Tables["Tabla"].Rows[0]["CHO_MODELO"].ToString();
                         TXTCHO_TELEFONO.Text = ds.Tables["Tabla"].Rows[0]["CHO_TELEFONO"].ToString();
                         TXTCHO_COLOR.Text = ds.Tables["Tabla"].Rows[0]["CHO_COLOR"].ToString();*/
                        // TXTLOT_LOTE.Select(TXTLOT_LOTE.Text.Length, 0);


                    }
                    else

                        MessageBox.Show("No Existe este dato");
                    txtNombre.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error " + ex.Message);
                }

            }
        }

        private void toolExit_Click(object sender, EventArgs e)
        {
            Formularios.FmMenu x = new Formularios.FmMenu();
            x.Show();this.Hide();
        }

        private void toolPrint_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            Reportes.Reporte x = new Reportes.Reporte();


            Reportes.CrystalReportRol orptPrueba;
            ConnectionInfo oConexInfo;
            Tables oListaTablas;
            TableLogOnInfo oTablaConexInfo;
            oConexInfo = new ConnectionInfo();
            oConexInfo.ServerName = Clases.globales.server; 
            oConexInfo.DatabaseName = Clases.globales.dbn;

            Boolean IntegratedSecurity = false;
            oConexInfo.IntegratedSecurity = IntegratedSecurity;
            oConexInfo.UserID = Clases.globales.user;
            oConexInfo.Password = Clases.globales.password;
            oConexInfo.DatabaseName = Clases.globales.dbn;
            oConexInfo.Type = ConnectionInfoType.Query;

            //orptPrueba = new rptventasperiodo();
            orptPrueba = new Reportes.CrystalReportRol();
            oListaTablas = orptPrueba.Database.Tables;
            foreach (Table roTabla in oListaTablas)
            {
                oTablaConexInfo = roTabla.LogOnInfo;
                oTablaConexInfo.ConnectionInfo = oConexInfo;
                roTabla.ApplyLogOnInfo(oTablaConexInfo);
            }

            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;


            /*  if (!(string.IsNullOrEmpty(txtboletai.Text)))
                  orptPrueba.SetParameterValue("@FOLIOBOLETA", int.Parse(txtboletai.Text));
              else

                  MessageBox.Show("Por favor introduzca el Número de Boleta", "Advertencia",
          MessageBoxButtons.OK,
          MessageBoxIcon.Exclamation,
          MessageBoxDefaultButton.Button1);*/


            x.crystalReportViewer1.ReportSource = orptPrueba;
            x.ShowDialog();
            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
        }
    }
}
