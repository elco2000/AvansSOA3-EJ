using System.Collections;

namespace ApplicationAvansSOA3
{
    public class Sprint
    {
        private string name;
        private SprintStatus status;
        private bool isInPipeline;
        private IList<IMember> members;

        public Sprint(string name)
        {
            this.name = name;
            this.status = SprintStatus.Doing;
            this.isInPipeline = false;
            this.members = new List<IMember>();
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

        public void AddMember(IMember developer)
        {
            this.members.Add(developer);
        }

        public IList<IMember> GetMembers()
        {
            return this.members;
        }

        public void SetIsInPipeline(bool v)
        {
            this.isInPipeline = v;
        }

        public Rapport GenerateRapport(string rapportName)
        {
            CloseSprint();
            return new Rapport(rapportName, this);
        }
    }
}