﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using CleverStocker.Client.DockForms;
using CleverStocker.Common.Extensions;
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
            LogHelper<LaunchForm>.Debug($"更新进度 => {message}");

            this.LaunchLabel.Text = message;
            this.LaunchLabel.Refresh();
        }

        /// <summary>
        /// 更新进度
        /// </summary>
        /// <param name="message"></param>
        private void UpdateProgressAsync(string message)
        {
            LogHelper<LaunchForm>.Debug($"异步更新进度 => {message}");

            this.LaunchLabel.Invoke(new Action(() =>
            {
                this.LaunchLabel.Text = message;
                this.LaunchLabel.Refresh();
            }));
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

                            this.UpdateProgressAsync("创建主窗口 ...");
                            MainForm mainForm = (MainForm)this.Invoke(new Func<MainForm>(() => new MainForm()));
                            DIContainerHelper.RegisteInstanceAsType<MainForm, MainForm>(mainForm);
                            foreach (var message in mainForm.Initialize())
                            {
                                this.UpdateProgressAsync(message);
                            }

                            this.UpdateProgressAsync("创建自选股票窗口 ...");
                            this.RegisterSingleDockFormInstance<SelfSelectStockForm>(mainForm);

                            this.UpdateProgressAsync("创建推荐股票窗口 ...");
                            this.RegisterSingleDockFormInstance<RecommendStockForm>(mainForm);

                            this.UpdateProgressAsync("创建实时行情窗口 ...");
                            this.RegisterSingleDockFormInstance<CurrentQuotaForm>(mainForm);

                            this.UpdateProgressAsync("创建大盘指数窗口 ...");
                            this.RegisterSingleDockFormInstance<MarketQuotaForm>(mainForm);

                            this.UpdateProgressAsync("创建公司信息窗口 ...");
                            this.RegisterSingleDockFormInstance<CompanyInfoForm>(mainForm);

                            this.UpdateProgressAsync("创建最近交易窗口 ...");
                            this.RegisterSingleDockFormInstance<RecentTradeForm>(mainForm);

                            this.UpdateProgressAsync("创建最近行情窗口 ...");
                            this.RegisterSingleDockFormInstance<RecentQuotaForm>(mainForm);

                            this.UpdateProgressAsync($"密封服务容器 ...");
                            DIContainerHelper.Build();
                        }));

        /// <summary>
        /// 注册单实例停靠窗口实例
        /// </summary>
        /// <typeparam name="TDockForm">停靠窗口类型</typeparam>
        /// <param name="mainForm"></param>
        private void RegisterSingleDockFormInstance<TDockForm>(MainForm mainForm)
            where TDockForm : DockFormBase
        {
            TDockForm instance = null;
            this.Invoke(new Action(() =>
            {
                instance = Activator.CreateInstance<TDockForm>();

                mainForm.RegisterDockFormToViewMenu<TDockForm>(
                    instance.Text,
                    Bitmap.FromHicon(instance.Icon.Handle));
            }));

            DIContainerHelper.RegisteInstanceAsType<TDockForm, TDockForm>(instance);

            foreach (var message in instance.Initialize())
            {
                this.UpdateProgressAsync(message);
            }
        }
    }
}
