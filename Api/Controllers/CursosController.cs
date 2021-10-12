﻿using System;
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
    public class CursosController : BaseController
    {
        #region Declaraciones

        private readonly INegocioCursos _servicio;

        #endregion

        #region Constructor

        public CursosController(INegocioCursos servicio)
        {
            _servicio = servicio;
        }

        #endregion

        #region Metodos

        [HttpGet]
        [Route("api/Cursos/Obtener/{id}")]
        public HttpResponseMessage ObtenerLista(int id)
        {
           
                var resultado = _servicio.Obtener(id);
                return resultado == null ? Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MensajeSinInformacion)
                                         : Request.CreateResponse(HttpStatusCode.OK, resultado);
            
        }

        [HttpGet]
        [Route("api/Cursos/ObtenerCursos")]
        public HttpResponseMessage ObtenerCursos()
        {
            
                var resultado = _servicio.ObtenerTodos();
                return resultado == null ? Request.CreateResponse(HttpStatusCode.NotFound, Mensajes.MensajeSinInformacion)
                                         : Request.CreateResponse(HttpStatusCode.OK, resultado);
                     
        }

        [HttpPost]
        [Route("api/Cursos/Insertar")]
        public HttpResponseMessage Insertar(Cursos modelo)
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
        [Route("api/Cursos/Actualizar")]
        public HttpResponseMessage Actualizar(Cursos modelo)
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

        #endregion
    }
}
