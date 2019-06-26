using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using CleverStocker.Client.DockForms;
using CleverStocker.Client.Interfaces;
using CleverStocker.Model;
using CleverStocker.Services;
using CleverStocker.Utils;
using WeifenLuo.WinFormsUI.Docking;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Client
{
    /// <summary>
    /// 主窗口
    /// </summary>
    public partial class MainForm : Form, IInitializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();

            this.Icon = AppResource.Icon;
            this.Text = Application.ProductName;

            this.IsMdiContainer = true;
            this.MainDockPanel.DocumentStyle = DocumentStyle.DockingMdi;
            this.MainDockPanel.DocumentTabStripLocation = DocumentTabStripLocation.Top;
            this.MainDockPanel.ShowDocumentIcon = true;

            this.ClassicsThemeMenuItem.Checked = true;
            this.SwitchTheme(Themes.Dark);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Initialize()
        {
            yield break;
        }

        private void TestToolItem_Click(object sender, EventArgs e)
        {
            var stockService = DIContainerHelper.Resolve<IStockerSpiderService>();
            var stock = stockService.GetStock(Markets.ShangHai, "600086");

            /*
            var service = new StockerService();
            service.Add(new Stock() { Code = Guid.NewGuid().ToString(), Market = "sz", Name = "深圳123" });
            var count = service.Transact<Func<int>, int>(() => service.AsQueryable().Count());
            var test = service.AsQueryable().Where(s => s.Market == "sz").ToArray();
            MessageBox.Show($"{stockService.GetType().FullName} => {stocks.Count()}\n{service.GetType().FullName} => {count}");
             */
        }

        #region 主题
        private void ClassicsThemeMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.ClassicsThemeMenuItem.Checked)
            {
                this.SwitchTheme(Themes.Classics);
            }
        }

        private void LightThemeMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.LightThemeMenuItem.Checked)
            {
                this.SwitchTheme(Themes.Light);
            }
        }

        private void BlueThemeMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.BlueThemeMenuItem.Checked)
            {
                this.SwitchTheme(Themes.Blue);
            }
        }

        private void DarkThemeMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.DarkThemeMenuItem.Checked)
            {
                this.SwitchTheme(Themes.Dark);
            }
        }

        /// <summary>
        /// 切换主题
        /// </summary>
        /// <param name="theme">
        public void SwitchTheme(Themes theme)
        {
            // 框架限制：切换主题需要关闭所有的 Pane (窗格)
            if (this.MainDockPanel.Panes.Count > 0)
            {
                // TODO: 立即保存当前布局到文件，然后关闭所有 Pane ，再从文件读入以恢复布局，即可解决此限制
                MessageBox.Show("请先关闭工作区内的所有窗格后再尝试切换主题。");
                return;
            }

            switch (theme)
            {
                case Themes.Classics:
                    {
                        this.ClassicsThemeMenuItem.Checked = true;
                        this.LightThemeMenuItem.Checked = false;
                        this.BlueThemeMenuItem.Checked = false;
                        this.DarkThemeMenuItem.Checked = false;

                        this.MainDockPanel.Theme.Dispose();
                        this.MainDockPanel.Theme = new VS2005Theme();

                        break;
                    }

                case Themes.Light:
                    {
                        this.ClassicsThemeMenuItem.Checked = false;
                        this.LightThemeMenuItem.Checked = true;
                        this.BlueThemeMenuItem.Checked = false;
                        this.DarkThemeMenuItem.Checked = false;

                        this.MainDockPanel.Theme.Dispose();
                        this.MainDockPanel.Theme = new VS2015LightTheme();

                        break;
                    }

                case Themes.Blue:
                    {
                        this.ClassicsThemeMenuItem.Checked = false;
                        this.LightThemeMenuItem.Checked = false;
                        this.BlueThemeMenuItem.Checked = true;
                        this.DarkThemeMenuItem.Checked = false;

                        this.MainDockPanel.Theme.Dispose();
                        this.MainDockPanel.Theme = new VS2015BlueTheme();

                        break;
                    }

                case Themes.Dark:
                    {
                        this.ClassicsThemeMenuItem.Checked = false;
                        this.LightThemeMenuItem.Checked = false;
                        this.BlueThemeMenuItem.Checked = false;
                        this.DarkThemeMenuItem.Checked = true;

                        this.MainDockPanel.Theme.Dispose();
                        this.MainDockPanel.Theme = new VS2015DarkTheme();

                        break;
                    }

                default:
                    break;
            }

            this.MainDockPanel.Theme.ApplyTo(this.MainTopMenuStrip);
            this.MainDockPanel.Theme.ApplyTo(this.MainToolStrip);
            this.MainDockPanel.Theme.ApplyTo(this.MainStatusStrip);
        }
        #endregion

        #region 显示

        private void MainForm_Shown(object sender, EventArgs e)
        {
            // TODO: 读取文件以尝试恢复布局
            DIContainerHelper.Resolve<SelfSelectStockForm>().Show(this.MainDockPanel);
            DIContainerHelper.Resolve<RecommendStockForm>().Show(this.MainDockPanel.Panes[0], null);
        }
        #endregion

        #region 视图菜单

        /// <summary>
        /// 注册停靠窗口到视图菜单
        /// </summary>
        /// <typeparam name="TDockForm">停靠窗口类型</typeparam>
        /// <param name="text"></param>
        /// <param name="image"></param>
        public void RegisterDockFormToViewMenu<TDockForm>(string text, Image image)
            where TDockForm : DockFormBase
        {
            var menuItem = this.ViewMenuItem.DropDownItems.Add(text, image);
            menuItem.Tag = typeof(TDockForm);
            menuItem.Click += this.ViewsMenuItem_Click;
        }

        /// <summary>
        /// 点击显示对应的窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewsMenuItem_Click(object sender, EventArgs e)
        {
            Type viewType = (sender as ToolStripItem)?.Tag as Type;
            if (!(DIContainerHelper.Resolve(viewType) is DockFormBase dockForm))
            {
                throw new NullReferenceException();
            }

            dockForm.Activate();
        }
        #endregion
    }
}
