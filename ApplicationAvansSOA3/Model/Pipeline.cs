using ApplicationAvansSOA3.CompositePipeline;

namespace ApplicationAvansSOA3
{
    public class Pipeline
    {
        private bool isReleased;
        private GitAction gitAction;

        public Pipeline()
        {
            this.isReleased = false;
        }

        public void StartPipeline()
        {
            Sources sources = new Sources();
            Package package = new Package();
            Build build = new Build();
            Test test = new Test();
            Analyse analyse = new Analyse();
            Deploy deploy = new Deploy();
            Utility utility = new Utility();

            sources.AddComponent(package);
            package.AddComponent(build);
            build.AddComponent(test);
            test.AddComponent(analyse);
            analyse.AddComponent(deploy);
            deploy.AddComponent(utility);

            ActivatedVisitor activatedVisitor = new ActivatedVisitor();
            sources.AcceptVisitor(activatedVisitor);
        }



        public void AddGitAction(GitAction gitAction)
        {
            this.gitAction = gitAction;
        }

        public GitAction GetGitAction()
        {
            return this.gitAction;
        }
    }
}