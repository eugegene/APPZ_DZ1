using System.Text;

namespace DZ1_Visitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.InputEncoding = System.Text.Encoding.GetEncoding(1251);
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1251);

            ObjectStructure objectStructure = new ObjectStructure();
            IVisitor visitor = new ConcreteVisitor();

            objectStructure.Accept(visitor);

            Console.ReadLine();
        }
    }
}
