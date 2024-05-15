using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1_Visitor
{
    interface IElement
    {
        void Accept(IVisitor visitor);
    }

    class ConcreteElementA : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void OperationA()
        {
            Console.WriteLine("Операція А в ConcreteElementA");
        }
    }

    class ConcreteElementB : IElement
    {
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public void OperationB()
        {
            Console.WriteLine("Операція B в ConcreteElementA");
        }
    }
}
