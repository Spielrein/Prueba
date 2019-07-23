using Business.Model.Api;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data.Api
{
    public class EnrollmentData
    {
        /// <summary>
        /// Metodo que permite obtener la matricula de un alumno registrado
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Matricula del alumno</returns>
        public static string Enrollment(string token)
        {
            
            using (var Contexto = new AppTecBDEntities())
            {

                var matricula = (from b in Contexto.Autentications
                                 where b.Token.Equals(token)
                                 select new Comps
                                 {
                                     Matricula = b.User
                                 }).FirstOrDefault();

                string a = matricula.Matricula;
                return a;
            }
        }

        public static string UserAdmin(string token)
        {

            using (var Contexto = new AppTecBDEntities())
            {

                var matricula = (from b in Contexto.Autentications
                                 where b.Token.Equals(token)
                                 select new Comps
                                 {
                                     Matricula = b.User
                                 }).FirstOrDefault();

                string a = matricula.Matricula;
                return a;
            }
        }
    }
}