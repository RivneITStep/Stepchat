using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace StepChat.Custom_Element.CustomMessageBox
{
    public static class CustomMessageBox
    {
        [DllImport("winmm.dll")]
        public static extern bool PlaySound(string pszSound, UIntPtr hmod, uint fdwSound);
        public static void Show(string message)
        {
            Custom_Element.MessageBox m = new Custom_Element.MessageBox();
            PlaySound(@"C:\WINDOWS\Media\town.wav", UIntPtr.Zero, 0);
            m.SetMessage(message);
            m.Show();
        }
    }
}
