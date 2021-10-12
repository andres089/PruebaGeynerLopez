using System.Collections.Generic;
using System.Web.Mvc;
using System.Threading.Tasks;
using FrontEnd.Controllers.Base;
using Prueba.Negocio.Entidades;
using Prueba.Transversal;
using FrontEnd.Models;

namespace FrontEnd.Controllers
{
    public class EstudianteController : BaseController
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
            var token = PostAsync<Login, string>("token/Generartoken", login);
            var modelo = await GetAsync<IEnumerable<Models.Estudiante>>("Estudiante/ObtenerEstudiantes");
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
            var token = PostAsync<Login, string>("token/Generartoken", login);
            var lista = await GetAsync<IEnumerable<Models.Estudiante>>("Estudiante/ObtenerEstudiantes");
            return PartialView("_List", lista);
        }

        /// <summary>
        /// Muestra ventana de creación.
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult> VentanaCrear()
        {
            Models.Estudiante estudiante = new Models.Estudiante();
            estudiante.Cursos = await GetAsync<IEnumerable<Cursos>>("Curso/ObtenerCurso");
            estudiante.Direcciones = await GetAsync<IEnumerable<Direcciones>>("Direcciones/ObtenerDirecciones");
            return PartialView("_CrearEditar", estudiante);
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
            var token = PostAsync<Login, string>("token/Generartoken", login);
            var estudiante = await GetAsync<Models.Estudiante>($"Estudiante/Obtener/{Id}");
            return PartialView("_CrearEditar", estudiante);
        }


        public async Task<ActionResult> Insertar(Models.Estudiante modelo)
        {
            Prueba.Negocio.Entidades.Estudiante estudiante = new Prueba.Negocio.Entidades.Estudiante();
            estudiante.Documento = modelo.Documento;
            estudiante.FechaCreacion = System.DateTime.Now;
            estudiante.Nombre = modelo.Nombre;
            estudiante.Telefono = modelo.Telefono;
            Login login = new Login();
            login.Contrasena = "Prueba";
            login.Usuario = "Prueba";
            var token = PostAsync<Login, string>("token/Generartoken", login);
            var resultado = await PostAsync<Prueba.Negocio.Entidades.Estudiante, string>("Persona/Insertar", estudiante);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region MetodosPost

        public async Task<ActionResult> Actualizar(Models.Estudiante modelo)
        {
            Prueba.Negocio.Entidades.Estudiante estudiante = new Prueba.Negocio.Entidades.Estudiante();
            estudiante.Documento = modelo.Documento;
            estudiante.FechaCreacion = System.DateTime.Now;
            estudiante.Nombre = modelo.Nombre;
            estudiante.Telefono = modelo.Telefono;

            Login login = new Login();
            login.Contrasena = "Prueba";
            login.Usuario = "Prueba";
            var token = PostAsync<Login, string>("token/Generartoken", login);
            var resultado = await PutAsync<Prueba.Negocio.Entidades.Estudiante, string>("Persona/Actualizar", estudiante);
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