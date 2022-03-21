namespace ApplicationAvansSOA3
{
    public class Sprint
    {
        private readonly string name;
        private SprintStatus status;

        public Sprint(string name)
        {
            this.name = name;
            this.status = SprintStatus.Doing;
        }

        public void CloseSprint()
        {
            this.status = SprintStatus.Finished;
        }

        public SprintStatus GetSprintStatus()
        {
            return this.status;
        }
    }
}