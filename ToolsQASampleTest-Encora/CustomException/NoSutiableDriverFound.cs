using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQASampleTest_Encora.CustomException
{
    public class NoSutiableDriverFound : Exception
    {
        public NoSutiableDriverFound(string mesg) : base(string.Format("Invalid browser object", mesg))
        {

        }
    }
}
