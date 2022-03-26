﻿using ApplicationAvansSOA3.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3
{
    public interface IMember : ISubscriber
    {
        public void SetName(string name);
        public string GetName();
        public void SetRole(string role);
        public string GetRole();

    }
}
