using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Exceptions
{
    public class StudentInvalidlevelRaiseException : Exception
    {
        public int InvalidRaise { get; private set; }
        public StudentInvalidlevelRaiseException(string message, int raise) :
            base(message)
        {
            InvalidRaise = raise;
        }
    }
}
