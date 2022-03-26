using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.Observer
{
    public interface ISubscriber
    {
        void Update(string message);
    }
}
