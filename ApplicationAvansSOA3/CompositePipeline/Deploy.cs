using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.CompositePipeline
{
    public class Deploy : CompositeComponent
    {
        public override void AcceptVisitor(Visitor visitor)
        {
            visitor.VisitDeploy(this);
            base.AcceptVisitor(visitor);
        }

        public void ActivatedDeploy()
        {
            Console.Write("De code wordt gedeployed op de gewenste omgeving.");
        }
    }
}
