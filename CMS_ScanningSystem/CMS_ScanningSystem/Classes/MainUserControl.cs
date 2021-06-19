using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMS_ScanningSystem.Classes
{
    class MainUserControl
    {
        public static void ShowControl(Control control, Control content)
        {
            content.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.BringToFront();
            control.Focus();
            content.Controls.Add(control);
        }
    }
}
