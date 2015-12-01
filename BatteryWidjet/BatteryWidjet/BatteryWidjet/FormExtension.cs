using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PresentationLayer
{
    internal static class FormExtension
    {
        public static void SetFormBackColor(this Form form, Color color)
        {
            form.BackColor = color;
        }

        public static void SetLabelText(this Label label, string text)
        {
            label.Text = text;
        }

        public static void SetProgressBarValue(this ProgressBar progBar, int value)
        {
            progBar.Value = value;  
        }

        public static void SetRadioButtonChecked(this RadioButton radioBtn, bool value)
        {
            radioBtn.Checked = value;
        }

        public static void SetCheckBoxChecked(this CheckBox checkBox, bool value)
        {
            checkBox.Checked = value;
        }
    }
}
