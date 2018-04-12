using System;
using System.Collections.Generic;

namespace Facturacion.Modal
{
    public partial class Articulos
    {
        public Articulos()
        {
            Detallesfactura = new HashSet<Detallesfactura>();
        }

        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public double CostoUnitario { get; set; }
        public double PrecioUnitario { get; set; }
        public bool Estado { get; set; }

        public ICollection<Detallesfactura> Detallesfactura { get; set; }
    }
}
