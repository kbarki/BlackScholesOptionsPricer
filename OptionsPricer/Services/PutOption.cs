using OptionsPricerGUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsPricerGUI.Services
{
    public class PutOption : PriceableOption
    {
        public override OptionsTypesEnum OptionType => OptionsTypesEnum.Put;

        protected override double ComputeOptionPrice(BlackScholesParametersModel inputs, double d1, double d2)
        {
            return Math.Round((inputs.Strike * Math.Exp(-inputs.InterestRate * inputs.Time) * CND(-d2)) - (inputs.Stock * CND(-d1)), 4);
        }
    }
}
