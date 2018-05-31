using System;
using System.Threading;
using System.Windows.Forms;

namespace HCalc
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {

            using (var mutex = new Mutex(true, "9ab6287c-ccbd-4a79-ab8c-71aa22cc886b", out var createNew))
            {
                if (createNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormMain());
                }
                else
                {
                    var hWnd = NativeMethods.FindWindow(null, FormMain.DirtyWinTitle);
                    if (hWnd != IntPtr.Zero)
                    {
                        NativeMethods.ShowWindow(hWnd, NativeMethods.SW_RESTORE);
                        NativeMethods.SetForegroundWindow(hWnd);
                    }
                    Environment.Exit(0);
                }
            }



        }
    }
}
