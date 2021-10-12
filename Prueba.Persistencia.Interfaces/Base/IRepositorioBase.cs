using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Prueba.Persistencia.Interfaces
{
    public interface IRepositorioBase<T> where T : class
    {
        bool ExecuteQuery(string consulta, object parametros, MySqlTransaction mySqlTransaction = null);
        int Insertar(T modelo);
        bool Actualizar(T modelo);
        bool Eliminar(T modelo);
        IEnumerable<T> ObtenerLista();
        T Obtener(int id);
        IEnumerable<T> ObtenerLista(string query, object Parametros);
    }
}
