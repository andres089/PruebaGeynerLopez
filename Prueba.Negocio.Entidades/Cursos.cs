using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Prueba.Negocio.Entidades
{
    [Table("tb_Cursos")]
    public class Cursos
    {

        [Key]
        [Column("IdCurso")]
        public int IdCurso { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

    }

}
