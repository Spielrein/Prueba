using ApiRest.Models;
using ApiRest.Providers;
using Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRest.Controllers
{
    [RoutePrefix("Api/Student")]
    public class StudentController : ApiController
    {
        Credenciales credenciales = new Credenciales();
        public string u;
        public string c;

        /// <summary>
        /// Controlador que permite crear un estudiante
        /// </summary>
        /// <param name="student"></param>
        /// <returns>Estado de la consulta true/false</returns>
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]StudentModel student)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = StudentData.Crear(student.Matricula, student.Nombre, student.Apellidop, student.Apellidom, student.Telefono, student.InstitucionId, student.GrupoId, student.Grado, u);
            return Ok(consulta);
        }

       /// <summary>
       /// Controlador que permite mostrar los estudiantes registrados
       /// </summary>
       /// <returns>Lista de tipo estudiantes</returns>
        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = StudentData.Mostrar(u);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite mostrar informacion de un estudiantes segun su id
        /// </summary>
        /// <param name="student"></param>
        /// <returns>Lista de tipo estudiante</returns>
        [HttpPost]
        [Route("ShowUpdate")]
        public IHttpActionResult ShowUpdate(StudentModel student)
        {
            var consulta = StudentData.MostrarActualizar(student.StudentId);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite actualizar un estudiante segun su id
        /// </summary>
        /// <param name="student"></param>
        /// <returns>Estado de la consulta true/false</returns>
        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update(StudentModel student)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = StudentData.Actualizar(student.StudentId, student.Matricula, student.Nombre, student.Apellidop, student.Apellidom, student.Telefono, student.InstitucionId, student.GrupoId, student.Grado,u);
            return Ok(consulta);
        }

        /// <summary>
        /// ontrolador que permite eliminar un estudiante segun su id
        /// </summary>
        /// <param name="student"></param>
        /// <returns>Estado de la consulta true/false</returns>
        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(StudentModel student)
        {
            var consulta = StudentData.Eliminar(student.StudentId);
            return Ok(consulta);
        }

        /// <summary>
        /// Controladro que permite mostrar los grupos registrados
        /// </summary>
        /// <returns>Lista de tipo grupos</returns>
        [HttpPost]
        [Route("ShowGroup")]
        public IHttpActionResult ShowGroup()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = StudentData.ObtenerGroup(u);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite mostra los grados registrados
        /// </summary>
        /// <returns>Lista de tipo grados</returns>
        [HttpPost]
        [Route("ShowDegree")]
        public IHttpActionResult ShowDegree()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = StudentData.ObtenerGrado(u);
            return Ok(consulta);
        }
    }
}
