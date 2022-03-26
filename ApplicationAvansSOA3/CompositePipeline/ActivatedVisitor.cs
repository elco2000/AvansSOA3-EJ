using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.CompositePipeline
{
    public class ActivatedVisitor : Visitor
    {
        public override void SendEmptyLine()
        {
            Console.Write("\n");
        }

        public override void VisitAnalyse(Analyse analyse)
        {
            analyse.ActivatedAnalyse();
            SendEmptyLine();
        }

        public override void VisitBuild(Build build)
        {
            build.ActivatedBuild();
            SendEmptyLine();
        }

        public override void VisitDeploy(Deploy deploy)
        {
            deploy.ActivatedDeploy();
            SendEmptyLine();
        }

        public override void VisitPackage(Package package)
        {
            package.ActivatedPackage();
            SendEmptyLine();
        }

        public override void VisitSources(Sources sources)
        {
            sources.ActivatedSources();
            SendEmptyLine();
        }

        public override void VisitTest(Test test)
        {
            test.ActivatedTest();
            SendEmptyLine();
        }

        public override void VisitUtility(Utility utility)
        {
            utility.ActivatedUtility();
        }
    }
}
