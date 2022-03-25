using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.GitActions
{
    public class Status : IGitBehavior
    {
        public void Action()
        {
            Console.Write("Git Action: Status wordt uitgevoerd. De status van de git is positief.");
        }
    }
}
