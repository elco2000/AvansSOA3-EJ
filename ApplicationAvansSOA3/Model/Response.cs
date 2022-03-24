namespace ApplicationAvansSOA3
{
    public class Response
    {
        private readonly string title;
        private readonly string text;
        private readonly DateTime date;

        public Response(string title, string text)
        {
            this.title = title;
            this.text = text;
            this.date = DateTime.Now;
        }
    }
}
