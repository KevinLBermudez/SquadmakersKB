using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Squadmakers.DomainObjects.Entities
{
    public partial class Chistes
    {
        public Chistes()
        {
            ChistesTematicas = new HashSet<ChistesTematicas>();
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Cuerpo { get; set; }
        public int Autor { get; set; }
        public bool? Activo { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Usuarios AutorNavigation { get; set; }
        public virtual ICollection<ChistesTematicas> ChistesTematicas { get; set; }
    }
}
