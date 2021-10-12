using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prueba.Negocio.Entidades;

namespace FrontEnd.Models
{
    public class Estudiante
    {       
        public int IdEstudiante { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public DateTime FechaCreacion { get; set; }

        public IEnumerable<Direcciones> Direcciones { get; set; }

        public IEnumerable<Cursos> Cursos { get; set; }

        public IEnumerable<Direcciones> DireccionesEstudiantes { get; set; }

        public IEnumerable<Cursos> CursosEstudiantes { get; set; }

    }
}