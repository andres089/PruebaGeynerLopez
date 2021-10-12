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
    public class NegocioCursos : INegocioCursos
    {
        #region Declaraciones

        private readonly IRepositorioCursos _repositorio;

        #endregion

        #region Constructor

        public NegocioCursos(IRepositorioCursos repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        #region Metodos

        public bool Actualizar(Cursos modelo, out string mensaje)
        {
            mensaje = string.Empty;
            return _repositorio.Actualizar(modelo);
        }

        public int Crear(Cursos modelo, out string mensaje)
        {
            mensaje = string.Empty;
            return _repositorio.Insertar(modelo);
        }

        public bool Eliminar(Cursos modelo, out string mensaje)
        {
            mensaje = string.Empty;
            return _repositorio.Eliminar(modelo);
        }

        public Cursos Obtener(int id)
        {
            return _repositorio.Obtener(id);
        }

        public IEnumerable<Cursos> ObtenerTodos()
        {
            return _repositorio.ObtenerLista();
        }

        #endregion


    }
}
