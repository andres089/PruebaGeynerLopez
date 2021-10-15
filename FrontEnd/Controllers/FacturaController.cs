using System.Collections.Generic;
using System.Web.Mvc;
using System.Threading.Tasks;
using FrontEnd.Controllers.Base;
using Prueba.Negocio.Entidades;
using Prueba.Transversal;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class FacturaController : BaseController
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
            var modelo = await GetAsync<IEnumerable<Models.Factura>>("Factura/ObtenerFacturas", token.ToString());
            return View(modelo);
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
            var lista = await GetAsync<IEnumerable<Models.Factura>>("Factura/ObtenerFacturas", token.Result.ToString());
            return PartialView("_List", lista);
        }

        /// <summary>
        /// Muestra ventana de creación.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> VentanaCrear()
        {
            Models.Factura factura = new Models.Factura();
            Login login = new Login();
            login.Contrasena = "Prueba";
            login.Usuario = "Prueba";
            var token = PostAsync<Login, string>("token/Generartoken", login, string.Empty);
            factura.Productos = await GetAsync<IEnumerable<Producto>>("Producto/ObtenerProductos", token.ToString());
            List<MedioPago> mediosPago = new List<MedioPago>();
            MedioPago medioPago = new MedioPago();
            medioPago.IdMedioPago = 1;
            medioPago.Descripcion = "Efectivo";
            mediosPago.Add(medioPago);
            MedioPago medioPago1 = new MedioPago();
            medioPago1.IdMedioPago = 2;
            medioPago1.Descripcion = "Tarjeta";
            mediosPago.Add(medioPago1);
            factura.medioPagos = mediosPago;
            return PartialView("_CrearEditar", factura);
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
            var factura = await GetAsync<Models.Factura>($"Factura/Obtener/{Id}", token.ToString());
            List<MedioPago> mediosPago = new List<MedioPago>();
            MedioPago medioPago = new MedioPago();
            medioPago.IdMedioPago = 1;
            medioPago.Descripcion = "Efectivo";
            mediosPago.Add(medioPago);
            MedioPago medioPago1 = new MedioPago();
            medioPago1.IdMedioPago = 2;
            medioPago1.Descripcion = "Tarjeta";
            mediosPago.Add(medioPago1);
            factura.medioPagos = mediosPago;
            return PartialView("_CrearEditar", factura);
        }


        public async Task<ActionResult> Insertar(Models.Factura modelo)
        {
            Prueba.Negocio.Entidades.Factura factura = new Prueba.Negocio.Entidades.Factura();
            factura.NombreCliente = modelo.NombreCliente;
            factura.DocumentoCliente = modelo.DocumentoCliente;
            factura.NumeroFactura = string.Concat("Cod:", modelo.DocumentoCliente);
            factura.Descuento = modelo.Descuento;
            factura.Subtotal = modelo.Subtotal;
            factura.TipoPago = modelo.TipoPago;
            factura.Total = modelo.Total;
            factura.TotalDescuento = modelo.TotalDescuento;
            factura.TotalImpuesto = modelo.TotalImpuesto;
            factura.Iva = modelo.Iva;
            factura.Fecha = System.DateTime.Now;
                       
            Login login = new Login();
            login.Contrasena = "Prueba";
            login.Usuario = "Prueba";
            var token = PostAsync<Login, string>("token/Generartoken", login, string.Empty);
            var resultado = await PostAsync<Prueba.Negocio.Entidades.Factura, string>("Persona/Insertar", factura, token.ToString());
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region MetodosPost        

        #endregion
    }
}