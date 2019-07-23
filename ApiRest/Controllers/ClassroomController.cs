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
    [RoutePrefix("Api/Classroom")]
    public class ClassroomController : ApiController
    {
        Credenciales credenciales = new Credenciales();
        public string u;

        /// <summary>
        /// Controlador que permite crear un aula
        /// </summary>
        /// <param name="classroom"></param>
        /// <returns>Estado de la consulta true/false</returns>

        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]ClassroomModel classroom)
        {
            u = credenciales.getUsuario();
     
            var consulta = ClassroomData.Crear(classroom.Clave,classroom.Nombre,classroom.Descripcion,classroom.Institucion,classroom.TipoAula,u);
            return Ok(consulta);
        }


        /// <summary>
        /// Controlador que permite mostrar las aulas registradas
        /// </summary>
        /// <param name="classroom"></param>
        /// <returns>Lista de aulas</returns>
        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            u = credenciales.getUsuario();
            

            var consulta = ClassroomData.Mostrar(u);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que muestra infromación especifica de un aula segun su id
        /// </summary>
        /// <param name="classroom"></param>
        /// <returns>Lista de aulas</returns>

        [HttpPost]
        [Route("ShowUpdate")]
        public IHttpActionResult ShowUpdate(ClassroomModel classroom)
        {
            var consulta = ClassroomData.MostrarUpdate(classroom.ClassroomId);
            return Ok(consulta);
        }


        /// <summary>
        /// Controlador que permite actualizar un aula especifica segun su id
        /// </summary>
        /// <param name="classroom"></param>
        /// <returns>Estado de la consulta true/false</returns>

        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update(ClassroomModel classroom)
        {
            u = credenciales.getUsuario();
           
            var consulta = ClassroomData.Atualizar(classroom.ClassroomId, classroom.Clave, classroom.Nombre, classroom.Descripcion, classroom.Institucion, classroom.TipoAula,u);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite eliminar un aula segun su id
        /// </summary>
        /// <param name="classroom"></param>
        /// <returns>Estado de la consulta true/false</returns>
        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(ClassroomModel classroom)
        {
            var consulta = ClassroomData.Eliminar(classroom.ClassroomId);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite mostrar los tipos de aulas registrados
        /// </summary>
        /// <returns>Lista de tipo de aulas</returns>
        [HttpPost]
        [Route("ShowClassroomType")]
        public IHttpActionResult ShowClassroomType()
        {
            var consulta = ClassroomData.ObtenerAula();
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite mostrar las instituciones registradas
        /// </summary>
        /// <returns>Lista de instituciones</returns>
        [HttpPost]
        [Route("ShowInstitution")]
        public IHttpActionResult ShowInstitution()
        {
            u = credenciales.getUsuario();
            var consulta = ClassroomData.ObtenerInstitucion(u);
            return Ok(consulta);
        }
    }
}
