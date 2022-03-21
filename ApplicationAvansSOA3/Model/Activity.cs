namespace ApplicationAvansSOA3
{
    public class Activity
    {
        private readonly string title;
        private readonly string description;
        private bool isDone;

        public Activity(string title, string description)
        {
            this.title = title;
            this.description = description;
            this.isDone = false;
        }

        public bool GetIsDone()
        {
            return this.isDone;
        }

        public void SetIsDone(bool isDone)
        { 
            this.isDone = isDone; 
        }
    }
}