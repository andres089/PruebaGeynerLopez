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
    public class NegocioEstudiante : INegocioEstudiante
    {
        #region Declaraciones

        private readonly IRepositorioEstudiante _repositorio;

        #endregion

        #region Constructor

        public NegocioEstudiante(IRepositorioEstudiante repositorio)
        {
            _repositorio = repositorio;
        }

        #endregion

        #region Metodos
        public bool Actualizar(Estudiante modelo, out string mensaje)
        {
            mensaje = string.Empty;
            if (_repositorio.ObtenerLista().Where(x => x.IdEstudiante != modelo.IdEstudiante && x.Nombre == modelo.Nombre && x.Documento == modelo.Documento && x.Telefono == modelo.Telefono).Any())
            {
                mensaje = Transversal.Mensajes.MensajeEstudianteExiste;
                return false;
            }
            else
            {
                return _repositorio.Actualizar(modelo);
            }            
        }

        public int Crear(Estudiante modelo, out string mensaje)
        {
            mensaje = string.Empty;
            if (_repositorio.ObtenerLista().Where(x =>  x.Nombre == modelo.Nombre && x.Documento == modelo.Documento).Any())
            {
                mensaje = Transversal.Mensajes.MensajeEstudianteExiste;
                return 0;
            }
            else
            {
                return _repositorio.Insertar(modelo);                
            }            
        }

        public bool Eliminar(Estudiante modelo, out string mensaje)
        {
            mensaje = string.Empty;
            return _repositorio.Eliminar(modelo);
        }

        public Estudiante Obtener(int id)
        {
            return _repositorio.Obtener(id);
        }
        
        public IEnumerable<Estudiante> ObtenerTodos()
        {
            return _repositorio.ObtenerLista();
        }

        #endregion
    }
}
