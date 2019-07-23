using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class UserData
    {
        /// <summary>
        /// Metodo para comprobar la existencia del usuario logeado
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean ExisteUsuario(string user, string password)
        {

            Boolean existe = false;

            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = Contexto.Admins.Where(x => x.Users.Equals(user) && x.Pass.Equals(password)).FirstOrDefault();
                if (Resultado != null)
                    existe = true;
            }
            return existe;
        }
    }
}