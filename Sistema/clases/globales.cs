using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Clases
{
    public static class globales
    {
        //Clase: globales
        static public string dbn = "PedidosMaria";
        static public string server = "AD4N";
        static public string user = "sa";
        static public string password = "12345687";

        static public string mycon = @"Data source=" + server + "; Initial Catalog= "+dbn+";Persist Security info=True; User ID="+user+";Password="+password+";";
    }
}
