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

        public void SetTitle(string title)
        {
            if(!this.isClosed)
            {
                this.title = title;
            }
        }

        public void SetDescription(string description)
        {
            if (!this.isClosed)
            {
                this.description = description;
            }
        }

        public string GetDescription()
        {
            return this.description;
        }
    }
}