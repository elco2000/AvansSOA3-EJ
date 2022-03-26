using System.Collections;

namespace ApplicationAvansSOA3
{
    public class Backlog
    {
        private string title;
        private string description;
        private readonly SortedList<int, BacklogItem> backlogItems;
        private int nrBacklogItem;

        public Backlog(string title, string description)
        {
            this.title = title;
            this.description = description;
            this.backlogItems = new SortedList<int, BacklogItem>();
            this.nrBacklogItem = 1;
        }

        public void AddBacklogItem(BacklogItem backlogItem)
        {
            backlogItems.Add(this.nrBacklogItem, backlogItem);
            nrBacklogItem++;
        }

        public SortedList<int, BacklogItem> getBacklogItems()
        {
            return backlogItems;
        }
    }
}