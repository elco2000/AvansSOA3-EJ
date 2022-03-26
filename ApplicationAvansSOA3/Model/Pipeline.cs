using ApplicationAvansSOA3.CompositePipeline;

namespace ApplicationAvansSOA3
{
    public class Pipeline
    {
        private bool isReleased;
        private GitAction? gitAction;

        public Pipeline()
        {
            isReleased = false;
        }

        public static void StartPipeline()
        {
            Sources sources = new();
            Package package = new();
            Build build = new();
            Test test = new();
            Analyse analyse = new();
            Deploy deploy = new();
            Utility utility = new();

            sources.AddComponent(package);
            package.AddComponent(build);
            build.AddComponent(test);
            test.AddComponent(analyse);
            analyse.AddComponent(deploy);
            deploy.AddComponent(utility);

            ActivatedVisitor activatedVisitor = new();
            sources.AcceptVisitor(activatedVisitor);
        }



        public void AddGitAction(GitAction gitAction)
        {
            this.gitAction = gitAction;
        }

        public GitAction GetGitAction()
        {
            return gitAction;
        }
    }
}