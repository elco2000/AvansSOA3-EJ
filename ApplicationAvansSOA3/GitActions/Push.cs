using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.GitActions
{
    public class Push : IGitBehavior
    {
        public void Action()
        {
            Console.Write("Git Action: Push wordt uitgevoerd. Code wordt nu gepusht.");
        }
    }
}
