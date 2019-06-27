using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CleverStocker.Common.Extensions
{
    /// <summary>
    /// 窗口扩展
    /// </summary>
    public static class FormExtension
    {
        private const int WMNCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        private const int CSDROPSHADOW = 0x20000;
        private const int GCLSTYLE = -26;

        /// <summary>
        /// SetClassLong
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="nIndex"></param>
        /// <param name="dwNewLong"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);

        /// <summary>
        /// GetClassLong
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="nIndex"></param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetClassLong(IntPtr hwnd, int nIndex);

        /// <summary>
        /// SendMessage
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        /// <summary>
        /// ReleaseCapture
        /// </summary>
        /// <returns></returns>
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        /// <summary>
        /// 设置窗口阴影
        /// </summary>
        /// <param name="form"></param>
        /// <param name="shadow"></param>
        public static void SetWindowShadow(this Form form, bool shadow)
        {
            if (form == null)
            {
                return;
            }

            if (shadow)
            {
                SetClassLong(form.Handle, GCLSTYLE, GetClassLong(form.Handle, GCLSTYLE) | CSDROPSHADOW);
            }
            else
            {
                SetClassLong(form.Handle, GCLSTYLE, GetClassLong(form.Handle, GCLSTYLE) & ~CSDROPSHADOW);
            }
        }

        /// <summary>
        /// 使用鼠标拖动
        /// </summary>
        /// <param name="control"></param>
        public static void AllowMouseDrag(this Control control)
        {
            if (control == null)
            {
                return;
            }

            control.MouseDown += new MouseEventHandler((sender, e) =>
            {
                ReleaseCapture();
                SendMessage(
                    control is Form form ? form.Handle : control.FindForm().Handle,
                    WMNCLBUTTONDOWN,
                    HTCAPTION,
                    0);
            });
        }
    }
}
