using System;
using Figgle;
using System.Collections.Generic;
using System.Text;
using Store.Library

namespace Store.ConsoleApp
{
    class Writer
    {

        public void writeStatement(string message)
        {
            Console.WriteLine(message);
        }

        public void writeTitle(string title)
        {
            Console.WriteLine(FiggleFonts.Standard.Render(title));
        }

        public void listProducts(Product name)
        {
            Console.WriteLine($"Product:{name.name}  ID:{name.productId")
        }
    }
}
