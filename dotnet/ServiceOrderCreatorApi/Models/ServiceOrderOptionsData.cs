using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.Models
{
    public struct ServiceOrderOptionsData
    {
        public int Version { get; set; }

        public List<(string title, bool selected)> Options { get; set; }
    }
}
