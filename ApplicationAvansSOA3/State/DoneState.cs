namespace ApplicationAvansSOA3.State
{
    public class DoneState : IFaseState
    {
        private readonly BacklogItem backlogItem;

        public DoneState(BacklogItem backlogItem)
        {
            this.backlogItem = backlogItem;
        }

        public IFaseState BacklogItemDoing()
        {
            return this;
        }

        public IFaseState BacklogItemDone()
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
