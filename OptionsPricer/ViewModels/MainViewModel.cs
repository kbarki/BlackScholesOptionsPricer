using Caliburn.Micro;
using OptionsPricerGUI.Models;
using OptionsPricerGUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsPricerGUI.ViewModels
{
    class MainViewModel : Screen
    {
        private BlackScholesParametersModel _inputs;

        public BlackScholesParametersModel Inputs
        {
            get
            {
                return _inputs;
            }
            set
            {
                _inputs = value;
                NotifyOfPropertyChange<BlackScholesParametersModel>(() => Inputs);
            }
        }

        public MainViewModel()
        {
            Inputs = new BlackScholesParametersModel();
        }

        private OptionModel _call;

        public OptionModel Call
        {
            get { return _call; }
            set 
            { 
                _call = value;
                NotifyOfPropertyChange<OptionModel>(() => Call);
            }
        }

        private OptionModel _put;

        public OptionModel Put
        {
            get { return _put; }
            set
            {
                _put = value;
                NotifyOfPropertyChange<OptionModel>(() => Put);
            }
        }

        private string _appStatus;

        public string AppStatus
        {
            get { return _appStatus; }
            set 
            { 
                _appStatus = value; 
            }
        }


        public void ComputeOptionsPrice()
        {
            try
            {
                if (!UsefulTools.IsBlackScholesVariablesValid(Inputs.InputParametersDict.Values.ToList()))
                {
                    UpdateAppStatus("Invalid input, Please enter all five variables.");
                    return;
                }

                CallOption callOption = new CallOption();
                Call = callOption.GetOptionData(Inputs);

                PutOption putOption = new PutOption();
                Put = putOption.GetOptionData(Inputs);

                UpdateAppStatus("Compute operation successfully completed.");
            }
            catch (Exception ex)
            {
                UpdateAppStatus(ex.Message);
            }
        }

        public void Reset()
        {
            try
            {
                Inputs = new BlackScholesParametersModel();
                Call = null;
                Put = null;

                UpdateAppStatus("Reset operation successfully completed.");
            }
            catch (Exception ex)
            {
                UpdateAppStatus(ex.Message);
            }
        }

        private void UpdateAppStatus(string msg)
        {
            AppStatus = msg;
            NotifyOfPropertyChange(() => AppStatus);
        }
    }
}
