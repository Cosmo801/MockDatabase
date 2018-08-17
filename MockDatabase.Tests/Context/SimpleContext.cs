
using Cosmo.MockDatabase.Context;
using MockDatabase.Tests.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockDatabase.Tests.Context
{
    public class SimpleContext : MockContext
    {
        public MockCollection<Customer> Customers { get; set; }
        public MockCollection<Products> Products { get; set; }


    }
}
