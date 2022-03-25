namespace ApplicationAvansSOA3
{
    public class Activity
    {
        private readonly string title;
        private readonly string description;
        private bool isDone;
        private IList<IMember> members;

        public Activity(string title, string description)
        {
            this.title = title;
            this.description = description;
            this.isDone = false;
            this.members = new List<IMember>();
        }

        public bool GetIsDone()
        {
            return this.isDone;
        }

        public void SetIsDone(bool isDone)
        { 
            this.isDone = isDone; 
        }

        public void AddMember(IMember member)
        {
            if (member.GetRole().ToUpper() == "DEVELOPER")
            {
                members.Add(member);
            }
        }

        public IList<IMember> GetMembers()
        {
            return this.members;
        }
    }
}