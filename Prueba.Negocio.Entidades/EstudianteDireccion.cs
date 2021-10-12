using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Prueba.Negocio.Entidades
{
    [Table("tb_EstudianteDirecion")]
    public class EstudianteDireccion
    {

        [Key]
        [Column("IdEstudianteDirecion")]
        public int IdEstudianteDirecion { get; set; }

        [Column("IdEstudiante")]
        public int Idestudiante { get; set; }

        [Column("IdDireccion")]
        public int IdDireccion { get; set; }
    }
}
