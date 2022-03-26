using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.AdapterNotification
{

    public class Adapter : INotificationEmail
    {
        private readonly Service _service;

        public Adapter(Service service)
        {
            _service = service;
        }

        public void ConvertInformationToEmail(string message)
        {
            string serviceText = $"{this._service.SendEmail()}";
            Console.Write(serviceText + message);
        }
    }
}
