using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class BinnacleData
    {
        /// <summary>
        /// Metodo para almacenar las acciones que realiza un usuario
        /// </summary>
        /// <param name="accion"></param>
        /// <param name="error"></param>
        /// <param name="msj"></param>
        /// <param name="U"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Recibir(string accion, string error, string msj, string U)
        {
            if (U==null)
            {
                U = "Default";
            }
            var existe = false;
            var Accion = accion;
            var User = U;
            var Error = error;
            var Msj = msj;

            Crear(Accion, User , Error, Msj);
                existe = true;

            return existe;
        }

        /// <summary>
        /// Metodo que almacena las acciones que hace un usuario en la tabla binnacle
        /// </summary>
        /// <param name="accion"></param>
        /// <param name="user"></param>
        /// <param name="error"></param>
        /// <param name="msj"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Crear(string accion, string user, string error, string msj)
        {
            var existe = false;
            AppTecBDEntities data = new AppTecBDEntities();
            var d = new Binnacle
            {
                Actions = accion,
                Users = user, 
                Error = error,
                Messages = msj,
                DateTime = DateTime.Now
            };
            data.Binnacles.Add(d);
            data.SaveChanges();

            if (d != null)
                existe = true;

            return existe;
        }
    }
}