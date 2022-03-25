using ApplicationAvansSOA3.GitActions;

namespace ApplicationAvansSOA3
{
    public class GitAction
    {
        private string name;
        private IGitBehavior gitBehavior;

        public GitAction(string name, IGitBehavior gitBehavior)
        {
            this.name = name;
            this.gitBehavior = gitBehavior;
        }

        public void PerformGit()
        {
            gitBehavior.Action();
        }

        public void SetGitBehavior(IGitBehavior gitBehavior)
        {
            this.gitBehavior = gitBehavior;
        }

        public IGitBehavior GetGitBehavior()
        {
            return this.gitBehavior;
        }
    }
}