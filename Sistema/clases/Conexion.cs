using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using CEDOTOYA.FORMULARIOS;



namespace Sistema.Clases
{
    internal class Conexion
    {
        //Clase conexion
        private string sentencia1;
        private SqlConnection conn = new SqlConnection();
        private SqlCommand cmd;

        public Conexion()
        {

        }
        public Conexion(string sentencia1)
        {
            this.sentencia1 = sentencia1;
        }

        public string EJECUTAR()
        {
            conn.ConnectionString = Clases.globales.mycon;
            if (conn.State!=ConnectionState.Open)
            {
                conn.Close();
                conn.Open();
            }
            cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = sentencia1;
            cmd.ExecuteNonQuery();
            conn.Close();

            return "Operacion exitosa";
        }

        public DataSet Consultar()
        {
            DataSet datos = new DataSet();
            conn = new SqlConnection(Clases.globales.mycon);
            if (conn.State != ConnectionState.Open)
            {
                conn.Close();conn.Open();
            }
            SqlDataAdapter resp = new SqlDataAdapter(sentencia1, conn);
            resp.Fill(datos, "Tabla");
            conn.Close();
            return datos;
        }

        private string mFieldValue;
        internal string FieldValue
        {
            get { return mFieldValue; }
        }
        internal bool Execute(string SQL, int ColumnNumberToRetrive)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(SQL, Clases.globales.mycon);
            da.Fill(ds, "Table");

            SearchForm frmSearchForm = new SearchForm();
            frmSearchForm.mColNumber = ColumnNumberToRetrive;
            frmSearchForm.mDS = ds;
            ds = null;
            frmSearchForm.ShowDialog();
            if (frmSearchForm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                mFieldValue = frmSearchForm.ReturnValue;
                return true;
            }
            else
            {
                return false;
            }
        }





    }
}
