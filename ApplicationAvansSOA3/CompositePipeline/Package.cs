using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.CompositePipeline
{
    public class Package : CompositeComponent
    {
        public override void AcceptVisitor(Visitor visitor)
        {
            visitor.VisitPackage(this);
            base.AcceptVisitor(visitor);
        }

        public static void ActivatedPackage()
        {
            Console.Write("De packages worden op dit moment geinstalleerd.");
        }
    }
}
