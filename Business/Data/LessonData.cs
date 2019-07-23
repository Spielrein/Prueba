using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class LessonData
    {
        /// <summary>
        /// Mtodoq que permite crear un horario
        /// </summary>
        /// <param name="Dia"></param>
        /// <param name="EmpleadoID"></param>
        /// <param name="HoraIn"></param>
        /// <param name="HoraFin"></param>
        /// <param name="AulaId"></param>
        /// <param name="MateriaId"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Crear(string Dia, int EmpleadoID, TimeSpan HoraIn, TimeSpan HoraFin, int AulaId, int MateriaId, string user)
        {
            AppTecBDEntities data = new AppTecBDEntities();
            Boolean existe = false;
            var s = new Lesson
            {
                Days = Dia,
                EmployersID = EmpleadoID,
                HousStart = HoraIn,
                HourFinish = HoraFin,
                ClassroomID = AulaId,
                SubjectsID = MateriaId,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1"
            };
            data.Lessons.Add(s);
            data.SaveChanges();

            if (s != null)
                existe = true;

            return existe;
        }

        /// <summary>
        /// Metodo que permite mostrar los horario sregistrados
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo horario</returns>
        public static List<LessonAllModel> Mostrar(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from lesson in Contexto.Lessons
                                     join empleado in Contexto.Employers on lesson.EmployersID equals empleado.EmployersID
                                     join aula in Contexto.Classrooms on lesson.ClassroomID equals aula.ClassroomID
                                     join materia in Contexto.Subjects on lesson.SubjectsID equals materia.SubjectsID
                                     //join gro in Contexto.Groups on lesson.GroupsID equals gro.GroupsID
                                     where lesson.Status == "1"
                                     select new LessonAllModel
                                     {
                                         Id = lesson.LessonsID,
                                         Dia = lesson.Days,
                                         EmpleadosNombre = empleado.Name,
                                         EmpleadoApp = empleado.LastNameP,
                                         EmpleadoApm = empleado.LastNameM,
                                         HoraIn = lesson.HousStart,
                                         HoraFin = lesson.HourFinish,
                                         AulaNombre = aula.Name,
                                         MateriaNombre = materia.Name
                                         //GrupoNombre = gro.Name
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from lesson in Contexto.Lessons
                                     join empleado in Contexto.Employers on lesson.EmployersID equals empleado.EmployersID
                                     join aula in Contexto.Classrooms on lesson.ClassroomID equals aula.ClassroomID
                                     join materia in Contexto.Subjects on lesson.SubjectsID equals materia.SubjectsID
                                     //join gro in Contexto.Groups on lesson.GroupsID equals gro.GroupsID
                                     where lesson.Status == "1" && lesson.UserCreation.Equals(user)
                                     select new LessonAllModel
                                     {
                                         Id = lesson.LessonsID,
                                         Dia = lesson.Days,
                                         EmpleadosNombre = empleado.Name,
                                         EmpleadoApp = empleado.LastNameP,
                                         EmpleadoApm = empleado.LastNameM,
                                         HoraIn = lesson.HousStart,
                                         HoraFin = lesson.HourFinish,
                                         AulaNombre = aula.Name,
                                         MateriaNombre = materia.Name
                                         //  GrupoNombre = gro.Name
                                     }).ToList();

                    return Resultado;
                }
            }
        }

        /// <summary>
        /// Metodo que permite mostrar datos de un horario segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Lista tipo horario</returns>
        public static List<LessonAllModel> MostrarActualizar(int id)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from lesson in Contexto.Lessons
                                 join empleado in Contexto.Employers on lesson.EmployersID equals empleado.EmployersID
                                 join aula in Contexto.Classrooms on lesson.ClassroomID equals aula.ClassroomID
                                 join materia in Contexto.Subjects on lesson.SubjectsID equals materia.SubjectsID
                                // join gro in Contexto.Groups on lesson.GroupsID equals gro.GroupsID
                                 where lesson.LessonsID == id
                                 select new LessonAllModel
                                 {
                                     Dia = lesson.Days,
                                     EmpleadosId = lesson.EmployersID,
                                     EmpleadosNombre = empleado.Name,
                                     HoraIn = lesson.HousStart,
                                     HoraFin = lesson.HourFinish,
                                     AulaId = lesson.ClassroomID,
                                     AulaNombre = aula.Name,
                                     MateriaId = lesson.SubjectsID,
                                     MateriaNombre = materia.Name,
                                    // GrupoId = lesson.Groups
                                    // GrupoNombre = gro.Name
                                 }).ToList();
                return Resultado;
            }
        }

        /// <summary>
        /// metodo que permite actualizar un horario segun su id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Dia"></param>
        /// <param name="EmpleadosId"></param>
        /// <param name="HoraIn"></param>
        /// <param name="HoraFin"></param>
        /// <param name="AulaId"></param>
        /// <param name="MateriaId"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Actualizar(int Id, string Dia, int EmpleadosId, TimeSpan HoraIn, TimeSpan HoraFin, int AulaId, int MateriaId, string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                Boolean existe = false;

                AppTecBDEntities data = new AppTecBDEntities();
                var consulta = data.Lessons.First(d => d.LessonsID == Id);
                if (consulta != null)
                {

                    consulta.Days = Dia;
                    consulta.EmployersID = EmpleadosId;
                    consulta.HousStart = HoraIn;
                    consulta.HourFinish = HoraFin;
                    consulta.ClassroomID = AulaId;
                    consulta.SubjectsID = MateriaId;
                  //  consulta.GroupsID = GrupoId;
                    consulta.DateTimeModification = DateTime.Now;
                    consulta.UserModification = user;
                    data.SaveChanges();
                    existe = true;
                }

                return existe;
            }

        }


        /// <summary>
        /// Metodoq ue permite eliminar un horario
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Eliminar(int Id)
        {
            Boolean existe = false;

            AppTecBDEntities data = new AppTecBDEntities();
            var consulta = data.Lessons.First(d => d.LessonsID == Id);
            if (consulta != null)
            {
                consulta.Status = "0";
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }

        /// <summary>
        /// Metodo que permite obtener los grupos registrados
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo grupos</returns>
        public static List<GroupAllModel> ObtenerGrupo(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from groups in Contexto.Groups
                                     where groups.Status == "1"
                                     select new GroupAllModel
                                     {
                                         Id = groups.GroupsID,
                                         Nombre = groups.Name
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from groups in Contexto.Groups
                                     where groups.Status == "1" && groups.UserCreation.Equals(user)
                                     select new GroupAllModel
                                     {
                                         Id = groups.GroupsID,
                                         Nombre = groups.Name
                                     }).ToList();
                    return Resultado;
                }
            }
        }

        /// <summary>
        /// Metodo que permite obtener las materias registradas
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo materias</returns>
        public static List<SubjectAllModel> ObtenerMateria(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from materia in Contexto.Subjects
                                     where materia.Status == "1"
                                     select new SubjectAllModel
                                     {
                                         Id = materia.SubjectsID,
                                         Nombre = materia.Name
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from materia in Contexto.Subjects
                                     where materia.Status == "1" && materia.UserCreation.Equals(user)
                                     select new SubjectAllModel
                                     {
                                         Id = materia.SubjectsID,
                                         Nombre = materia.Name
                                     }).ToList();
                    return Resultado;
                }
            }
        }


        /// <summary>
        /// Metodoq ue permite obtener las aulas registradas
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo aulas</returns>
        public static List<ClassroomAllModel> ObtenerAula(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from aula in Contexto.Classrooms
                                     where aula.Status == "1"
                                     select new ClassroomAllModel
                                     {
                                         Id = aula.ClassroomID,
                                         Clave = aula.Clave,
                                         Nombre = aula.Name
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from aula in Contexto.Classrooms
                                     where aula.Status == "1" && aula.UserCreation.Equals(user)
                                     select new ClassroomAllModel
                                     {
                                         Id = aula.ClassroomID,
                                         Clave = aula.Clave,
                                         Nombre = aula.Name
                                     }).ToList();
                    return Resultado;
                }
            }
        }

        /// <summary>
        /// Metodo que permite obtener los profesore sregistrados
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo profesores</returns>
        public static List<EmployerAllModel> ObtenerEmpleado(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from empleado in Contexto.Employers
                                     where empleado.Status == "1"
                                     select new EmployerAllModel
                                     {
                                         Id = empleado.EmployersID,
                                         Nombre = empleado.Name,
                                         Apellidop = empleado.LastNameP,
                                         Apellidom = empleado.LastNameM
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from empleado in Contexto.Employers
                                     where empleado.Status == "1" && empleado.UserCreation.Equals(user)
                                     select new EmployerAllModel
                                     {
                                         Id = empleado.EmployersID,
                                         Nombre = empleado.Name,
                                         Apellidop = empleado.LastNameP,
                                         Apellidom = empleado.LastNameM
                                     }).ToList();
                    return Resultado;
                }
            }
        }

        /// <summary>
        /// Metodo que permite mostrar los horarios registradosun dia especifico de la semana
        /// </summary>
        /// <param name="dia"></param>
        /// <param name="user"></param>
        /// <returns>Lista tipo horario</returns>
        public static List<LessonAllModel> GetDia(string dia, string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from lesson in Contexto.Lessons
                                     join empleado in Contexto.Employers on lesson.EmployersID equals empleado.EmployersID
                                     join materia in Contexto.Subjects on lesson.SubjectsID equals materia.SubjectsID
                                     join aula in Contexto.Classrooms on lesson.ClassroomID equals aula.ClassroomID
                                   // join gro in Contexto.Groups on lesson.GroupsID equals gro.GroupsID
                                     join degsub in Contexto.DegreeSubjects on materia.SubjectsID equals degsub.SubjectsID
                                     join deg in Contexto.Degrees on degsub.DegreeID equals deg.DegreeID

                                     where lesson.Days == dia
                                     select new LessonAllModel
                                     {
                                         EmpleadosNombre = empleado.Name,
                                         EmpleadoApp = empleado.LastNameP,
                                         EmpleadoApm = empleado.LastNameM,
                                         HoraIn = lesson.HousStart,
                                         HoraFin = lesson.HourFinish,
                                         AulaNombre = aula.Name,
                                         MateriaNombre = materia.Name,
                                       //  GrupoNombre = gro.Name,
                                         GradoNombre = deg.Name
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from lesson in Contexto.Lessons
                                     join empleado in Contexto.Employers on lesson.EmployersID equals empleado.EmployersID
                                     join materia in Contexto.Subjects on lesson.SubjectsID equals materia.SubjectsID
                                     join aula in Contexto.Classrooms on lesson.ClassroomID equals aula.ClassroomID
                                 //    join gro in Contexto.Groups on lesson.GroupsID equals gro.GroupsID
                                     join degsub in Contexto.DegreeSubjects on materia.SubjectsID equals degsub.SubjectsID
                                     join deg in Contexto.Degrees on degsub.DegreeID equals deg.DegreeID

                                     where lesson.Days == dia && lesson.UserCreation.Equals(user)
                                     select new LessonAllModel
                                     {
                                         EmpleadosNombre = empleado.Name,
                                         EmpleadoApp = empleado.LastNameP,
                                         EmpleadoApm = empleado.LastNameM,
                                         HoraIn = lesson.HousStart,
                                         HoraFin = lesson.HourFinish,
                                         AulaNombre = aula.Name,
                                         MateriaNombre = materia.Name,
                                   //      GrupoNombre = gro.Name,
                                         GradoNombre = deg.Name
                                     }).ToList();
                    return Resultado;
                }
            }
        }
    }
}