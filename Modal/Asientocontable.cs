using System;
using System.Collections.Generic;

namespace Facturacion.Modal
{
    public partial class Asientocontable
    {
        public int AsientoId { get; set; }
        public string Descripcion { get; set; }
        public int ClienteId { get; set; }
        public string Cuenta { get; set; }
        public bool TipoMovimiento { get; set; }
        public DateTime FechaAsiento { get; set; }
        public double MontoAsiento { get; set; }
        public bool Estado { get; set; }

        public Clientes Cliente { get; set; }
    }
}
