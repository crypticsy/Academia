using System;
using System.Windows.Forms;

namespace Hermes
{
    public class TablessControl : TabControl
    {
        public TablessControl()
        {
            
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x1328 && !DesignMode)
            {
                m.Result = (IntPtr)1;
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
