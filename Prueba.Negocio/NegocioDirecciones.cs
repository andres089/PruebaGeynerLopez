using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prueba.Negocio.Entidades;
using Prueba.Negocio.Interfaces;
using Prueba.Persistencia.Interfaces;

namespace Prueba.Negocio
{
    public class NegocioDirecciones : INegocioDirecciones
    {

        #region Declaraciones

        private readonly IRepositorioDirecciones _repositorio;

        #endregion

        #region Constructor

        public NegocioDirecciones(IRepositorioDirecciones repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        #region Metodos

        public bool Actualizar(Direcciones modelo, out string mensaje)
        {
            mensaje = "Actualizacion correcta";
            return _repositorio.Actualizar(modelo);
        }

        public int Crear(Direcciones modelo, out string mensaje)
        {
            mensaje = "Actualizacion correcta";
            return _repositorio.Insertar(modelo);
        }

       public bool Eliminar(Direcciones modelo, out string mensaje)
        {
            throw new NotImplementedException();
        }

        public Direcciones Obtener(int id)
        {
            return _repositorio.Obtener(id);
        }



        public IEnumerable<Direcciones> ObtenerTodos()
        {
            return _repositorio.ObtenerLista();
        }

       
        #endregion
    }
}
