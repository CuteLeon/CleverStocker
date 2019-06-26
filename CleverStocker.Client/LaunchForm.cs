using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using CleverStocker.Client.DockForms;
using CleverStocker.Client.Extensions;
using CleverStocker.Client.Interfaces;
using CleverStocker.Utils;

namespace CleverStocker.Client
{
    /// <summary>
    /// 启动窗口
    /// </summary>
    public partial class LaunchForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchForm"/> class.
        /// </summary>
        public LaunchForm()
        {
            LogHelper<LaunchForm>.Debug("启动窗口构造函数 ...");

            this.InitializeComponent();
            this.Icon = AppResource.Icon;
            this.Text = $"{Application.ProductName} 正在启动 ...";

            this.SetWindowShadow(true);
            this.AllowMouseDrag();

            LogHelper<LaunchForm>.Debug("启动窗口构造完成");
        }

        /// <summary>
        /// 启动窗口显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LaunchForm_Shown(object sender, EventArgs e)
        {
            LogHelper<LaunchForm>.Debug("启动窗口显示 ...");
            Application.DoEvents();

            LogHelper<LaunchForm>.Debug("启动应用程序 ...");
            DialogResult dialogResult = DialogResult.None;
            try
            {
                await this.LaunchApplication();

                LogHelper<LaunchForm>.Debug("启动应用程序完成 ...");
                dialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                this.UpdateProgress(ex.Message);
                LogHelper<LaunchForm>.ErrorException(ex, "启动应用程序失败：");

                dialogResult = DialogResult.Abort;
                throw;
            }
            finally
            {
                this.SetWindowShadow(false);
                this.DialogResult = dialogResult;
            }
        }

        /// <summary>
        /// 绘制窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LaunchLabel_Paint(object sender, PaintEventArgs e)
        {
            using (Brush linearGradientBrush = new LinearGradientBrush(
                this.LaunchLabel.ClientRectangle,
                Color.Transparent,
                Color.Black,
                LinearGradientMode.ForwardDiagonal))
            {
                e.Graphics.FillRectangle(linearGradientBrush, this.LaunchLabel.ClientRectangle);
            }
        }

        /// <summary>
        /// 更新进度
        /// </summary>
        /// <param name="message"></param>
        private void UpdateProgress(string message)
        {
            LogHelper<LaunchForm>.Debug($"进度 => {message}");

            this.LaunchLabel.Text = message;
            this.LaunchLabel.Refresh();
        }

        /// <summary>
        /// 更新进度
        /// </summary>
        /// <param name="message"></param>
        private void UpdateProgressAsync(string message)
        {
            if (this.LaunchLabel.InvokeRequired)
            {
                this.LaunchLabel.Invoke(new Action(() => this.UpdateProgress(message)));
            }
            else
            {
                this.UpdateProgress(message);
            }
        }

        /// <summary>
        /// 启动应用程序
        /// </summary>
        private async Task LaunchApplication()
            => await Task.WhenAll(
                    Task.Delay(1000),
                    Task.Factory.StartNew(() =>
                        {
                            this.UpdateProgressAsync("开始注册服务到依赖注入容器 ...");
                            DIContainerHelper.RegistServicesFromConfig();

                            LogHelper<Application>.Debug("创建主窗口 ...");
                            this.RegisterInitializableInstance<MainForm>();

                            LogHelper<Application>.Debug("创建自选股票窗口 ...");
                            this.RegisterInitializableInstance<SelfSelectStockForm>();

                            DIContainerHelper.Build();
                        }));

        /// <summary>
        /// 注册可初始化实例
        /// </summary>
        /// <typeparam name="TInitializable">实例类型</typeparam>
        private void RegisterInitializableInstance<TInitializable>()
            where TInitializable : class, IInitializable
        {
            TInitializable instance = (TInitializable)this.Invoke(new Func<TInitializable>(() => Activator.CreateInstance<TInitializable>()));
            DIContainerHelper.RegisteInstanceAsType<TInitializable, TInitializable>(instance);

            foreach (var message in instance.Initialize())
            {
                this.UpdateProgressAsync(message);
            }
        }
    }
}
