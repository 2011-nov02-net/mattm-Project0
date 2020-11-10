using System;
using Figgle;
using System.Collections.Generic;
using System.Text;

namespace StoreConsoleApp
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
    }
}
