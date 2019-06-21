using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleverStocker.Client
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var launcher = new LaunchForm())
            {
                switch (launcher.ShowDialog())
                {
                    case DialogResult.None:
                    case DialogResult.OK:
                    case DialogResult.Ignore:
                    case DialogResult.Yes:
                        {
                            Application.Run(new MainForm());

                            break;
                        }
                    case DialogResult.Cancel:
                    case DialogResult.Abort:
                    case DialogResult.Retry:
                    case DialogResult.No:
                        {
                            Environment.Exit(-1);

                            break;
                        }
                    default:
                        break;
                }
            }
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
