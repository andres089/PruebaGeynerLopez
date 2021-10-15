using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Prueba.Negocio.Entidades
{
    [Table("tb_Factura")]
    public class Factura
    {

        [Key]
        [Column("IdFactura")]
        public int IdFactura { get; set; }

        [Column("NumeroFactura")]
        public string NumeroFactura { get; set; }

        [Column("Fecha")]
        public DateTime Fecha { get; set; }

        [Column("TipoPago")]
        public int TipoPago { get; set; }

        [Column("DocumentoCliente")]
        public string DocumentoCliente { get; set; }

        [Column("NombreCliente")]
        public string NombreCliente { get; set; }

        [Column("Subtotal")]
        public long Subtotal { get; set; }

        [Column("Descuento")]
        public long Descuento { get; set; }

        [Column("Iva")]
        public int Iva { get; set; }

        [Column("TotalDescuento")]
        public long TotalDescuento { get; set; }

        [Column("TotalImpuesto")]
        public long TotalImpuesto { get; set; }

        [Column("Total")]
        public long Total { get; set; }

    }
}
