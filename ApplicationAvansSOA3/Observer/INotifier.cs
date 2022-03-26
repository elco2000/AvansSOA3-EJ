using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationAvansSOA3;

namespace ApplicationAvansSOA3.Observer
{
    public interface INotifier
    {
        void Subscribe(IMember subscriber);
        void Unsubscribe(IMember subscriber);
        void Notify(string role, string message);
    }
}
