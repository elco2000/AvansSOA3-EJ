using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.CompositePipeline
{
    public abstract class Component
    {
        public abstract void AcceptVisitor(Visitor visitor);
    }
}
