using OptionsPricerGUI.Models;
using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace OptionsPricerGUI.Services
{
    public abstract class PriceableOption : IPriceableOption
    {
        private static readonly Chart _chart = new Chart();

        public abstract OptionsTypesEnum OptionType { get; }

        public OptionModel GetOptionData(BlackScholesParametersModel inputs)
        {
            try
            {
                double d1 = ComputeD1(inputs);
                double d2 = ComputeD2(inputs, d1);
                double optionPrice = ComputeOptionPrice(inputs, d1, d2);

                return new OptionModel(OptionType, optionPrice);
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected abstract double ComputeOptionPrice(BlackScholesParametersModel inputs, double d1, double d2);

        // This method compute the cumulative normal distribution of x 
        protected double CND(double x)
        {
            return _chart.DataManipulator.Statistics.NormalDistribution(x);
        }

        protected double ComputeD1(BlackScholesParametersModel inputs)
        {
            return (Math.Log(inputs.Stock / inputs.Strike) + (inputs.InterestRate + (Math.Pow(inputs.Volatility, 2) / 2)) * inputs.Time) / (inputs.Volatility * Math.Sqrt(inputs.Time));
        }

        protected double ComputeD2(BlackScholesParametersModel inputs, double d1)
        {
            return (d1 - (inputs.Volatility * Math.Sqrt(inputs.Time)));
        }

        // This method compute d1 and d2 values and return a tuple <d1,d2>
        //private Tuple<double, double> ComputeDOneAndDTwo(InputParametersModel inputs)
        //{
        //    double d1;
        //    double d2;
        //    d1 = (Math.Log(inputs.Stock / inputs.Strike) + (inputs.InterestRate + (Math.Pow(inputs.Volatility, 2) / 2)) * inputs.Time) / (inputs.Volatility * Math.Sqrt(inputs.Time));
        //    d2 = d1 - (inputs.Volatility * Math.Sqrt(inputs.Time));
        //    return new Tuple<double, double>(d1, d2);
        //}
    }
}
