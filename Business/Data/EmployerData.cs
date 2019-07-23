using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class EmployerData
    {
        /// <summary>
        /// MEtod que permite crear un profesor
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Apellidop"></param>
        /// <param name="Apellidom"></param>
        /// <param name="Rfc"></param>
        /// <param name="RolId"></param>
        /// <param name="InstitucionId"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Crear(string Nombre, string Apellidop, string Apellidom, string Rfc, int RolId, int InstitucionId, string user)
        {
            AppTecBDEntities data = new AppTecBDEntities();
            Boolean existe = false;
            var s = new Employer
            {
                Name = Nombre,
                LastNameP= Apellidop,
                LastNameM = Apellidom,
                RFC = Rfc,
                RolesID=RolId,
                InstitutionID=InstitucionId,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1"
            };
            data.Employers.Add(s);
            data.SaveChanges();

            if (s != null)
                existe = true;

            return existe;
        }

        /// <summary>
        /// Metod que permite mostrar ls profesores registrados
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo empleado</returns>
        public static List<EmployerAllModel> Mostrar(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from employer in Contexto.Employers
                                     join rol in Contexto.Roles on employer.RolesID equals rol.RolesID
                                     join institucion in Contexto.Institutions on employer.InstitutionID equals institucion.InstitutionID
                                     where employer.Status == "1"
                                     select new EmployerAllModel
                                     {
                                         Id = employer.EmployersID,
                                         Nombre = employer.Name,
                                         Apellidop = employer.LastNameP,
                                         Apellidom = employer.LastNameM,
                                         Rfc = employer.RFC,
                                         RolNombre = rol.Name,
                                         InstitucionNombre = institucion.Name
                                     }).ToList();
                    return Resultado;
                }
                else
                {

                    var Resultado = (from employer in Contexto.Employers
                                     join rol in Contexto.Roles on employer.RolesID equals rol.RolesID
                                     join institucion in Contexto.Institutions on employer.InstitutionID equals institucion.InstitutionID
                                     where employer.Status == "1" && employer.UserCreation.Equals(user)
                                     select new EmployerAllModel
                                     {
                                         Id = employer.EmployersID,
                                         Nombre = employer.Name,
                                         Apellidop = employer.LastNameP,
                                         Apellidom = employer.LastNameM,
                                         Rfc = employer.RFC,
                                         RolNombre = rol.Name,
                                         InstitucionNombre = institucion.Name
                                     }).ToList();
                    return Resultado;
                }
            }
        }

        /// <summary>
        /// Metodo que permite mostrar informacion de un profesor segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Lista tipo profesor</returns>
        public static List<EmployerAllModel> MostrarActualizar(int id)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from employer in Contexto.Employers
                                 join rol in Contexto.Roles on employer.RolesID equals rol.RolesID
                                 join institucion in Contexto.Institutions on employer.InstitutionID equals institucion.InstitutionID
                                 where employer.EmployersID==id
                                 select new EmployerAllModel
                                 {
                                     Id = employer.EmployersID,
                                     Nombre = employer.Name,
                                     Apellidop = employer.LastNameP,
                                     Apellidom = employer.LastNameM,
                                     Rfc = employer.RFC,
                                     RolId=employer.RolesID,
                                     RolNombre = rol.Name,
                                     InstitucionId=employer.InstitutionID,
                                     InstitucionNombre = institucion.Name
                                 }).ToList();
                return Resultado;
            }
        }


        /// <summary>
        /// Metodo que permite actualizar un rpofesor segun su id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Nombre"></param>
        /// <param name="Apellidop"></param>
        /// <param name="Apellidom"></param>
        /// <param name="Rfc"></param>
        /// <param name="RolId"></param>
        /// <param name="InstitucionId"></param>
        /// <param name="user"></param>
        /// <returns>Lista tipo proesor</returns>
        public static Boolean Actualizar(int Id, string Nombre, string Apellidop, string Apellidom, string Rfc, int RolId, int InstitucionId,string user)
        {
            Boolean existe = false;

            AppTecBDEntities data = new AppTecBDEntities();
            var consulta = data.Employers.First(d => d.EmployersID == Id);
            if (consulta != null)
            {
                consulta.Name=Nombre;
                consulta.LastNameP =Apellidop;
                consulta.LastNameM =Apellidom;
                consulta.RFC = Rfc;
                consulta.RolesID = RolId;
                consulta.InstitutionID = InstitucionId;
                consulta.DateTimeModification = DateTime.Now;
                consulta.UserModification = user;
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }


        /// <summary>
        /// Metodo  que permite eliminarr un profesor segun su id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Eliminar(int Id)
        {
            Boolean existe = false;

            AppTecBDEntities data = new AppTecBDEntities();
            var consulta = data.Employers.First(d => d.EmployersID == Id);
            if (consulta != null)
            {
                consulta.Status = "0";
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }

        /// <summary>
        /// Metodo que permite obtener los roles manejados
        /// </summary>
        /// <returns>Lista tipo Rol</returns>
        public static List<RolAllModel> ObtenerRol()
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from rol in Contexto.Roles

                                 select new RolAllModel
                                 {
                                     Id = rol.RolesID,
                                     Nombre = rol.Name
                                 }).ToList();
                return Resultado;
            }
        }
    }
}