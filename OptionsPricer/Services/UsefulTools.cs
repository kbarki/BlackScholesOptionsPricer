using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsPricerGUI.Services
{
    public static class UsefulTools
    {
        public static bool IsBlackScholesVariablesValid(IEnumerable<double> inputs)
        {
            if(inputs.Any(x => x == 0))
            {
                return false;
            }
            return true;
        }
    }
}
