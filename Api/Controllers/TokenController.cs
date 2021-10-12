using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Prueba.Negocio.Entidades;
using Prueba.Negocio.Interfaces;
using Api.Controllers.Base;
using Prueba.Transversal;
using Api.Models;

namespace Api.Controllers
{

    public class TokenController : BaseController
    {

        [AllowAnonymous]
        [RoutePrefix("api/token")]
        public class LoginController : ApiController
        {
           
            [HttpPost]
            [Route("Generartoken")]
            public IHttpActionResult Generartoken(Login usuario)
            {
               var token = GenerateTokenJwt(usuario.Usuario);
                return Ok(token);
               
            }
        }

    }
}
