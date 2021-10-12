using Prueba.Negocio.Entidades;
using Prueba.Persistencia.Interfaces;
using Prueba.Persistencia.Base;
using Dapper;
using System;
using Prueba.Transversal;
using System.Collections.Generic;

namespace Prueba.Persistencia.Repositorios
{
    public class RepositorioEstudiante : RepositorioBase<Estudiante>, IRepositorioEstudiante
    {


    }
}
