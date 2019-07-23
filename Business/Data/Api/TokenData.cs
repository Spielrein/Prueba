using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Business.Data.Api
{
    public class TokenData
    {
        /// <summary>
        /// Metodo que permite validar el token para ser usado 
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static bool ValidarToken(string token)
        {
            using (var contexto = new AppTecBDEntities())
            {
                var actual = DateTime.Now;

                var tok = contexto.Autentications.Where(x => x.Token.Equals(token) && x.Deleted > DateTime.Now && x.Status.Equals("1")).FirstOrDefault();
                //var matricula = contexto.Autentications.Select(y => y.User).Where(z =)
                if (tok != null && !(DateTime.Now > tok.Deleted))
                {

                    tok.Deleted = DateTime.Now.AddDays(1);
                    contexto.Entry(tok).State = System.Data.Entity.EntityState.Modified;
                    contexto.SaveChanges();
                    return true;
                }
                else
                {
                    var estado = InvalidarToken(token);
                    return estado;

                }
            }
        }

        /// <summary>
        /// MEtodo que permite invalidar el token
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static bool InvalidarToken(string token)
        {
            using (var Contexto = new AppTecBDEntities())
            {

                var id = (from tok in Contexto.Autentications where tok.Token.Equals(token) select tok.IdToken).FirstOrDefault();
                var to = (from tok in Contexto.Autentications where tok.Token.Equals(token) select tok.Token).FirstOrDefault();
                var id_al = (from tok in Contexto.Autentications where tok.Token.Equals(token) select tok.User).FirstOrDefault();
                var tokeniss = (from tok in Contexto.Autentications where tok.Token.Equals(token) select tok.Inssued).FirstOrDefault();
                var tokendel = (from tok in Contexto.Autentications where tok.Token.Equals(token) select tok.Deleted).FirstOrDefault();

                var query = (from t in Contexto.Autentications
                             where t.Token == token
                             select t).FirstOrDefault();

                query.IdToken = id;
                query.Token = to;
                query.User = id_al;
                query.Inssued = tokeniss;
                query.Deleted = tokendel;
                query.Status = "0";

                Contexto.SaveChanges();
            }
            return false;
        }

    }
}