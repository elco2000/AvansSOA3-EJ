using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.GitActions
{
    public class PullRequest : IGitBehavior
    {
        public void Action()
        {
            Console.Write("Git Action: PullRequest wordt uitgevoerd. Code wordt nu gepusht naar de gewenste branch.");
        }
    }
}
