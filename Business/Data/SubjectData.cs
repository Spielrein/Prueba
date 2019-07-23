using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class SubjectData
    {
        /// <summary>
        /// MEtodo que perite crear una materia
        /// </summary>
        /// <param name="Clave"></param>
        /// <param name="Nombre"></param>
        /// <param name="Creditos"></param>
        /// <param name="Carreraid"></param>
        /// <param name="EspecialidadId"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Crear(string Clave, string Nombre, int Creditos, int Carreraid, int EspecialidadId, string user)
        {
            AppTecBDEntities data = new AppTecBDEntities();
            Boolean existe = false;
            var s = new Subject
            {
                Clave = Clave,
                Name = Nombre,
                Credits = Creditos,
                CareersID = Carreraid,
                SpecialityID = EspecialidadId,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1"
            };
            data.Subjects.Add(s);
            data.SaveChanges();

            if (s != null)
                existe = true;

            return existe;
        }

        /// <summary>
        /// Metodo que permite mostrar las materias registradas
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo materia</returns>
        public static List<SubjectAllModel> Mostrar(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from subject in Contexto.Subjects
                                     join career in Contexto.Careers on subject.CareersID equals career.CareersID
                                     join speciality in Contexto.Specialities on subject.SpecialityID equals speciality.SpecialityID
                                     where subject.Status == "1"
                                     select new SubjectAllModel
                                     {
                                         Id = subject.SubjectsID,
                                         Clave = subject.Clave,
                                         Nombre = subject.Name,
                                         Creditos = subject.Credits,
                                         CarreraNombre = career.Name,
                                         EspecialidadNombre = speciality.Name
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from subject in Contexto.Subjects
                                     join career in Contexto.Careers on subject.CareersID equals career.CareersID
                                     join speciality in Contexto.Specialities on subject.SpecialityID equals speciality.SpecialityID
                                     where subject.Status == "1" && subject.UserCreation.Equals(user)
                                     select new SubjectAllModel
                                     {
                                         Id = subject.SubjectsID,
                                         Clave = subject.Clave,
                                         Nombre = subject.Name,
                                         Creditos = subject.Credits,
                                         CarreraNombre = career.Name,
                                         EspecialidadNombre = speciality.Name
                                     }).ToList();
                    return Resultado;
                }
            }
        }

        /// <summary>
        /// Metodo para mostrar informacion de una materia segun si id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Lista tipo materia</returns>
        public static List<SubjectAllModel> MostrarActualizar(int id)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from subject in Contexto.Subjects
                                 join career in Contexto.Careers on subject.CareersID equals career.CareersID
                                 join speciality in Contexto.Specialities on subject.SubjectsID equals speciality.SpecialityID
                                 where subject.SubjectsID==id
                                 select new SubjectAllModel
                                 {
                                     Id = subject.SubjectsID,
                                     Clave = subject.Clave,
                                     Nombre = subject.Name,
                                     Creditos = subject.Credits,
                                     CarreraId=subject.CareersID,
                                     CarreraNombre = career.Name,
                                     EspecialidadId=subject.SubjectsID,
                                     EspecialidadNombre = speciality.Name
                                 }).ToList();
                return Resultado;
            }
        }


        /// <summary>
        /// Metodo para editar una teria segun su id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Clave"></param>
        /// <param name="Nombre"></param>
        /// <param name="Creditos"></param>
        /// <param name="CarreraId"></param>
        /// <param name="EspecialidadId"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Actualizar(int Id, string Clave, string Nombre, int Creditos, int CarreraId, int EspecialidadId, string user)
        {
            Boolean existe = false;

            AppTecBDEntities data = new AppTecBDEntities();
            var consulta = data.Subjects.First(d => d.SubjectsID == Id);
            if (consulta != null)
            {
                consulta.Clave = Clave;
                consulta.Name = Nombre;
                consulta.Credits = Creditos;
                consulta.CareersID = CarreraId;
                consulta.SpecialityID = EspecialidadId;
                consulta.DateTimeModification = DateTime.Now;
                consulta.UserModification = user;
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }


        /// <summary>
        /// MEtodo para eliminar una materia
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Eliminar(int Id)
        {
            Boolean existe = false;

            AppTecBDEntities data = new AppTecBDEntities();
            var consulta = data.Subjects.First(d => d.SubjectsID == Id);
            if (consulta != null)
            {
                consulta.Status = "0";
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }

        /// <summary>
        /// MEtodo para obtener una especialidad registrada
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo especialidad</returns>
        public static List<SpecialityAllModel> ObtenerEspecialidad(string user)
        {
           
                using (var Contexto = new AppTecBDEntities())
                {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from speciality in Contexto.Specialities
                                     where speciality.Status == "1" 
                                     select new SpecialityAllModel
                                     {
                                         Id = speciality.SpecialityID,
                                         Nombre = speciality.Name
                                     }).ToList();
                    return Resultado;
                }else{
                    var Resultado = (from speciality in Contexto.Specialities
                                     where speciality.Status == "1" && speciality.UserCreation.Equals(user)
                                     select new SpecialityAllModel
                                     {
                                         Id = speciality.SpecialityID,
                                         Nombre = speciality.Name
                                     }).ToList();
                    return Resultado;
                }
            }
        }

        /// <summary>
        /// Metodo para mostrar las carreras registradas
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo carreras</returns>
        public static List<CareerAllModel> ObtenerCarrera(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from career in Contexto.Careers
                                     where career.Status == "1"
                                     select new CareerAllModel
                                     {
                                         Id = career.CareersID,
                                         Nombre = career.Name
                                     }).ToList();
                    return Resultado;
                }
                else {
                    var Resultado = (from career in Contexto.Careers
                                     where career.Status == "1" && career.UserCreation.Equals(user)
                                     select new CareerAllModel
                                     {
                                         Id = career.CareersID,
                                         Nombre = career.Name
                                     }).ToList();
                    return Resultado;
                }
            }
        }
    }
}
