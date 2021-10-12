using System.Collections.Generic;
using System.Web.Mvc;
using System.Threading.Tasks;
using FrontEnd.Controllers.Base;
using Prueba.Negocio.Entidades;
using Prueba.Transversal;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class CursosController : BaseController
    {
        #region MetodosGet

        /// <summary>
        /// Carga la entrada grilla por primera vez
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            Models.Estudiante estudiante = new Models.Estudiante();
            estudiante.Cursos = await GetAsync<IEnumerable<Cursos>>("Cursos/ObtenerCursos");
            return View(estudiante);
        }

        /// <summary>
        /// Carga grilla despues de creacion o edicion
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> CargarGrilla()
        {
            Models.Estudiante estudiante = new Models.Estudiante();
            var lista = await GetAsync<IEnumerable<Cursos>>("Cursos/ObtenerCursos");
            return PartialView("_List", lista);
        }

        /// <summary>
        /// Muestra ventana de creación.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> VentanaCrear()
        {
            Cursos curso = new Cursos();
            return PartialView("_CrearEditar", curso);
        }

        /// <summary>
        /// Muestra ventana de edición
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Obtener(int Id)
        {
            Cursos curso = await GetAsync<Cursos>($"Curso/Obtener/{Id}");
            return PartialView("_CrearEditar", curso);
        }      
       
        #endregion

        #region MetodosPost

        public async Task<ActionResult> Actualizar(Cursos modelo)
        {
            
            var resultado = await PutAsync<Cursos, string>("Curso/Actualizar", modelo);
            if (string.IsNullOrEmpty(resultado))
            {
                return Json(new RespuestaViewModel { Correcto = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new RespuestaViewModel { Correcto = false, Mensaje = resultado }, JsonRequestBehavior.AllowGet);
            }

        }

        #endregion
    }
}