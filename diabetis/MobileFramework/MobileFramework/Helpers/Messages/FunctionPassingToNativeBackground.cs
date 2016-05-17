using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileFramework.Helpers.Messages
{
    public class FunctionPassingToNativeBackground
    {
        public string FunctionName { get; set; }

        public List<object> Params { get; set; }

        public object ClassObject { get; set; }
        
    }
}
