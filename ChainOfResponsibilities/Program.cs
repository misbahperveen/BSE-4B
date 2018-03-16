using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibilities
{
    class Program
    {
        static void Main(string[] args)
        {

            Handler obj = new ConcreateHandler();
            Handler obj1 = new ConcreateHandler1();
            Handler obj2 = new ConcreateHandler2();
            obj.SetSuccessor(obj1);
            obj1.SetSuccessor(obj2);

            obj.RequestHandler(12);
            obj.RequestHandler(5);
            obj.RequestHandler(21);
        }
    }


    abstract class Handler
    {
        protected Handler successor;

        public abstract void RequestHandler(int val);

        public void SetSuccessor(Handler obj)
        {
            successor = obj;
        }
    }

    class ConcreateHandler : Handler
    {
        public override void RequestHandler(int val)
        {
            if (val > 0 && val < 10)
            {
                Console.WriteLine("Request Handled "+ this.GetType().ToString());
            }
            else
            {
                successor.RequestHandler(val);
            }
        }
    }

    class ConcreateHandler1 : Handler
    {
        public override void RequestHandler(int val)
        {
            if (val > 10 && val < 20)
            {
                Console.WriteLine("Request Handled " + this.GetType().ToString());
            }
            else
            {
                successor.RequestHandler(val);
            }
        }
    }

    class ConcreateHandler2 : Handler
    {
        public override void RequestHandler(int val)
        {
            if (val > 20 && val < 30)
            {
                Console.WriteLine("Request Handled " + this.GetType().ToString());
            }
            else
            {
                successor.RequestHandler(val);
            }
        }
    }
}
