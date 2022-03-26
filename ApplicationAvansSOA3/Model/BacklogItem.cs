using System.Collections;
using ApplicationAvansSOA3.Observer;
using ApplicationAvansSOA3.State;

namespace ApplicationAvansSOA3
{
    public class BacklogItem : INotifier
    {
        private readonly string title;
        private readonly string description;
        private bool isDone;
        private IList activities;
        private Discussion? discussion;
        private IMember? member;
        private IFaseState state;
        private int testedFailedAmount;

        private readonly IList<IMember> _subscribers = new List<IMember>();

        public BacklogItem(string title, string description)
        {
            this.title = title;
            this.description = description;
            this.isDone = false;
            this.activities = new List<Activity>();
            this.state = new ToDoState(this);
            this.testedFailedAmount = 0;
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
            return isDone;
        }

        public void SetIsDone(bool isDone)
        {
            this.isDone = isDone;
        }

        public void CreateDiscussion(string title, string description)
        {
            if(discussion == null)
            {
                discussion = new Discussion(title, description);
            }
        }

        public Discussion GetDiscussion()
        {
            return discussion;
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
            member = null;
        }

        public IMember GetMember()
        {
            return member;
        }

        #region States
        public IFaseState GetState()
        {
            return state;
        }

        public void BacklogItemToDo()
        {
            state = state.BacklogItemToDo();   
        }

        public void BacklogItemDoing()
        {
            state = state.BacklogItemDoing();
        }

        public void BacklogItemReadyForTesting()
        {
            if (state.GetType() == new TestedState(this).GetType() && testedFailedAmount < 2)
            {
                testedFailedAmount++;
            }

            state = state.BacklogItemReadyForTesting();

            if (testedFailedAmount >= 2)
            {
                BacklogItemToDo();
                testedFailedAmount = 0;
            }         
        }

        public void BacklogItemTested()
        {
            state = state.BacklogItemTested();
        }

        public void BacklogDone()
        {
            state = state.BacklogItemDone(member, GetIsDone());
        }
        #endregion

        public void Subscribe(IMember subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Unsubscribe(IMember subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public void Notify(string role, string message)
        {
            foreach (var subscriber in _subscribers)
            {
                if (subscriber.GetRole().ToUpper() == role.ToUpper())
                {
                    subscriber.Update(message);
                }
            }
        }

    }
}