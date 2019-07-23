using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class InstitutionData
    {

        /// <summary>
        /// Metodo que permite obtener los niveles educativos registrados
        /// </summary>
        /// <returns>Lista tipo nivel educativo</returns>

        public static List<EducationLevelAllmodel> ObtenerNivel()
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from education in Contexto.EducationLevels

                                 select new EducationLevelAllmodel
                                 {
                                     Id = education.EducationLevelID,
                                     Nombre = education.Level
                                 }).ToList();
                return Resultado;
            }
        }


        /// <summary>
        /// Metodo que permite mostrar las instituciones registradas
        /// </summary>
        /// <param name="u"></param>
        /// <returns>Lista tipo instituciones</returns>
        public static List<InstitutionRegisterAllModel> Mostrar(string u)
        {
            using (var Contexto = new AppTecBDEntities())
            {



                if (u == "SuperPowerUser")
                {
                    var Resultado = (from Institution in Contexto.Institutions
                                     join edLevel in Contexto.EducationLevels on Institution.EducationLevelID equals edLevel.EducationLevelID
                                     where Institution.Status == "1" 
                                     select new InstitutionRegisterAllModel
                                     {
                                         InstitutionID = Institution.InstitutionID,
                                         Name = Institution.Name,
                                         Direction = Institution.Direction,
                                         Phone = Institution.Phone,
                                         EducationLevelName = edLevel.Level,
                                         Logo = Institution.Logo,
                                         Director = Institution.Director

                                     }).ToList();
                    return Resultado;

                }
                else
                {
                    var Resultado = (from Institution in Contexto.Institutions
                                     join edLevel in Contexto.EducationLevels on Institution.EducationLevelID equals edLevel.EducationLevelID
                                     where Institution.Status == "1" && Institution.UserCreation == u
                                     select new InstitutionRegisterAllModel
                                     {
                                         InstitutionID = Institution.InstitutionID,
                                         Name = Institution.Name,
                                         Direction = Institution.Direction,
                                         Phone = Institution.Phone,
                                         EducationLevelName = edLevel.Level,
                                         Logo = Institution.Logo,
                                         Director = Institution.Director

                                     }).ToList();
                    return Resultado;

                }


            }
        }


        /// <summary>
        /// Metodo que permite crear un institucion
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="direccion"></param>
        /// <param name="phone"></param>
        /// <param name="nivel"></param>
        /// <param name="director"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Crear(string nombre, string direccion, string phone, int nivel, string director, string user)
        {
            AppTecBDEntities data = new AppTecBDEntities();
            Boolean existe = false;
            var i = new Institution
            {
                Name = nombre,
                Direction = direccion,
                Phone = phone,
                EducationLevelID = nivel,
                Logo = "",
                Director = director,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = "Default",
                UserModification = "Default",
                Status = "1"
            };
            data.Institutions.Add(i);
            data.SaveChanges();
            if (i != null)
            {
                existe = true;

            }
            return existe;

        }


        /// <summary>
        /// Metodo que permite mostrar informacion de una institucion segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Lista tipo institucion</returns>
        public static List<InstitutionRegisterAllModel> UpdateShow(int id)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from Institution in Contexto.Institutions
                                 where Institution.InstitutionID == id
                                 select new InstitutionRegisterAllModel
                                 {
                                     InstitutionID = Institution.InstitutionID,
                                     Name = Institution.Name,
                                     Direction = Institution.Direction,
                                     Phone = Institution.Phone,
                                     EducationLevelID = Institution.EducationLevelID,
                                     Logo = Institution.Logo,
                                     Director = Institution.Director
                                 }).ToList();

                return Resultado;
            }
        }


        /// <summary>
        /// Metodo que permite actualizar una institucoin segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="direccion"></param>
        /// <param name="phone"></param>
        /// <param name="nivel"></param>
        /// <param name="logo"></param>
        /// <param name="director"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean UpdateRegister(int id, string name, string direccion, string phone, int nivel, string logo, string director, string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                Boolean existe = false;
                AppTecBDEntities data = new AppTecBDEntities();
                var consulta = data.Institutions.First(a => a.InstitutionID == id);
                if (consulta != null)
                {
                    consulta.Name = name;
                    consulta.Direction = direccion;
                    consulta.Phone = phone;
                    consulta.EducationLevelID = nivel;
                    consulta.Logo = logo;
                    consulta.Director = director;
                    consulta.DateTimeModification = DateTime.Now;
                    consulta.UserModification = user;

                    data.SaveChanges();
                    existe = true;
                }

                return existe;
            }
        }


        /// <summary>
        /// Metodo que permite actualizar el usuario que registro la institucion
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean UpdateRegisterUser(int id, string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                Boolean existe = false;
                AppTecBDEntities data = new AppTecBDEntities();
                var consulta = data.Institutions.First(a => a.InstitutionID == id);
                if (consulta != null)
                {

                    consulta.UserCreation = user;

                    data.SaveChanges();
                    existe = true;
                }

                return existe;
            }
        }

        /// <summary>
        /// Metodo que permite eliminar una institucion segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Eliminar(int id)
        {
            Boolean existe = false;
            AppTecBDEntities data = new AppTecBDEntities();
            var consulta = data.Institutions.First(i => i.InstitutionID == id);

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