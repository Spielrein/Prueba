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
    [RoutePrefix("Api/Employer")]
    public class EmployerController : ApiController
    {
        Credenciales credenciales = new Credenciales();
        public string u;
        public string c;

        /// <summary>
        /// Controlador que permite crear un profesor
        /// </summary>
        /// <param name="employer"></param>
        /// <returns>Estado de la consulta true/false</returns>
        [HttpPost]
        [Route("Create")]
        public IHttpActionResult Create([FromBody]EmployerModel employer)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = EmployerData.Crear(employer.Nombre, employer.Apellidop, employer.Apellidom, employer.Rfc, employer.RolesId, employer.InstitucionId,u);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite mostrar los profesores reistrados 
        /// </summary>
        /// <returns>Lista de profesores</returns>
        [HttpPost]
        [Route("Show")]
        public IHttpActionResult Show()
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = EmployerData.Mostrar(u);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite mostrar informacion de un profesor segun su id
        /// </summary>
        /// <param name="employer"></param>
        /// <returns>Lista de tipo profesor</returns>
        [HttpPost]
        [Route("ShowUpdate")]
        public IHttpActionResult ShowActualizar(EmployerModel employer)
        {
            var consulta = EmployerData.MostrarActualizar(employer.EmployerId);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite actualizar un profesor
        /// </summary>
        /// <param name="employer"></param>
        /// <returns>Estado de la consulta true/false</returns>
        [HttpPost]
        [Route("Update")]
        public IHttpActionResult Update(EmployerModel employer)
        {
            u = credenciales.getUsuario();
            c = credenciales.getUsuario();
            var consulta = EmployerData.Actualizar(employer.EmployerId, employer.Nombre, employer.Apellidop, employer.Apellidom, employer.Rfc, employer.RolesId, employer.InstitucionId,u);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite eliminar un profesor segun su id
        /// </summary>
        /// <param name="employer"></param>
        /// <returns>Estado de la consulta true/false</returns>
        [HttpPost]
        [Route("Delete")]
        public IHttpActionResult Delete(EmployerModel employer)
        {
            var consulta = EmployerData.Eliminar(employer.EmployerId);
            return Ok(consulta);
        }

        /// <summary>
        /// Controlador que permite mostrar los roles registrados
        /// </summary>
        /// <returns>Lista de roles</returns>
        [HttpPost]
        [Route("ShowRol")]
        public IHttpActionResult ShowRol()
        {
            var consulta = EmployerData.ObtenerRol();
            return Ok(consulta);
        }
        
    }
}

