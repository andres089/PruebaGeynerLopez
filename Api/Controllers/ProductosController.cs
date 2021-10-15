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

namespace Api.Controllers
{
    [AllowAnonymous]
    public class ProductosController : BaseController
    {
        #region Declaraciones

        private readonly INegocioProducto _servicio;

        #endregion

        #region Constructor

        public ProductosController(INegocioProducto servicio)
        {
            _servicio = servicio;
        }

        #endregion

        #region Metodos

        [HttpGet]
        [Route("api/Productos/Obtener/{id}")]
        public HttpResponseMessage ObtenerLista(int id)
        {
           
                var resultado = _servicio.Obtener(id);
                return resultado == null ? Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MensajeSinInformacion)
                                         : Request.CreateResponse(HttpStatusCode.OK, resultado);
            
        }

        [HttpGet]
        [Route("api/Productos/ObtenerProductos")]
        public HttpResponseMessage ObtenerProductos()
        {
            
                var resultado = _servicio.ObtenerTodos();
                return resultado == null ? Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MensajeSinInformacion)
                                         : Request.CreateResponse(HttpStatusCode.OK, resultado);
                     
        }

        [HttpPost]
        [Route("api/Productos/Insertar")]
        public HttpResponseMessage Insertar(Producto modelo)
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
                Utilidades.RegistrarError(ex, "ProductosController_Insertar");
                return Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MensajeIncidencia);
            }
        }

        [HttpPut]
        [Route("api/Productos/Actualizar")]
        public HttpResponseMessage Actualizar(Producto modelo)
        {
            string mensaje = string.Empty;
            try
            {
                var resultado = _servicio.Actualizar(modelo, out mensaje);
                return resultado ? Request.CreateResponse(HttpStatusCode.OK, "")
                                     : Request.CreateResponse(HttpStatusCode.NotFound, mensaje);
                
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(ex, "ProductoController_Actualizar");
                return Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MensajeIncidencia);
            }
        }

        #endregion
    }
}
