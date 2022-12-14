using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.clases
{
    internal class Modulo
    {
        byte id;
        string nombre;

        public Modulo(byte id, string name)
        {
            this.id = id;
            this.nombre = name;
        }
        public Modulo(byte id)
        {
            this.id = id;
        }

        public Modulo()
        {
            
        }

        public string GRABAR()
        {
            return (" insert into MODULO values ('" + this.id + "','" + this.nombre + "')");
        }
        public string CONSULTARI()
        {
            return (" SELECT * FROM  MODULO WHERE ID_MODULO = '" + this.id + "'");
        }
        public string modificar()
        {
            return (" update MODULO set NOMBRE ='" + this.nombre + "' WHERE ID = '" + this.id + "'");
        }
        public string consultageneral()
        {
            return (" SELECT ID_MODULO as ID, NOMBRE as NOMBRE FROM  MODULO");
        }
        public string consecutivo()
        {
            return ("select count(*) +1 as folio from MODULO");
        }
    }
}
