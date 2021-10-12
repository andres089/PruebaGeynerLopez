using System;
using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;
using System.Configuration;
using Prueba.Transversal;
using System.Linq;
using Prueba.Persistencia.Interfaces;

namespace Prueba.Persistencia.Base
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class
    {
        public readonly MySqlConnection _cnn;

        public RepositorioBase()
        {

            string connectionString = string.Format("datasource={0};port={1};username={2};password={3};database={4}",
                                                     ConfigurationManager.AppSettings["servidor"],
                                                     ConfigurationManager.AppSettings["puerto"],
                                                     ConfigurationManager.AppSettings["usuario"],
                                                     ConfigurationManager.AppSettings["clave"],
                                                     ConfigurationManager.AppSettings["basedatos"]);

            //Instancia la conexion y define el dialecto de mysql como predeterminado.
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            _cnn = new MySqlConnection(connectionString);            
        }

        public bool ExecuteQuery(string consulta, object parametros, MySqlTransaction mySqlTransaction = null)
        {
            try
            {
                if (mySqlTransaction != null)
                {
                    return _cnn.Execute(consulta, parametros, mySqlTransaction) > 0;
                }
                else
                {
                    return _cnn.Execute(consulta, parametros) > 0;
                }
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(ex, "RepositorioBase_ExecuteQuery");
                throw;
            }
        }
                        
        public int Insertar(T modelo)
        {
            try
            {
                return _cnn.Insert<object>(modelo).Value;
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(ex, "RepositorioBase_Insertar");
                throw;
            }
        }

        public bool Actualizar(T modelo)
        {
            try
            {
                return _cnn.Update(modelo) > 0;
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(ex, "RepositorioBase_Actualizar");
                throw;
            }
        }

        public bool Eliminar(T modelo)
        {
            return _cnn.Delete<T>(modelo) > 0;
        }

        public T Obtener(int id)
        {
            return _cnn.Get<T>(id);
        }

        public IEnumerable<T> ObtenerLista()
        {
            try
            {                
                return _cnn.GetList<T>();
            }
            catch (Exception ex)
            {
                Utilidades.RegistrarError(ex, "RepositorioBase_ObtenerLista");
                throw;
            }
        }

        public IEnumerable<T> ObtenerLista(string query, object Parametros)
        {
            return _cnn.Query<T>(query, Parametros);
        }
    }
}