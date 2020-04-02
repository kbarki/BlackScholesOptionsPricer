using NUnit.Framework;
using OptionsPricerGUI.Models;
using OptionsPricerGUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsPricerGUI.UnitTests
{

    [TestFixture]
    class OptionsPricerTests
    {

        // Test if ComputePrice() methode return the correct value for put option
        [TestCase(50, 55, 1, 0.2, 0.09, 4.1279)]
        [TestCase(64, 60, 0.49315, 0.27, 0.045, 2.4493)]
        public void ReturnTheCorrectValueOfPut(double S, double K,
                                               double t, double sigma,
                                               double r, double expectedPriceValue)
        {

            BlackScholesParametersModel inputs = new BlackScholesParametersModel(S, K, t, sigma, r);

            PutOption putOption = new PutOption();
            OptionModel put = putOption.GetOptionData(inputs);
            Assert.AreEqual(expectedPriceValue, put.Value, 0.0001);
        }

        // Test if ComputePrice() methode return the correct value for put option
        [TestCase(50, 55, 1, 0.2, 0.09, 4.1279)]
        [TestCase(64, 60, 0.49315, 0.27, 0.045, 2.4493)]
        public void ReturnTheCorrectValueOfCall(double S, double K,
                                               double t, double sigma,
                                               double r, double expectedPriceValue)
        {

            BlackScholesParametersModel inputs = new BlackScholesParametersModel(S, K, t, sigma, r);

            PutOption putOption = new PutOption();
            OptionModel put = putOption.GetOptionData(inputs);
            Assert.AreEqual(expectedPriceValue, put.Value, 0.0001);
        }
    }
}
