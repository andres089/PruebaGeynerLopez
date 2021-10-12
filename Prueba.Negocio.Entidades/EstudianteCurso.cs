using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Prueba.Negocio.Entidades
{
    [Table("tb_EstudianteCurso")]
    public class EstudianteCurso
    {
        [Key]
        [Column("IdEstudianteCurso")]
        public int IdVehiculoConductor { get; set; }

        [Column("Idestudiante")]
        public int IdEstudiante { get; set; }

        [Column("IdCurso")]
        public int IdCurso { get; set; }        

    }
}
