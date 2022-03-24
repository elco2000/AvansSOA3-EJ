using System.Collections;

namespace ApplicationAvansSOA3
{
    public class Discussion
    {
        private string title;
        private string description;
        private DateTime date;
        private bool isClosed;
        private IList responses;

        public Discussion(string title, string discussion)
        {
            this.title = title;
            this.description = discussion;
            this.date = DateTime.Now;
            this.isClosed = false;
            this.responses = new List<Response>();
        }

        public string GetTitle()
        {
            return this.title;
        }

        public void CreateResponse(string title, string text)
        {
            if(!this.isClosed)
            {
                responses.Add(new Response(title, text));
            }
        }

        public IList GetResponses()
        {
            return this.responses;
        }

        public void CloseDiscussion()
        {
            this.isClosed = true;
        }
    }
}