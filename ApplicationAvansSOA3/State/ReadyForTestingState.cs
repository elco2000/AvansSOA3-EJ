namespace ApplicationAvansSOA3.State
{
    public class ReadyForTestingState : IFaseState
    {
        private readonly BacklogItem backlogItem;

        public ReadyForTestingState(BacklogItem backlogItem)
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
            return this;
        }

        public IFaseState BacklogItemTested()
        {
            return new TestedState(backlogItem);
        }

        public IFaseState BacklogItemToDo()
        {
            return new ToDoState(backlogItem);
        }
    }
}
