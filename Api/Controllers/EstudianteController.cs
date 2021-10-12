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
    public class EstudianteController : BaseController
    {
        #region Declaraciones

        private readonly INegocioEstudiante _servicio;

        #endregion

        #region Constructor

        public EstudianteController(INegocioEstudiante servicio)
        {
            _servicio = servicio;
        }

        #endregion

        #region Metodos

        [HttpPost]
        [Route("api/Estudiante/Insertar")]
        public HttpResponseMessage Insertar(Estudiante modelo)
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
                Utilidades.RegistrarError(ex, "PersonaController_Insertar");
                return Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MensajeIncidencia);
            }
        }

        [HttpPut]
        [Route("api/Estudiante/Actualizar")]
        public HttpResponseMessage Actualizar(Estudiante modelo)
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
                Utilidades.RegistrarError(ex, "PersonaController_Actualizar");
                return Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MensajeIncidencia);
            }
        }

        [HttpGet]
        [Route("api/Estudiante/ObtenerEstudiantes")]
        public HttpResponseMessage ObtenerEstudiantes()
        {
            
            var resultado = _servicio.ObtenerTodos();
            return resultado != null ? Request.CreateResponse(HttpStatusCode.OK, resultado)
                                        : Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MensajeSinInformacion);
            
        }
       
        [HttpGet]
        [Route("api/Estudiante/Obtener/{id}")]
        public HttpResponseMessage Obtener(int id)
        {
            
            var resultado = _servicio.Obtener(id);
            return resultado != null ? Request.CreateResponse(HttpStatusCode.OK, resultado)
                                        : Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MensajeSinInformacion);
            
        }

        #endregion
    }
}
