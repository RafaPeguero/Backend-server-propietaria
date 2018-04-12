using System;
using System.Collections.Generic;

namespace Facturacion.Modal
{
    public partial class Condicionpago
    {
        public int PagoId { get; set; }
        public string Descripcion { get; set; }
        public int Dias { get; set; }
        public bool Estado { get; set; }
    }
}
