using System.Collections.Generic;
using System.Web.Mvc;
using System.Threading.Tasks;
using FrontEnd.Controllers.Base;
using Prueba.Negocio.Entidades;
using Prueba.Transversal;
using System.Linq;

namespace FrontEnd.Controllers
{
    public class DireccionesController : BaseController
    {
        #region MetodosGet
        /// <summary>
        /// Carga la entrada grilla por primera vez
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {
            var modelo = await GetAsync<IEnumerable<Direcciones>>("Direcciones/ObtenerDirecciones");
            return View(modelo);
        }

        /// <summary>
        /// Carga grilla despues de creacion o edicion
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> CargarGrilla()
        {
            var lista =  await GetAsync<IEnumerable<Direcciones>>("Direcciones/ObtenerDirecciones");
            return PartialView("_List", lista);
        }

        /// <summary>
        /// Muestra ventana de creación.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> VentanaCrear()
        {
            Direcciones modelo = new Direcciones();
            return PartialView("_CrearEditar", modelo);
        }

        public async Task<ActionResult> Insertar(Direcciones vehiculo)
        {
            var resultado = await PostAsync<Direcciones, string>("Direcciones/Insertar", vehiculo);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}