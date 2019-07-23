using Business.Data.Api;
using Business.Model.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ApiRest.Controllers.Api
{
    [RoutePrefix("Api/Class")]
    public class CloseSession:ApiController
    {
        /// <summary>
        /// Controlador para cerrar sesión desde la aplicación móvil
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Estado false</returns>
        [HttpPost]
        [Route("cerrar")]
        public IHttpActionResult Cerrar(TokenModel token)
        {

            TokenData.InvalidarToken(token.Token);

            return BadRequest();
        }
    }
}