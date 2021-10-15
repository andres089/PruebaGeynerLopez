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
    [Authorize]
    public class FacturaController : BaseController
    {
        #region Declaraciones

        private readonly INegocioFactura _servicio;

        #endregion

        #region Constructor

        public FacturaController(INegocioFactura servicio)
        {
            _servicio = servicio;
        }

        #endregion

        #region Metodos

        [HttpPost]
        [Route("api/Factura/Insertar")]
        public HttpResponseMessage Insertar(Factura modelo)
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
                Utilidades.RegistrarError(ex, "FacturaController_Insertar");
                return Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MensajeIncidencia);
            }
        }

        [HttpGet]
        [Route("api/Factura/ObtenerFactura")]
        public HttpResponseMessage ObtenerFactura()
        {
            
            var resultado = _servicio.ObtenerTodos();
            return resultado != null ? Request.CreateResponse(HttpStatusCode.OK, resultado)
                                        : Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MensajeSinInformacion);
            
        }
       
        [HttpGet]
        [Route("api/Factura/Obtener/{id}")]
        public HttpResponseMessage Obtener(int id)
        {
            
            var resultado = _servicio.Obtener(id);
            return resultado != null ? Request.CreateResponse(HttpStatusCode.OK, resultado)
                                        : Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MensajeSinInformacion);
            
        }

        #endregion
    }
}
