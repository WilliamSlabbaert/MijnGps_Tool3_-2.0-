using System;
using System.Collections.Generic;
using System.Text;

namespace Tool3
{
    class Street
    {
        public Street(string iD, string name, string segment)
        {
            ID = iD;
            Name = name;
            Segment = segment;
        }

        public String ID { get; set; }
        public String Name { get; set; }
        public String Segment { get; set; }
    }
}
