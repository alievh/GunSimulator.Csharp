using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.ExceptionsFolder
{
    public class NotAcceptableInput : Exception
    {
        public NotAcceptableInput(string message) : base(message)
        {
            
        }
        public static void Show(string message)
        {
            Console.WriteLine("Please enter only number!");
        }
    }
}
