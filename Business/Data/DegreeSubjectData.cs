using Business.Model;
using Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class DegreeSubjectData
    {
        /// <summary>
        /// Metodo que permite cear una asignacion de materias y grados
        /// </summary>
        /// <param name="DegreeId"></param>
        /// <param name="SubjectId"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Crear(int DegreeId, int SubjectId, string user)
        {
            AppTecBDEntities data = new AppTecBDEntities();
            Boolean existe = false;
            var s = new DegreeSubject
            {
                DegreeID=DegreeId,
                SubjectsID=SubjectId,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1"
            };
            data.DegreeSubjects.Add(s);
            data.SaveChanges();

            if (s != null)
                existe = true;

            return existe;
        }

        /// <summary>
        /// Metodo que permite mostrar las asignaciones registradas
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo materiaGrado</returns>
        public static List<DegreeSubjectAllModel> Mostrar(string user)
        {

            using (var Contexto = new AppTecBDEntities())
            {
               if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from degreeSubject in Contexto.DegreeSubjects
                                     join subject in Contexto.Subjects on degreeSubject.SubjectsID equals subject.SubjectsID
                                     join degree in Contexto.Degrees on degreeSubject.DegreeID equals degree.DegreeID
                                     select new DegreeSubjectAllModel
                                     {
                                         Id = degreeSubject.DegreeSubjectsID,
                                         DegreeNombre = degree.Name,
                                         SubjectNombre = subject.Name
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from degreeSubject in Contexto.DegreeSubjects
                                     join subject in Contexto.Subjects on degreeSubject.SubjectsID equals subject.SubjectsID
                                     join degree in Contexto.Degrees on degreeSubject.DegreeID equals degree.DegreeID
                                     where degreeSubject.UserCreation.Equals(user)
                                     select new DegreeSubjectAllModel
                                     {
                                         Id = degreeSubject.DegreeSubjectsID,
                                         DegreeNombre = degree.Name,
                                         SubjectNombre = subject.Name
                                     }).ToList();
                    return Resultado;
                }
            }
        }

        /// <summary>
        /// Metodo que permite mostrar informacion de una asignacion segu su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Lista tipo materiaGrao</returns>
        public static List<DegreeSubjectAllModel> MostrarActualizar(int id)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from degreeSubject in Contexto.DegreeSubjects
                                 join subject in Contexto.Subjects on degreeSubject.SubjectsID equals subject.SubjectsID
                                 join degree in Contexto.Degrees on degreeSubject.DegreeID equals degree.DegreeID
                                 where degreeSubject.DegreeSubjectsID==id
                                 select new DegreeSubjectAllModel
                                 {
                                     Id = degreeSubject.DegreeSubjectsID,
                                     DegreeId=degreeSubject.DegreeID,
                                     DegreeNombre = degree.Name,
                                     SubjectId=degreeSubject.SubjectsID,
                                     SubjectNombre = subject.Name
                                 }).ToList();
                return Resultado;
            }
        }

        /// <summary>
        /// Metodo que permite actualizar una asignacion segun si id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="DegreeId"></param>
        /// <param name="SubjectId"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Actualizar(int Id, int DegreeId, int SubjectId, string user)
        {
            Boolean existe = false;

            AppTecBDEntities data = new AppTecBDEntities();
            var consulta = data.DegreeSubjects.First(d => d.DegreeSubjectsID ==Id);
            if (consulta != null)
            {
                consulta.DegreeID = DegreeId;
                consulta.SubjectsID = SubjectId;
                consulta.DateTimeModification = DateTime.Now;
                consulta.UserModification = user;
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }

        /// <summary>
        /// metodo que permite obtener los grados registrados
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo grado</returns>
        public static List<DegreeAllModel> GetDegree(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from degree in Contexto.Degrees where  degree.Status=="1" && degree.UserCreation.Equals(user)
                                 select new DegreeAllModel
                                 {
                                     Id = degree.DegreeID,
                                     Nombre = degree.Name
                                 }).ToList();
                return Resultado;
            }
        }

        /// <summary>
        /// Metodo que permite obtener las materias registradas
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo materia</returns>
        public static List<DegreeAllModel> GetSubject(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from subject in Contexto.Subjects where subject.Status == "1" && subject.UserCreation.Equals(user)
                                 select new DegreeAllModel
                                 {
                                     Id = subject.SubjectsID,
                                     Nombre = subject.Name
                                 }).ToList();
                return Resultado;
            }
        }

    }
}

