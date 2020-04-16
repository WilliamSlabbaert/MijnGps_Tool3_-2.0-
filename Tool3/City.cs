using System;
using System.Collections.Generic;
using System.Text;

namespace Tool3
{
    class City
    {
        public City(string name, string iD, List<string> streetIds)
        {
            Name = name;
            ID = iD;
            StreetIds = streetIds;
        }

        public String Name { get; set; }
        public String ID { get; set; }
        public List<String> StreetIds { get; set; }
    }
}
