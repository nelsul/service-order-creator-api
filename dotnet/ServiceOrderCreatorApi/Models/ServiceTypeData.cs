using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceOrderCreatorApi.Models
{
    public struct ServiceTypeData
    {
        public int Version { get; set; }

        public List<string> Options { get; set; }
    }
}
