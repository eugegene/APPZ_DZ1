from abc import ABC, abstractmethod

class IElement(ABC):
    @abstractmethod
    def Accept(self, visitor):
        pass

class ConcreteElementA(IElement):
    def Accept(self, visitor):
        visitor.Visit(self)

    def OperationA(self):
        print("Операція А в ConcreteElementA")

class ConcreteElementB(IElement):
    def Accept(self, visitor):
        visitor.Visit(self)

    def OperationB(self):
        print("Операція B в ConcreteElementB")

class IVisitor(ABC):
    @abstractmethod
    def Visit(self, element):
        pass

class ConcreteVisitor(IVisitor):
    def Visit(self, element):
        element.OperationA() if isinstance(element, ConcreteElementA) else element.OperationB()

class ObjectStructure:
    def __init__(self):
        self.elements = [
            ConcreteElementA(),
            ConcreteElementB()
        ]

    def Accept(self, visitor):
        for element in self.elements:
            element.Accept(visitor)

if __name__ == "__main__":
    objectStructure = ObjectStructure()
    visitor = ConcreteVisitor()
    objectStructure.Accept(visitor)