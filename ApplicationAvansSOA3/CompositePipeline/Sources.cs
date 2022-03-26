using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.CompositePipeline
{
    public class Sources : CompositeComponent
    {
        public override void AcceptVisitor(Visitor visitor)
        {
            visitor.VisitSources(this);
            base.AcceptVisitor(visitor);
        }

        public void ActivatedSources()
        {
            Console.Write("De source code wordt opgehaald.");
        }
    }
}
