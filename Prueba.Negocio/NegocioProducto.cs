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
    public class NegocioProducto : INegocioProducto
    {
        #region Declaraciones

        private readonly IRepositorioProducto _repositorio;

        #endregion

        #region Constructor

        public NegocioProducto(IRepositorioProducto repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        #region Metodos

        public bool Actualizar(Producto modelo, out string mensaje)
        {
            mensaje = string.Empty;
            return _repositorio.Actualizar(modelo);
        }

        public int Crear(Producto modelo, out string mensaje)
        {
            mensaje = string.Empty;
            return _repositorio.Insertar(modelo);
        }

        public bool Eliminar(Producto modelo, out string mensaje)
        {
            mensaje = string.Empty;
            return _repositorio.Eliminar(modelo);
        }

        public Producto Obtener(int id)
        {
            return _repositorio.Obtener(id);
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            return _repositorio.ObtenerLista();
        }

        #endregion


    }
}
