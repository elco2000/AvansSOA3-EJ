namespace ApplicationAvansSOA3.State
{
    public class DoingState : IFaseState
    {
        private readonly BacklogItem backlogItem;

        public DoingState(BacklogItem backlogItem)
        {
            this.backlogItem = backlogItem;
        }

        public IFaseState BacklogItemDoing()
        {
            return this;
        }

        public IFaseState BacklogItemDone(IMember member)
        {
            return this;
        }

        public IFaseState BacklogItemReadyForTesting()
        {
            return new ReadyForTestingState(backlogItem);
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
