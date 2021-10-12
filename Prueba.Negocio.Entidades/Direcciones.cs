using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Prueba.Negocio.Entidades
{
    [Table("tb_Direcciones")]
    public class Direcciones
    {

        [Key]
        [Column("IdDireccion")]
        public int IdDireccion { get; set; }

        [Column("Direccion")]
        public string Direccion { get; set; }


    }
}
