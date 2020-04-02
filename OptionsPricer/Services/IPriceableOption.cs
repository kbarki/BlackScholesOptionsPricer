using OptionsPricerGUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsPricerGUI.Services
{
    interface IPriceableOption
    {
        OptionsTypesEnum OptionType { get; }
        OptionModel GetOptionData(BlackScholesParametersModel inputs);
    }
}
