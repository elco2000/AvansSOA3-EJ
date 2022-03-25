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
            
        }

        public void SendNotificationByError()
        {

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