using ApplicationAvansSOA3.AdapterNotification;
using System.Collections;

namespace ApplicationAvansSOA3
{
    public class Sprint
    {
        private string name;
        private SprintStatus status;
        private bool isInPipeline;
        private IList<IMember> members;
        private Pipeline pipeline;
        private Backlog ?backlog;

        public Sprint(string name)
        {
            this.name = name;
            this.status = SprintStatus.Doing;
            this.isInPipeline = false;
            this.members = new List<IMember>();
            this.pipeline = new Pipeline();
        }

        public void CloseSprint()
        {
            bool isFinished = true;
            Service service = new Service();
            INotificationEmail notification = new Adapter(service);

            if (backlog != null)
            {
                foreach (var backlogItem in backlog.getBacklogItems())
                {
                    if (!backlogItem.Value.GetIsDone())
                    {
                        isFinished = false;
                        break;
                    }
                }
            }

            if (isFinished && backlog != null)
            {
                notification.ConvertInformationToEmail("Sprint is gesloten. En Pipeline wordt gestart!");

                this.status = SprintStatus.Finished;

                SetIsInPipeline(true);

                this.pipeline.StartPipeline();
            } else
            { 
                notification.ConvertInformationToEmail("Sprint release is geannuleerd.");
            }
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

        public void SetBacklog(Backlog backlog)
        {
            this.backlog = backlog;
        }

        public Backlog GetBacklog()
        {
            return this.backlog; 
        }
    }
}