using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Prueba.Negocio.Entidades;

namespace FrontEnd.Models
{
    public class Factura
    {
        public int IdFactura { get; set; }

        public string NumeroFactura { get; set; }

        public DateTime Fecha { get; set; }

        public int TipoPago { get; set; }

        public string DocumentoCliente { get; set; }

        public string NombreCliente { get; set; }

        public long Subtotal { get; set; }

        public long Descuento { get; set; }

        public int Iva { get; set; }

        public long TotalDescuento { get; set; }

        public long TotalImpuesto { get; set; }

        public long Total { get; set; }

        public IEnumerable<Producto> Productos { get; set; }

        public IEnumerable<MedioPago> medioPagos { get; set; }

    }

    public class MedioPago
    {
        public int IdMedioPago { get; set; }

        public string Descripcion { get; set; }

    }
}