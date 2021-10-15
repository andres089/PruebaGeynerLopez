using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Prueba.Negocio.Entidades
{
    [Table("tb_FacturaProducto")]
    public class FacturaProducto
    {

        [Key]
        [Column("IdFacturaProducto")]
        public int IdFacturaProducto { get; set; }

        [Column("IdFactura")]
        public int IdFactura { get; set; }

        [Column("IdProducto")]
        public int IdProducto { get; set; }

    }

}
