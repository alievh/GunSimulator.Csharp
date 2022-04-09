using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions.ExceptionsFolder
{
    public class NotAcceptableInput : Exception
    {
        public NotAcceptableInput(string message)
        {
            Console.WriteLine("Invalid Input!\n" +
                              "Please TryAgain!");
        }
    }
}
