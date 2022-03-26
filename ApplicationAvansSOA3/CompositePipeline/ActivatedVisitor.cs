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
            Analyse.ActivatedAnalyse();
            SendEmptyLine();
        }

        public override void VisitBuild(Build build)
        {
            Build.ActivatedBuild();
            SendEmptyLine();
        }

        public override void VisitDeploy(Deploy deploy)
        {
            Deploy.ActivatedDeploy();
            SendEmptyLine();
        }

        public override void VisitPackage(Package package)
        {
            Package.ActivatedPackage();
            SendEmptyLine();
        }

        public override void VisitSources(Sources sources)
        {
            Sources.ActivatedSources();
            SendEmptyLine();
        }

        public override void VisitTest(Test test)
        {
            Test.ActivatedTest();
            SendEmptyLine();
        }

        public override void VisitUtility(Utility utility)
        {
            Utility.ActivatedUtility();
        }
    }
}
