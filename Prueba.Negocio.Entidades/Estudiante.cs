using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Prueba.Negocio.Entidades
{
    [Table("tb_EStudiante")]
    public class Estudiante
    {

        [Key]
        [Column("IdEstudiante")]
        public int IdEstudiante { get; set; }

        [Column("Documento")]
        public string Documento { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Telefono")]
        public string Telefono { get; set; }

        [Column("FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        public IEnumerable<Direcciones> Direcciones { get; set; }

        public IEnumerable<Cursos> Cursos { get; set; }

    }
}
