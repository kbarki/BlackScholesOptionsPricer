using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsPricerGUI.Models
{
    public class BlackScholesParametersModel
    {
        public double Stock { get; set; }
        public double Strike { get; set; }
        public double Time { get; set; }
        public double Volatility { get; set; }
        public double InterestRate { get; set; }

        public IDictionary<string,double> InputParametersDict
        {
            get
            {
                return new Dictionary<string, double>()
                {
                    { "Stock" , Stock },
                    { "Strike" , Strike },
                    { "Time" , Time },
                    { "Volatility" , Volatility },
                    { "InterestRate" , InterestRate },
                };
            }
        }

        public BlackScholesParametersModel(double S, double K, double t, double sigma, double r)
        {
            Stock = S;
            Strike = K;
            Time = t;
            Volatility = sigma;
            InterestRate = r;
        }

        public BlackScholesParametersModel()
        {

        }
    }
}
