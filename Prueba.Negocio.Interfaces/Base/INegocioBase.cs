using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Negocio.Interfaces.Base
{
    public interface INegocioBase<T> where T : class
    {
        IEnumerable<T> ObtenerTodos();
        T Obtener(int id);
        int Crear(T modelo, out string mensaje);
        bool Actualizar(T modelo, out string mensaje);
        bool Eliminar(T modelo, out string mensaje);
    }
}
