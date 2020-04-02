using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsPricerGUI.Models
{
    public class OptionModel
    {
        public OptionsTypesEnum Type { get; set; }
        public double Value { get; set; }

        public OptionModel(OptionsTypesEnum optionType, double val)
        {
            Type = optionType;
            Value = val;
        }

    }
}
