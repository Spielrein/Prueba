using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class ValidationData
    {
        /// <summary>
        /// MEtodo que permite almacenar los datos del admin y del token en authenticacion
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <param name="token"></param>
        /// <param name="delete"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public Boolean InsertValidation(string user, string password, string token, DateTime delete)
        {
            AppTecBDEntities data = new AppTecBDEntities();
            Boolean status = false;
            var insertToken = new Autentication
            {
                User = user,
                Pass = password,
                Token = token,
                Inssued = DateTime.Now,
                Deleted= delete,
                Status = "1"
            };

            data.Autentications.Add(insertToken);
            data.SaveChanges();

            if (insertToken != null)
                status = true;

            return status;
        }


        /// <summary>
        /// MEtodo que permit evalidar el token
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public Boolean ValidationToken(string token)
        {
            Boolean status = false;

            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = Contexto.Autentications.Where(x => x.Token.Equals(token) && x.Deleted>(DateTime.Now)).FirstOrDefault();
                if (Resultado != null)
                    status = true;
            }
          
            return status;
        }
    }
}