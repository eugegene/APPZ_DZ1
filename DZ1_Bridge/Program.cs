using System.Text;

namespace DZ1_Bridge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.InputEncoding = System.Text.Encoding.GetEncoding(1251);
            Console.OutputEncoding = System.Text.Encoding.GetEncoding(1251);

            Shape blueTriangle = new Triangle(10, 10, 10, new DrawBlueTriangle());
            Shape greenTriangle = new Triangle(8, 9, 10, new DrawGreenTriangle());

            blueTriangle.Draw();
            greenTriangle.Draw();
        }
    }
}
