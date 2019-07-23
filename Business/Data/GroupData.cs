using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class GroupData
    {
        /// <summary>
        /// Metodo que permite crear un grupo
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Crear(string Nombre, string user)
        {
            AppTecBDEntities data = new AppTecBDEntities();
            Boolean existe = false;
            var g = new Group
            {
                Name = Nombre,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1"
            };
            data.Groups.Add(g);
            data.SaveChanges();

            if (g != null)
                existe = true;
        
            return existe;
        }

      /// <summary>
      /// Metodo que permite mostrar los grupos registrados
      /// </summary>
      /// <param name="user"></param>
      /// <returns>Lista tipo grupo</returns>
        public static List<GroupAllModel> Mostrar(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from grou in Contexto.Groups
                                     where grou.Status == "1"
                                     select new GroupAllModel
                                     {
                                         Id = grou.GroupsID,
                                         Nombre = grou.Name
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from grou in Contexto.Groups
                                     where grou.Status == "1" && grou.UserCreation.Equals(user)
                                     select new GroupAllModel
                                     {
                                         Id = grou.GroupsID,
                                         Nombre = grou.Name
                                     }).ToList();
                    return Resultado;
                }
            }
        }

        /// <summary>
        /// Metodoq ue permite actualizar un grupo segun su id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Lista tipo grupo <returns>
        public static List<GroupAllModel> MostrarUpdate(int Id)
        {
            AppTecBDEntities data = new AppTecBDEntities();
            var Resultado = (from groups in data.Groups
                             where groups.GroupsID == Id
                             select new GroupAllModel
                             {
                                 Id = groups.GroupsID,
                                 Nombre = groups.Name
                             }).ToList();
            return Resultado;
        }

        /// <summary>
        /// Metodo que permite actualzar un grupo segun su id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nombre"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Actualizar(int Id, string Nombre, string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                Boolean existe = false;

                AppTecBDEntities data = new AppTecBDEntities();
                var consulta = data.Groups.First(d => d.GroupsID == Id);
                if (consulta != null)
                {
                  
                    consulta.Name = Nombre;
                    consulta.DateTimeModification = DateTime.Now;
                    consulta.UserModification = user;
                    data.SaveChanges();
                    existe = true;
                }

                return existe;
            }

        }

        /// <summary>
        /// Metodo que permite eliminar un grupo segun su id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Eliminar(int Id)
            {
            Boolean existe = false;

            AppTecBDEntities data = new AppTecBDEntities();
            var consulta = data.Groups.First(d => d.GroupsID == Id);
            if (consulta != null)
            {
                consulta.Status = "0";
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }
    }
}