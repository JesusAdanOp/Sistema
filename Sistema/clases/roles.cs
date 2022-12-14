using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Clases
{
    internal class roles
    {

        private byte id;
        private string nombre;

        //metodo constructor para grabar y editar
        public roles(byte id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        //Metodo constructor consultar
        public roles(byte id)
        {
            this.id = id;
        }

        public roles()
        {

        }

        public string GRABAR()
        {
            return (" insert into ROL values ('" + this.id + "','" + this.nombre + "')");
        }
        public string CONSULTARI()
        {
            return (" SELECT * FROM  ROL WHERE ID = '" + this.id + "'");
        }
        public string modificar()
        {
            return (" update ROL set NOMBRE ='" + this.nombre + "' WHERE ID = '" + this.id + "'");
        }
        public string consultageneral()
        {
            return (" SELECT ID as ID, NOMBRE as NOMBRE FROM  ROL");
        }
        public string consecutivo()
        {
            return ("select count(*) +1 as folio from ROL");
        }
    }
}
