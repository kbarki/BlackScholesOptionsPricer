using NUnit.Framework;
using OptionsPricerGUI.Models;
using OptionsPricerGUI.Services;
using OptionsPricerGUI.ViewModels;
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

        // Test if GetOptionData() methode return the correct value for put option
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

        // Test if GetOptionData() methode return the correct value for call option
        [TestCase(50, 55, 1, 0.2, 0.09, 3.8617)]
        [TestCase(64, 60, 0.49315, 0.27, 0.045, 7.7661)]
        public void ReturnTheCorrectValueOfCall(double S, double K,
                                               double t, double sigma,
                                               double r, double expectedPriceValue)
        {

            BlackScholesParametersModel inputs = new BlackScholesParametersModel(S, K, t, sigma, r);

            CallOption callOption = new CallOption();
            OptionModel call = callOption.GetOptionData(inputs);
            Assert.AreEqual(expectedPriceValue, call.Value, 0.0001);
        }

        // Test user input validation
        [TestCase(0, 0, 0, 0, 0)]
        public void CheckInvalidUserInput(double S, double K, double t, double sigma, double r)
        {

            BlackScholesParametersModel inputs = new BlackScholesParametersModel(S, K, t, sigma, r);
            Assert.IsFalse(UsefulTools.IsBlackScholesVariablesValid(new List<double>() { S, K, t, sigma, r }));
        }

        // Test user input validation
        [TestCase(61, 42, 0.3, 0.7, 0)]
        public void CheckInvalidUserInput2(double S, double K, double t, double sigma, double r)
        {

            BlackScholesParametersModel inputs = new BlackScholesParametersModel(S, K, t, sigma, r);
            Assert.IsFalse(UsefulTools.IsBlackScholesVariablesValid(new List<double>() { S, K, t, sigma, r }));
        }

        // Test user input validation
        [TestCase(40, 43, 0.6, 0.5, 0.01)]
        public void CheckValidUserInput(double S, double K, double t, double sigma, double r)
        {

            BlackScholesParametersModel inputs = new BlackScholesParametersModel(S, K, t, sigma, r);
            Assert.IsTrue(UsefulTools.IsBlackScholesVariablesValid(new List<double>() { S, K, t, sigma, r }));
        }

        // Test reset option
        [TestCase(40, 43, 0.6, 0.5, 0.01)]
        public void TestResetCalculator(double S, double K, double t, double sigma, double r)
        {

            BlackScholesParametersModel inputs = new BlackScholesParametersModel(S, K, t, sigma, r);

            MainViewModel mvm = new MainViewModel
            {
                Inputs = inputs
            };
            mvm.ComputeOptionsPrice();
            mvm.Reset();

            Assert.IsNull(mvm.Call);
            Assert.IsNull(mvm.Put);
            Assert.IsFalse(UsefulTools.IsBlackScholesVariablesValid(mvm.Inputs.InputParametersDict.Values.ToList()));
        }
    }
}
