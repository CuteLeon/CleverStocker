using System;
using System.Windows.Forms;
using CleverStocker.Utils;

namespace CleverStocker.Client
{
    /// <summary>
    /// Program
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            LogHelper<Application>.Debug("程序启动 ...");

#if !DEBUG
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;
#endif
            Application.ApplicationExit += Application_ApplicationExit;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DialogResult launchResult = DialogResult.None;
            LogHelper<Application>.Debug("创建启动窗口 ...");
            using (var launcher = new LaunchForm())
            {
                LogHelper<Application>.Debug("显示启动窗口 ...");
                launchResult = launcher.ShowDialog();
                LogHelper<Application>.Debug($"启动窗口返回：{launchResult.ToString()}");
            }

            switch (launchResult)
            {
                case DialogResult.None:
                case DialogResult.OK:
                case DialogResult.Ignore:
                case DialogResult.Yes:
                    {
                        LogHelper<Application>.Debug("创建主窗口 ...");
                        Form mainForm = new MainForm();

                        LogHelper<Application>.Debug("运行主窗口 ...");
                        Application.Run(mainForm);

                        break;
                    }

                case DialogResult.Cancel:
                case DialogResult.Abort:
                case DialogResult.Retry:
                case DialogResult.No:
                    {
                        LogHelper<Application>.Debug("关闭应用程序 ...");
                        Environment.Exit(-1);

                        break;
                    }

                default:
                    break;
            }
        }

        /// <summary>
        /// 应用程序退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            LogHelper<Application>.Debug($"应用程序退出 ...");
        }

        /// <summary>
        /// 应用程序异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogHelper<Exception>.ErrorException(e.Exception, $"应用遇到未捕捉异常：");

            MessageBox.Show(
                $"应用遇到未捕捉异常：\n{e.Exception.Message}",
                "应用遇到未捕捉异常",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        /// <summary>
        /// 当前域异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogHelper<Exception>.ErrorException(e.ExceptionObject as Exception, $"当前应用域遇到未捕捉异常 {(e.IsTerminating ? "(程序即将退出)" : string.Empty)}：");

            MessageBox.Show(
                $"当前应用域遇到未捕捉异常：\n{(e.ExceptionObject as Exception)?.Message}",
                "当前应用域遇到未捕捉异常",
                MessageBoxButtons.OK,
                e.IsTerminating ? MessageBoxIcon.Error : MessageBoxIcon.Warning);
        }
    }
}
