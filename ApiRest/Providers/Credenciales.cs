using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRest.Providers
{
    public class Credenciales
    {
        private static string user;
        private static string contra;
        private static string token;

        public Credenciales()
        {

        }

        public Credenciales(string u, string c)
        {
            user = u;
            contra = c;
           

        }
        public Credenciales(string took)
        {
           
            token = took;

        }

        public string getUsuario()
        {
            return user;
        }

        public string getContra()
        {
            return contra;
        }

        public string getToken()
        {
            return token;
        }

    }
}