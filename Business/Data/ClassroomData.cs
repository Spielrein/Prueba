using Business.Model;
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Business.Data
{
    public class ClassroomData
    {
        /// <summary>
        /// MEtodo que permite crear un aula
        /// </summary>
        /// <param name="clave"></param>
        /// <param name="nombre"></param>
        /// <param name="descripcion"></param>
        /// <param name="intitutoId"></param>
        /// <param name="tipoAula"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Crear(string clave, string nombre, string descripcion, int intitutoId, int tipoAula, string user)
        {
            AppTecBDEntities data = new AppTecBDEntities();
            Boolean existe = false;
            var c = new Classroom
            {
                Clave = clave,
                Name = nombre,
                Description = descripcion,
                InstitutionID = intitutoId,
                ClassRoomTypeID = tipoAula,
                DateTimeCreation = DateTime.Now,
                DateTimeModification = DateTime.Now,
                UserCreation = user,
                UserModification = user,
                Status = "1"
            };
            data.Classrooms.Add(c);
            data.SaveChanges();

            if (c != null)
                existe = true;


            return existe;
        }
       
        /// <summary>
        /// Metodo que permite mostrar todas las aulas
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo aula</returns>
        public static List<ClassroomAllModel> Mostrar(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                if (user.Equals("SuperPowerUser"))
                {
                    var Resultado = (from classroom in Contexto.Classrooms
                                     join institucion in Contexto.Institutions
                                     on classroom.InstitutionID equals institucion.InstitutionID
                                     join classroomtype in Contexto.ClassRoomTypes on classroom.ClassRoomTypeID equals classroomtype.ClassRoomTypeID
                                     where classroom.Status == "1"
                                     select new ClassroomAllModel
                                     {
                                         Id = classroom.ClassroomID,
                                         Clave = classroom.Clave,
                                         Nombre = classroom.Name,
                                         Descripcion = classroom.Description,
                                         InstitucionNombre = institucion.Name,
                                         NombreAula = classroomtype.Name,
                                     }).ToList();
                    return Resultado;
                }
                else
                {
                    var Resultado = (from classroom in Contexto.Classrooms
                                     join institucion in Contexto.Institutions
                                     on classroom.InstitutionID equals institucion.InstitutionID
                                     join classroomtype in Contexto.ClassRoomTypes on classroom.ClassRoomTypeID equals classroomtype.ClassRoomTypeID
                                     where classroom.Status == "1" && classroom.UserCreation.Equals(user)
                                     select new ClassroomAllModel
                                     {
                                         Id = classroom.ClassroomID,
                                         Clave = classroom.Clave,
                                         Nombre = classroom.Name,
                                         Descripcion = classroom.Description,
                                         InstitucionNombre = institucion.Name,
                                         NombreAula = classroomtype.Name,
                                     }).ToList();
                    return Resultado;
                }

            }
        }


        /// <summary>
        /// Metodo que muestra informacion de un aula segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Lista tipo aula</returns>
        public static List<ClassroomAllModel> MostrarUpdate(int id)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from classroom in Contexto.Classrooms
                                 join institucion in Contexto.Institutions
                                 on classroom.InstitutionID equals institucion.InstitutionID
                                 join classroomtype in Contexto.ClassRoomTypes on classroom.ClassRoomTypeID equals classroomtype.ClassRoomTypeID
                                 where classroom.ClassroomID==id
                                 select new ClassroomAllModel
                                 {
                                     Id = classroom.ClassroomID,
                                     Clave = classroom.Clave,
                                     Nombre = classroom.Name,
                                     Descripcion = classroom.Description,
                                     InstitucionId=institucion.InstitutionID,
                                     InstitucionNombre = institucion.Name,
                                     TipoAula=classroom.ClassRoomTypeID,
                                     NombreAula = classroomtype.Name
                                 }).ToList();
                return Resultado;
            }
        }

        /// <summary>
        /// Metodo que permite actualizar un aula segun su id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Clave"></param>
        /// <param name="Nombre"></param>
        /// <param name="Descripcion"></param>
        /// <param name="InstitucionId"></param>
        /// <param name="TipoAula"></param>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Atualizar(int Id, string Clave, string Nombre, string Descripcion, int InstitucionId, int TipoAula, string user)
        {
            Boolean existe = false;

            AppTecBDEntities data = new AppTecBDEntities();
            var consulta = data.Classrooms.First(d => d.ClassroomID == Id);
            if (consulta != null)
            {
                consulta.Clave = Clave;
                consulta.Name = Nombre;
                consulta.Description = Descripcion;
                consulta.InstitutionID = InstitucionId;
                consulta.ClassRoomTypeID = TipoAula;
                consulta.DateTimeModification = DateTime.Now;
                consulta.UserModification = user;
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }


        /// <summary>
        /// Metodo que permite eliminar un aula segun su id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Estado de la consulta true/false</returns>
        public static Boolean Eliminar(int Id)
        {
            Boolean existe = false;

            AppTecBDEntities data = new AppTecBDEntities();
            var consulta = data.Classrooms.First(d => d.ClassroomID == Id);
            if (consulta != null)
            {
                consulta.Status = "0";
                data.SaveChanges();
                existe = true;
            }

            return existe;
        }

        /// <summary>
        /// Metodo que permite mostrar las aulas registradas
        /// </summary>
        /// <returns>Lista tipo aula</returns>
        public static List<ClassroomTypeAllModel> ObtenerAula()
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from classroomType in Contexto.ClassRoomTypes 
                                 select new ClassroomTypeAllModel
                                 {
                                     Id=classroomType.ClassRoomTypeID,
                                     Nombre = classroomType.Name
                                 }).ToList();
                return Resultado;
            }
        }

        /// <summary>
        /// Metodo que permite mostrar las instituciones registradas
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Lista tipo instituciones</returns>
        public static List<InstitutionAllModel> ObtenerInstitucion(string user)
        {
            using (var Contexto = new AppTecBDEntities())
            {
                var Resultado = (from Institution in Contexto.Institutions where Institution.Status=="1" && Institution.UserCreation.Equals(user)

                                 select new InstitutionAllModel
                                 {
                                     Id = Institution.InstitutionID,
                                     Nombre = Institution.Name
                                 }).ToList();
                return Resultado;
            }
        }
    }
}