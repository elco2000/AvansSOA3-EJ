namespace ApplicationAvansSOA3
{
    public class Sprint
    {
        private string name;
        private SprintStatus status;
        private bool isInPipeline;

        public Sprint(string name)
        {
            this.name = name;
            this.status = SprintStatus.Doing;
            this.isInPipeline = false;
        }

        public void CloseSprint()
        {
            this.status = SprintStatus.Finished;
        }

        public SprintStatus GetSprintStatus()
        {
            return this.status;
        }

        public string GetName() { 
            return this.name;
        }

        public void SetName(string name)
        {
            if(!this.isInPipeline)
            {
                this.name = name;
            }
        }

        public void SetIsInPipeline(bool v)
        {
            this.isInPipeline = v;
        }
    }
}