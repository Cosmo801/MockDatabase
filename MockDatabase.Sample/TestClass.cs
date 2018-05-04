using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDatabase.Sample
{
    public class TestClass
    {
        public string Name { get; set; }
        public int Number { get; set; }

        public ICollection<OtherTestClass> Orders { get; set; }
        public ThirdTestClass Info { get; set; }



    }
}
