namespace ApplicationAvansSOA3.State
{
    public class ToDoState : IFaseState
    {
        private readonly BacklogItem backlogItem;

        public ToDoState(BacklogItem backlogItem)
        {
            this.backlogItem = backlogItem;
        }

        public IFaseState BacklogItemDoing()
        {
            return new DoingState(backlogItem);
        }

        public IFaseState BacklogItemDone(IMember member, bool backlogIsDone)
        {
            return this;
        }

        public IFaseState BacklogItemReadyForTesting()
        {
            return this;
        }

        public IFaseState BacklogItemTested()
        {
            return this;
        }

        public IFaseState BacklogItemToDo()
        {
            return this;
        }
    }
}
