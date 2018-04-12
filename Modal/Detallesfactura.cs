using System;
using System.Collections.Generic;

namespace Facturacion.Modal
{
    public partial class Detallesfactura
    {
        public int DetalleId { get; set; }
        public int FacturaId { get; set; }
        public int ArticuloId { get; set; }

        public Articulos Articulo { get; set; }
        public Facturacion Factura { get; set; }
    }
}
