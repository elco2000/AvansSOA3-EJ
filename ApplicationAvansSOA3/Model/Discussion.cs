using ApplicationAvansSOA3.AdapterNotification;
using System.Collections;

namespace ApplicationAvansSOA3
{
    public class Discussion
    {
        private string title;
        private string description;
        private readonly DateTime date;
        private bool isClosed;
        private IList responses;

        public Discussion(string title, string description)
        {
            this.title = title;
            this.description = description;
            date = DateTime.Now;
            isClosed = false;
            responses = new List<Response>();
        }

        public string GetTitle()
        {
            return title;
        }

        public void CreateResponse(string title, string text)
        {
            if(!isClosed)
            {
                Service service = new();
                INotificationEmail notification = new Adapter(service);

                notification.ConvertInformationToEmail("Reactie geplaatst bij: " + this.title + " - " + description);

                responses.Add(new Response(title, text));
            }
        }

        public IList GetResponses()
        {
            return responses;
        }

        public void CloseDiscussion()
        {
            isClosed = true;
        }

        public void SetTitle(string title)
        {
            if(!isClosed)
            {
                this.title = title;
            }
        }

        public void SetDescription(string description)
        {
            if (!isClosed)
            {
                this.description = description;
            }
        }

        public string GetDescription()
        {
            return description;
        }
    }
}