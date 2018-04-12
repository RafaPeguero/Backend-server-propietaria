using System;
using System.Collections.Generic;

namespace Facturacion.Modal
{
    public partial class Clientes
    {
        public Clientes()
        {
            Asientocontable = new HashSet<Asientocontable>();
            Facturacion = new HashSet<Facturacion>();
        }

        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string CuentaContable { get; set; }
        public bool Estado { get; set; }

        public ICollection<Asientocontable> Asientocontable { get; set; }
        public ICollection<Facturacion> Facturacion { get; set; }
    }
}
