using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Prueba.Negocio.Entidades
{
    [Table("tb_Producto")]
    public class Producto
    {

        [Key]
        [Column("IdProducto")]
        public int IdProducto { get; set; }

        [Column("Producto")]
        public int NombreProducto { get; set; }

    }

}
