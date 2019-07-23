using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class StudentData
    {
        /// <summary>
        /// Metodo para crear un estudiante
        /// </summary>
        /// <param name="Matricula"></param>
        /// <param name="Nombre"></param>
        /// <param name="Apellidop"></param>
        /// <param name="Apellidom"></param>
        /// <param name="Telefono"></param>
        /// <param name="InstitucionId"></param>
        /// <param name="GrupoId"></param>
        /// <param name="Grado"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Crear(string Matricula, string Nombre, string Apellidop, string Apellidom, string Telefono, int InstitucionId, int GrupoId, int Grado, string user)
        {
            AppTecBDEntities data = new AppTecBDEntities();
            Boolean existe = false;
            var s = new Student
            {
                Enrollment=Matricula,
                Name = Nombre,
                LastNameP=Apellidop,
                LastNameM=Apellidom,
                Phone=Telefono,
                InstitutionID=InstitucionId,
                GroupsID=GrupoId,
                Password=Matricula,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1",
                DegreeId=Grado
                
            };
            data.Students.Add(s);
            data.SaveChanges();

            if (s != null)
                existe = true;

            return existe;
        }


        /// <summary>
        /// Metodo para mostrar los estudiantes registrados
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo estudiantes</returns>
        public static List<StudentAllModel> Mostrar(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from student in Contexto.Students
                                     join inst in Contexto.Institutions on student.InstitutionID equals inst.InstitutionID
                                     join gro in Contexto.Groups on student.GroupsID equals gro.GroupsID
                                     join gra in Contexto.Degrees on student.DegreeId equals gra.DegreeID
                                     where student.Status == "1" 
                                     select new StudentAllModel
                                     {
                                         Id = student.StudentsID,
                                         Matricula = student.Enrollment,
                                         Nombre = student.Name,
                                         Apellidop = student.LastNameP,
                                         Apellidom = student.LastNameM,
                                         Telefono = student.Phone,
                                         InstitucionNombre = inst.Name,
                                         GrupoNombre = gro.Name,
                                         GradoNombre = gra.Name,
                                         Password = student.Password
                                         
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from student in Contexto.Students
                                     join inst in Contexto.Institutions on student.InstitutionID equals inst.InstitutionID
                                     join gro in Contexto.Groups on student.GroupsID equals gro.GroupsID
                                     where student.Status == "1" && student.UserCreation.Equals(user)
                                     join gra in Contexto.Degrees on student.DegreeId equals gra.DegreeID
                                     select new StudentAllModel
                                     {
                                         Id = student.StudentsID,
                                         Matricula = student.Enrollment,
                                         Nombre = student.Name,
                                         Apellidop = student.LastNameP,
                                         Apellidom = student.LastNameM,
                                         Telefono = student.Phone,
                                         InstitucionNombre = inst.Name,
                                         GrupoNombre = gro.Name,
                                         GradoNombre = gra.Name,
                                         Password = student.Password

                                     }).ToList();
                    return Resultado;
                }
            }
        }


        /// <summary>
        /// Metodo que permite mostrar datos de los estudiantes segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Lista tipo estudintes</returns>
        public static List<StudentAllModel> MostrarActualizar(int id)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from student in Contexto.Students
                                 join inst in Contexto.Institutions on student.InstitutionID equals inst.InstitutionID
                                 join gro in Contexto.Groups on student.GroupsID equals gro.GroupsID
                                 join gra in Contexto.Degrees on student.DegreeId equals gra.DegreeID
                                 where student.StudentsID==id
                                 select new StudentAllModel
                                 {
                                     Id = student.StudentsID,
                                     Matricula = student.Enrollment,
                                     Nombre = student.Name,
                                     Apellidop = student.LastNameP,
                                     Apellidom = student.LastNameM,
                                     Telefono = student.Phone,
                                     InstitucionId=student.InstitutionID,
                                     InstitucionNombre = inst.Name,
                                     GrupoId=student.GroupsID,
                                     GrupoNombre = inst.Name,
                                     Password = student.Password,
                                     GradoId = gra.DegreeID,
                                     GradoNombre=gra.Name

                                 }).ToList();
                return Resultado;
            }
        }

        /// <summary>
        /// Metodo que permite actualizar un estudiantes egun su id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Matricula"></param>
        /// <param name="Nombre"></param>
        /// <param name="Apellidop"></param>
        /// <param name="Apellidom"></param>
        /// <param name="Telefono"></param>
        /// <param name="InstitucionId"></param>
        /// <param name="GrupoId"></param>
        /// <param name="grado"></param>
        /// <param name="user"></param>
        /// <returns>Lista tipo estudiantes</returns>
        public static Boolean Actualizar(int Id, string Matricula, string Nombre, string Apellidop, string Apellidom, string Telefono, int InstitucionId, int GrupoId, int grado, string user)
        {
            Boolean existe = false;

            AppTecBDEntities data = new AppTecBDEntities();
            var consulta = data.Students.First(d => d.StudentsID == Id);
            if (consulta != null)
            {
                consulta.Enrollment=Matricula;
                consulta.Name =Nombre;
                consulta.LastNameP = Apellidop;
                consulta.LastNameM = Apellidom;
                consulta.Phone = Telefono;
                consulta.InstitutionID = InstitucionId;
                consulta.GroupsID = GrupoId;
                // consulta.Password = student.Password;
                consulta.DegreeId = grado;
                consulta.DateTimeModification = DateTime.Now;
                consulta.UserModification = user;
                
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }

        /// <summary>
        /// Metodo que ermite eliminar un estudiante segun su id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Eliminar(int Id)
        {
            Boolean existe = false;

            AppTecBDEntities data = new AppTecBDEntities();
            var consulta = data.Students.First(d => d.StudentsID == Id);
            if (consulta != null)
            {
                consulta.Status = "0";
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }

        /// <summary>
        /// Metodo que permite mostrar los grupos registrados
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo grupos</returns>
        public static List<GroupAllModel> ObtenerGroup(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from groups in Contexto.Groups where groups.Status=="1" && groups.UserCreation.Equals(user)
                                 select new GroupAllModel
                                 {
                                     Id = groups.GroupsID,
                                     Nombre = groups.Name
                                 }).ToList();
                return Resultado;
            }
        }

        /// <summary>
        /// Metodo que permite mostrar los f¿grados registrados
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo grados</returns>
        public static List<DegreeAllModel> ObtenerGrado(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from degree in Contexto.Degrees
                                 where degree.Status == "1" && degree.UserCreation.Equals(user)
                                 select new DegreeAllModel
                                 {
                                     Id = degree.DegreeID,
                                     Nombre = degree.Name
                                 }).ToList();
                return Resultado;
            }
        }

    }
}