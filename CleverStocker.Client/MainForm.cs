using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
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
            for (int index = 0; index < 3; index++)
            {
                System.Threading.Thread.Sleep(1000);
                yield return index.ToString();
            }

            // throw new InvalidOperationException("凉凉");

            yield break;
        }

        private void TestToolItem_Click(object sender, EventArgs e)
        {
            var stockService = DIContainerHelper.Resolve<IStockerSpiderService>();
            var stocks = stockService.GetStocks();

            var service = new StockerService();
            service.Add(new Stock() { Code = Guid.NewGuid().ToString(), Market = "sz", Name = "深圳123" });
            var count = service.Transact<Func<int>, int>(() => service.AsQueryable().Count());
            var test = service.AsQueryable().Where(s => s.Market == "sz").ToArray();
            MessageBox.Show($"{stockService.GetType().FullName} => {stocks.Count()}\n{service.GetType().FullName} => {count}");
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

    }
}
