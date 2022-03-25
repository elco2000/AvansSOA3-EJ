namespace ApplicationAvansSOA3.State
{
    public class TestedState : IFaseState
    {
        private readonly BacklogItem backlogItem;

        public TestedState(BacklogItem backlogItem)
        {
            this.backlogItem = backlogItem;
        }

        public IFaseState BacklogItemDoing()
        {
            return this;
        }

        public IFaseState BacklogItemDone()
        {
            return new DoneState(backlogItem);
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
