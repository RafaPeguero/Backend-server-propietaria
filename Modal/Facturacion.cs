using System;
using System.Collections.Generic;

namespace Facturacion.Modal
{
    public partial class Facturacion
    {
        public Facturacion()
        {
            Detallesfactura = new HashSet<Detallesfactura>();
        }

        public int FacturaId { get; set; }
        public int VendedorId { get; set; }
        public int ClienteId { get; set; }
        public string TipoPago { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }

        public Clientes Cliente { get; set; }
        public Vendedores Vendedor { get; set; }
        public ICollection<Detallesfactura> Detallesfactura { get; set; }
    }
}
