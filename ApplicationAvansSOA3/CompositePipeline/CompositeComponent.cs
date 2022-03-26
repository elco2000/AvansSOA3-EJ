using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationAvansSOA3.CompositePipeline
{
    public class CompositeComponent : Component
    {
        private IList<Component> components;

        public CompositeComponent()
        {
            components = new List<Component>();
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
        }

        public override void AcceptVisitor(Visitor visitor)
        {
            foreach(Component comp in components)
            {
                comp.AcceptVisitor(visitor);
            }
        }
    }
}
