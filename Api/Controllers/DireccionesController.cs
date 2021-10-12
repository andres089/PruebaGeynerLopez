using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Prueba.Negocio.Entidades;
using Prueba.Negocio.Interfaces;
using Api.Controllers.Base;
using Prueba.Transversal;

namespace Api.Controllers
{
    [AllowAnonymous]
    public class DireccionesController : BaseController
    {
        #region Declaraciones
        private readonly INegocioDirecciones _servicio;
        #endregion

        #region Constructor

        public DireccionesController(INegocioDirecciones servicio)
        {
            _servicio = servicio;
        }

        #endregion

        #region Metodos

        [HttpPost]
        [Route("api/Direcciones/Insertar")]
        public HttpResponseMessage Insertar(Direcciones modelo)
        {
            string mensaje = string.Empty;
            try
            {
                
                var resultado = _servicio.Crear(modelo, out mensaje);
                return resultado == 0 ? Request.CreateResponse(HttpStatusCode.NotFound, mensaje)
                                        : Request.CreateResponse(HttpStatusCode.OK, "");
               
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(ex, "VehiculoConductorController_Insertar");
                return Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MensajeIncidencia);
            }
        }

        [HttpGet]
        [Route("api/Direcciones/ObtenerDirecciones")]
        public HttpResponseMessage ObtenerDirecciones()
        {
            
                var resultado = _servicio.ObtenerTodos();
                return resultado != null ? Request.CreateResponse(HttpStatusCode.OK, resultado)
                                         : Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MensajeSinInformacion);
            
        }

        #endregion
    }
}
