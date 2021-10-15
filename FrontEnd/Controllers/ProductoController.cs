using System.Collections.Generic;
using System.Web.Mvc;
using System.Threading.Tasks;
using FrontEnd.Controllers.Base;
using Prueba.Negocio.Entidades;
using Prueba.Transversal;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class ProductoController : BaseController
    {
        #region MetodosGet

        /// <summary>
        /// Carga la entrada grilla por primera vez
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> Index()
        {

            Login login = new Login();
            login.Contrasena = "Prueba";
            login.Usuario = "Prueba";
            var token = PostAsync<Login, string>("token/Generartoken", login, string.Empty);
            IEnumerable<Producto> productos = await GetAsync<IEnumerable<Producto>>("Producto/ObtenerProductos", token.ToString());
            return View(productos);
        }

        /// <summary>
        /// Carga grilla despues de creacion o edicion
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> CargarGrilla()
        {
            Login login = new Login();
            login.Contrasena = "Prueba";
            login.Usuario = "Prueba";
            var token = PostAsync<Login, string>("token/Generartoken", login, string.Empty);
            IEnumerable<Producto> productos =  await GetAsync<IEnumerable<Producto>>("Producto/ObtenerProductos", token.ToString());
            return PartialView("_List", productos);
        }

        /// <summary>
        /// Muestra ventana de creación.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> VentanaCrear()
        {
            Producto producto = new Producto();
            return PartialView("_CrearEditar", producto);
        }

        /// <summary>
        /// Muestra ventana de edición
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<ActionResult> Obtener(int Id)
        {
            Login login = new Login();
            login.Contrasena = "Prueba";
            login.Usuario = "Prueba";
            var token = PostAsync<Login, string>("token/Generartoken", login, string.Empty);
            Producto producto = await GetAsync<Producto>($"Producto/Obtener/{Id}", token.ToString());
            return PartialView("_CrearEditar", producto);
        }      
       
        #endregion

        #region MetodosPost

        public async Task<ActionResult> Actualizar(Producto modelo)
        {
            
            var resultado = await PutAsync<Producto, string>("Curso/Actualizar", modelo);
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