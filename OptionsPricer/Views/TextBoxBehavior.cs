using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OptionsPricerGUI.Views
{

    public static partial class TextBoxBehavior
    {
        public static readonly DependencyProperty IsNumericInputProperty = DependencyProperty.RegisterAttached(
            "IsNumericInput",
            typeof(bool),
            typeof(TextBoxBehavior),
            new FrameworkPropertyMetadata(false, OnIsNumericInputChanged));

        public static bool GetIsNumericInput(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsNumericInputProperty);
        }

        public static void SetIsNumericInput(DependencyObject obj, bool value)
        {
            obj.SetValue(IsNumericInputProperty, value);
        }

        private static void OnIsNumericInputChanged(DependencyObject owner, DependencyPropertyChangedEventArgs args)
        {
            Control textBox = owner as TextBox;
            bool? isNumericInput = args.NewValue as bool?;

            if (isNumericInput == null || textBox == null)
                return;

            if (isNumericInput ?? false)
            {
                textBox.PreviewTextInput += OnNumericInputPreviewTextInputHandler;
            }
            else
            {
                textBox.PreviewTextInput -= OnNumericInputPreviewTextInputHandler;
            }
        }

        private static readonly TextCompositionEventHandler OnNumericInputPreviewTextInputHandler = new TextCompositionEventHandler(OnTextBox_PreviewTextInput);

        private static void OnTextBox_PreviewTextInput(object sender, TextCompositionEventArgs args)
        {
            Control control = sender as TextBox;
            if (control == null)
                return;

            if (string.IsNullOrEmpty(args.Text))
                return;

            Regex reg = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            args.Handled = !reg.IsMatch(args.Text);
        }
    }
}
