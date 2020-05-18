using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
        public class Counter
        {
            public string name { get; set; }
            public int value { get; set; }
            public Counter()
            {
                name = "";
                value = 0;
            }
            public Counter(string _name, int _value)
            {
                name = _name;
                value = _value;
            }
        }
    }


