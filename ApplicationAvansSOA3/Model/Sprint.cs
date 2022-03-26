using ApplicationAvansSOA3.AdapterNotification;
using System.Collections;

namespace ApplicationAvansSOA3
{
    public class Sprint
    {
        private string name;
        private SprintStatus status;
        private bool isInPipeline;
        private readonly IList<IMember> members;
        private readonly Pipeline pipeline;
        private Backlog ?backlog;

        public Sprint(string name)
        {
            this.name = name;
            status = SprintStatus.Doing;
            isInPipeline = false;
            members = new List<IMember>();
            pipeline = new Pipeline();
        }

        public void CloseSprint()
        {
            bool isFinished = true;
            Service service = new();
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

                status = SprintStatus.Finished;

                SetIsInPipeline(true);

                Pipeline.StartPipeline();
            } else
            { 
                notification.ConvertInformationToEmail("Sprint release is geannuleerd.");
            }
        }

        public SprintStatus GetSprintStatus()
        {
            return status;
        }

        public string GetName() { 
            return name;
        }

        public void SetName(string name)
        {
            if(!isInPipeline)
            {
                this.name = name;
            }
        }

        public void AddMember(IMember developer)
        {
            members.Add(developer);
        }

        public IList<IMember> GetMembers()
        {
            return members;
        }

        public void SetIsInPipeline(bool v)
        {
            isInPipeline = v;
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
            return backlog; 
        }
    }
}