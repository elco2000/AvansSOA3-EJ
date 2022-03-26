using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.CompositePipeline
{
    public abstract class Visitor
    {
        public abstract void VisitSources(Sources sources);
        public abstract void VisitAnalyse(Analyse analyse);
        public abstract void VisitBuild(Build build);
        public abstract void VisitDeploy(Deploy deploy);
        public abstract void VisitPackage(Package package);
        public abstract void VisitTest(Test test);
        public abstract void VisitUtility(Utility utility);

        public abstract void SendEmptyLine();
    }
}
