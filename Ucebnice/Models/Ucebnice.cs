using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ucebnice.models
{
    public class Ucebnice
    {
        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }
    }
    public class SampleViewModel
    {
        public List<Ucebnice> Ucebnice{ get; set; }
    }
}
