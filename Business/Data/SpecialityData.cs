using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class SpecialityData
    {
        /// <summary>
        /// metodo que permite crear una especialidad
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="InstitucionId"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Crear(string Nombre, int InstitucionId, string user)
        {
            AppTecBDEntities data = new AppTecBDEntities();
            Boolean existe = false;
            var g = new Speciality
            {
                Name = Nombre,
                InstitutionID=InstitucionId,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1"
            };
            data.Specialities.Add(g);
            data.SaveChanges();

            if (g != null)
                existe = true;

            return existe;
        }

        /// <summary>
        /// Metodo que permite mostrr las especiaidades registradas
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo especialidades</returns>
        public static List<SpecialityAllModel> Mostrar(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from speciality in Contexto.Specialities
                                     join institucion in Contexto.Institutions
                                     on speciality.InstitutionID equals institucion.InstitutionID
                                     where speciality.Status == "1"
                                     select new SpecialityAllModel
                                     {
                                         Id = speciality.SpecialityID,
                                         Nombre = speciality.Name,
                                         InstitucionNombre = institucion.Name
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from speciality in Contexto.Specialities
                                     join institucion in Contexto.Institutions
                                     on speciality.InstitutionID equals institucion.InstitutionID
                                     where speciality.Status == "1" && speciality.UserCreation.Equals(user)
                                     select new SpecialityAllModel
                                     {
                                         Id = speciality.SpecialityID,
                                         Nombre = speciality.Name,
                                         InstitucionNombre = institucion.Name
                                     }).ToList();
                    return Resultado;
                }
            }
        }

        /// <summary>
        /// Metodo quer permiet mostrar infromacion de una especialidad segun su id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Lista tipo especialidad</returns>
        public static List<SpecialityAllModel> MostrarUpdate(int Id)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from speciality in Contexto.Specialities
                                 join institucion in Contexto.Institutions
                                 on speciality.InstitutionID equals institucion.InstitutionID
                                 where speciality.SpecialityID==Id
                                 select new SpecialityAllModel
                                 {
                                     Id = speciality.SpecialityID,
                                     Nombre = speciality.Name,
                                     InstitucionId = speciality.InstitutionID,
                                     InstitucionNombre=institucion.Name
                                 }).ToList();
                return Resultado;
            }
        }

        /// <summary>
        /// Metodoq ue permite actualizar una especialidad segun su id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nombre"></param>
        /// <param name="InstitucionId"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Actualizar(int Id, string Nombre, int InstitucionId, string user)
        {
            Boolean existe = false;

            AppTecBDEntities data = new AppTecBDEntities();
            var consulta = data.Specialities.First(d => d.SpecialityID == Id);
            if (consulta != null)
            {
                consulta.Name=Nombre;
                consulta.InstitutionID =InstitucionId;
                consulta.DateTimeModification = DateTime.Now;
                consulta.UserModification = user;
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }

        /// <summary>
        /// Metodo que permite eliminar una especialidad segun su id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Eliminar(int Id)
        {
            Boolean existe = false;

            AppTecBDEntities data = new AppTecBDEntities();
            var consulta = data.Specialities.First(d => d.SpecialityID == Id);
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