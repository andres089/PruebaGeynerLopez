using Prueba.Negocio.Entidades;
using Prueba.Persistencia.Interfaces;
using Prueba.Persistencia.Base;

namespace Prueba.Persistencia.Repositorios
{
    public class RepositorioProducto : RepositorioBase<Producto>, IRepositorioProducto
    {
    }
}
