using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.GitActions
{
    public class Fork : IGitBehavior
    {
        public void Action()
        {
            Console.Write("Git Action: Fork wordt uitgevoerd. Code wordt nu geforkt.");
        }
    }
}
