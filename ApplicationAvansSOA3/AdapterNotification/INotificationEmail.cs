using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.AdapterNotification
{
    public interface INotificationEmail
    {
        public void ConvertInformationToEmail(string message);
    }
}
