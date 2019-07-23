using Business.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using Microsoft.AspNet.Identity;
using ApiRest.Models;

namespace ApiRest.Controllers
{
    [RoutePrefix("Api/Login")]
    public class LoginController : ApiController
    {
        /// <summary>
        /// Controlador que permite authtnticar al usuario que ingresa
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        [HttpPost]
        [Route("Authenticate")]
        public IHttpActionResult Sign([FromBody]UserModel user)
        {
            Boolean Existe = false;


            Existe = UserData.ExisteUsuario(user.User, user.Password);
            if (Existe == true)
            {
                //token falta
                user.User = User.Identity.GetUserId();

                
            }
            return NotFound();
        }

        /// <summary>
        /// Controlador que permite cerrar sesion del portal
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Estado de la consulta true/false</returns>
        [HttpPost]
        [Route("Logout")]
        public IHttpActionResult Out([FromBody]UserModel user)
        {
            //Invalidar token
            return BadRequest();
        }

        
    }
}
