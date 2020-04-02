using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OptionsPricerGUI.Views
{
    public class AutoFocusTextBox : TextBox
    {
        public AutoFocusTextBox()
        {
            GotFocus += (sender, e) => SelectAll();
            GotMouseCapture += (sender, e) => SelectAll();
        }
    }
}
