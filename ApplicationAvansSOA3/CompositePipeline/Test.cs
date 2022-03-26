using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.CompositePipeline
{
    public class Test : CompositeComponent
    {
        public override void AcceptVisitor(Visitor visitor)
        {
            visitor.VisitTest(this);
            base.AcceptVisitor(visitor);
        }

        public void ActivatedTest()
        {
            Console.Write("De code wordt getest met alle beschikbaar testen.");
        }
    }
}
