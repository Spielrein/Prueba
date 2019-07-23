using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiRest.Models;
using ApiRest.Providers;
using Business.Data;


namespace ApiRest.Controllers
{
    [RoutePrefix("Api/Binnacle")]
    public class BinnacleController : ApiController
    {

        Credenciales credenciales = new Credenciales();
        public string u;
        /// <summary>
        /// Controlador que permite insertar datos en la tabla bitacora
        /// </summary>
        /// <param name="binnacle"></param>
        /// <returns>Estado de la consulta true/false</returns>

        [HttpPost]
        [Route("Info")]
        public IHttpActionResult Create([FromBody]BinnacleModel binnacle)
        {
            u = credenciales.getUsuario();
            
            var consulta = BinnacleData.Recibir(binnacle.Accion, binnacle.Error, binnacle.Msj, u);
            return Ok(consulta);
        }

    }
}
