using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Component obj = new ConcreteComponent();
            obj.Operation();
            Decorator objDecorator = new ConcreteDecorator();
            objDecorator.SetComponent(obj);
            objDecorator.Operation();
            Decorator objDecorator2 = new ConcreteDecorator2();
            objDecorator2.SetComponent(objDecorator);
            objDecorator2.Operation();
        }
    }

    abstract class Component {
        public abstract void Operation();

    }

    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteComponent");
        }
    }

    class Decorator : Component
    {
        protected Component component;
        public void SetComponent(Component obj) { component = obj; }
        public override void Operation()
        {
            Console.WriteLine("Decorator");
        }
    }

    class ConcreteDecorator : Decorator
    {
        public void AddonFunctionality() {
            Console.WriteLine("AddonFunctionality");
        }
        public override void Operation()
        {
            AddonFunctionality();
            Console.WriteLine(GetType().ToString());
        }

    }

    class ConcreteDecorator2 : Decorator
    {
        public override void Operation()
        {
            AddonFunctionality2();
            Console.WriteLine(GetType().ToString());
         }
        public void AddonFunctionality2() {
            Console.WriteLine("AddonFunctionality2");
        }

    }

}
