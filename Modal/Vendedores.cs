using System;
using System.Collections.Generic;

namespace Facturacion.Modal
{
    public partial class Vendedores
    {
        public Vendedores()
        {
            Facturacion = new HashSet<Facturacion>();
            Usuarios = new HashSet<Usuarios>();
        }

        public int VendedorId { get; set; }
        public string Nombre { get; set; }
        public double Comision { get; set; }
        public bool Estado { get; set; }

        public ICollection<Facturacion> Facturacion { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
