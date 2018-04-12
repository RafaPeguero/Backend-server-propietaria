using System;
using System.Collections.Generic;

namespace Facturacion.Modal
{
    public partial class Usuarios
    {
        public int UsuarioId { get; set; }
        public int VendedorId { get; set; }
        public string Clave { get; set; }

        public Vendedores Vendedor { get; set; }
    }
}
