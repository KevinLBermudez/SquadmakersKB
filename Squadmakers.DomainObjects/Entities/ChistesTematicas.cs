using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Squadmakers.DomainObjects.Entities
{
    public partial class ChistesTematicas
    {
        public int ChisteId { get; set; }
        public int TematicaId { get; set; }

        public virtual Chistes Chiste { get; set; }
        public virtual Tematicas Tematica { get; set; }
    }
}
