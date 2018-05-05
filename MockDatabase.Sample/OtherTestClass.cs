using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDatabase.Sample
{
    public class OtherTestClass
    {
        public int Id { get; set; }
        public double Price { get; set; }

        public TestClass Parent { get; set; }

        public IEnumerable<ThirdTestClass> Products { get; set; }




    }
}
