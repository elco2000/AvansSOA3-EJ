using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.CompositePipeline
{
    public class Build : CompositeComponent
    {
        public override void AcceptVisitor(Visitor visitor)
        {
            visitor.VisitBuild(this);
            base.AcceptVisitor(visitor);
        }

        public static void ActivatedBuild()
        {
            Console.Write("De software wordt gebuild. Maakt connectie met andere verschillende builds.");
        }
    }
}
