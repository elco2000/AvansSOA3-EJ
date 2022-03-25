using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.State
{
    public interface IFaseState
    {
        public IFaseState BacklogItemTested();
        public IFaseState BacklogItemToDo();
        public IFaseState BacklogItemDone(IMember member, bool backlogIsDone);
        public IFaseState BacklogItemDoing();
        public IFaseState BacklogItemReadyForTesting();
    }
}
