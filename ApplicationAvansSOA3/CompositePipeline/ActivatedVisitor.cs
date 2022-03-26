using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.CompositePipeline
{
    public class ActivatedVisitor : Visitor
    {
        public override void VisitAnalyse(Analyse analyse)
        {
            analyse.ActivatedAnalyse();
        }

        public override void VisitBuild(Build build)
        {
            build.ActivatedBuild();
        }

        public override void VisitDeploy(Deploy deploy)
        {
            deploy.ActivatedDeploy();
        }

        public override void VisitPackage(Package package)
        {
            package.ActivatedPackage();
        }

        public override void VisitSources(Sources sources)
        {
            sources.ActivatedSources();
        }

        public override void VisitTest(Test test)
        {
            test.ActivatedTest();
        }

        public override void VisitUtility(Utility utility)
        {
            utility.ActivatedUtility();
        }
    }
}
