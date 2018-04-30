using MockDatabase.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1
{
    public class WebContext : MockContext
    {
        public MockCollection<WebClass> WebClass { get; set; }

    }
}
