using MockDatabase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDatabase.Sample
{
    public class TestContext : MockContext
    {
        public MockCollection<TestClass> MyEntity { get; set; }
        public MockCollection<OtherTestClass> MyOtherEntity { get; set; }
        public MockCollection<ThirdTestClass> ThirdEntity { get; set; }



    }
}
