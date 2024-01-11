using Squadmakers.DomainObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squadmakers.DomainObjects.ValueObjects
{
    [Serializable]
    public class ChistesVo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Autor { get; set; }

        public void ConvertTo(Chistes ent)
        {
            this.Id = ent.Id;
            this.Titulo = ent.Titulo;
            this.Autor = ent.Autor;
        }
    }
}
