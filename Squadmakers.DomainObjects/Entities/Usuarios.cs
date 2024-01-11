using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Squadmakers.DomainObjects.Entities
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Chistes = new HashSet<Chistes>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }

        public virtual ICollection<Chistes> Chistes { get; set; }
    }
}
