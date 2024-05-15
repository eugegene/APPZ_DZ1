using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ1_Visitor
{
    interface IVisitor
    {
        void Visit(ConcreteElementA element);
        void Visit(ConcreteElementB element);
    }

    class ConcreteVisitor : IVisitor
    {
        public void Visit(ConcreteElementA element)
        {
            element.OperationA();
        }

        public void Visit(ConcreteElementB element)
        { 
            element.OperationB();
        }
    }

    class ObjectStructure
    {
        public readonly IElement[] elements;

        public ObjectStructure()
        {
            elements = new IElement[]
            {
                new ConcreteElementA(),
                new ConcreteElementB()
            };
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var element in elements)
            {
                element.Accept(visitor);
            }
        }
    }
}
