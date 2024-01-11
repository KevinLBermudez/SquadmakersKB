using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Squadmakers.DomainObjects.ValueObjects
{
    [Serializable]
    public class IcanhazdadJoke
    {
        public string id { get; set; }
        public string joke { get; set; }
        public string status { get; set; }
    }
}
