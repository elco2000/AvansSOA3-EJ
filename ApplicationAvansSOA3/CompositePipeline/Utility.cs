using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.CompositePipeline
{
    public class Utility : Component
    {
        public override void AcceptVisitor(Visitor visitor)
        {
            visitor.VisitUtility(this);
        }

        public static void ActivatedUtility()
        {
            Console.Write("Overige commands worden uitgevoerd. De pipeline is succesvol voltooid!");
        }
    }
}
