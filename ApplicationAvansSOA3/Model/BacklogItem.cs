using System.Collections;

namespace ApplicationAvansSOA3
{
    public class BacklogItem
    {
        private string title;
        private string description;
        private bool isDone;
        private IList activities;
        private Discussion discussion;
        private IMember member;
        
        public BacklogItem(string title, string description)
        {
            this.title = title;
            this.description = description;
            this.isDone = false;
            this.activities = new List<Activity>();
        }

        public string GetTitle() 
        {
            return title; 
        }

        public void CreateActivity(string title, string description)
        {
            activities.Add(new Activity(title, description));
        }

        public IList GetActivities()
        {
            return activities;
        }

        public void SetActivities(IList activities)
        {
            this.activities = activities;
        }

        public void CloseBacklogItem()
        {
            bool allActivitiesClosed = true;
            foreach (Activity activity in activities)
            {
                if (!activity.GetIsDone())
                {
                    allActivitiesClosed = false;
                    break;
                }
            }

            if (allActivitiesClosed) { SetIsDone(true); }
        }

        public bool GetIsDone()
        {
            return this.isDone;
        }

        public void SetIsDone(bool isDone)
        {
            this.isDone = isDone;
        }

        public void CreateDiscussion(string title, string description)
        {
            if(this.discussion == null)
            {
                this.discussion = new Discussion(title, description);
            }
        }

        public Discussion GetDiscussion()
        {
            return this.discussion;
        }

        public void AddMember(IMember member)
        {
            if(this.member is null && member.GetRole().ToUpper() == "DEVELOPER")
            {
                this.member = member;
            }
        }

        public void RemoveMember()
        {
            this.member = null;
        }

        public IMember GetMember()
        {
            return this.member;
        }
    }
}