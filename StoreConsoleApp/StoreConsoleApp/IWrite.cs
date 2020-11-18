using System;
using Figgle;
using System.Collections.Generic;
using System.Text;

namespace Store.ConsoleApp
{
    interface IWrite
    {
        public static void writeStatement(string message)
        {
            Console.WriteLine(message);
        }

        public static void writeTitle(string title)
        {
            Console.WriteLine(FiggleFonts.Standard.Render(title));
        }
    }
}
