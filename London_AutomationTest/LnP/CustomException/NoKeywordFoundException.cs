using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LnP.CustomException
{
    public class NoSuchKeywordFoundException : Exception
    {
        public NoSuchKeywordFoundException(string msg) : base(msg)
        {
            
        }
    }
}
