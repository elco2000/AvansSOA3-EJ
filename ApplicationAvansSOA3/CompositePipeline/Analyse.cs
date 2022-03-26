using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.CompositePipeline
{
    public class Analyse : CompositeComponent
    {
        public override void AcceptVisitor(Visitor visitor)
        {
            visitor.VisitAnalyse(this);
            base.AcceptVisitor(visitor);
        }

        public static void ActivatedAnalyse()
        {
            Console.Write("De code wordt geanalyseerd door SonarCloud.");
        }
    }
}
