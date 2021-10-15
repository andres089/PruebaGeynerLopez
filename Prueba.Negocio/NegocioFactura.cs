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
    public class NegocioFactura : INegocioFactura
    {
        #region Declaraciones

        private readonly IRepositorioFactura _repositorio;

        #endregion

        #region Constructor

        public NegocioFactura(IRepositorioFactura repositorio)
        {
            _repositorio = repositorio;
        }

        public bool Actualizar(Factura modelo, out string mensaje)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Metodos

        public int Crear(Factura modelo, out string mensaje)
        {
            mensaje = string.Empty;
            if (_repositorio.ObtenerLista().Where(x =>  x.NumeroFactura == modelo.NumeroFactura).Any())
            {
                mensaje = Transversal.Mensajes.MensajeFacturaExiste;
                return 0;
            }
            else
            {
                return _repositorio.Insertar(modelo);                
            }            
        }

        public bool Eliminar(Factura modelo, out string mensaje)
        {
            mensaje = string.Empty;
            return _repositorio.Eliminar(modelo);
        }

        public Factura Obtener(int id)
        {
            return _repositorio.Obtener(id);
        }
        
        public IEnumerable<Factura> ObtenerTodos()
        {
            return _repositorio.ObtenerLista();
        }

        #endregion
    }
}
