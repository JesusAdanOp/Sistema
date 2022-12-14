using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Clases
{
    internal class Usuarios
    {
        string userLogin;
        string userPassword;
        string userName;

        public Usuarios(string userLogin, string userPassword)
        {
            this.userLogin = userLogin;
            this.userPassword = userPassword;
        }

        public string Consultar()
        {
            return (" SELECT * FROM USUARIO WHERE USERNAME='"+userLogin+"' AND CONTRASEÑA = dbo.MD5('"+this.userPassword+"')");
        }
    }
}
