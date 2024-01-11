using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Squadmakers.DomainObjects.Entities
{
    public partial class Tematicas
    {
        public Tematicas()
        {
            ChistesTematicas = new HashSet<ChistesTematicas>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<ChistesTematicas> ChistesTematicas { get; set; }
    }
}
