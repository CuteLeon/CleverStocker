using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CleverStocker.Client.DockForms;
using CleverStocker.Client.DockForms.FloatWindows;
using CleverStocker.Client.Interfaces;
using CleverStocker.Common;
using CleverStocker.Model;
using CleverStocker.Services;
using CleverStocker.Utils;
using WeifenLuo.WinFormsUI.Docking;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Client
{
    /* <功能布局：>
     * 自选股票
     * 推荐股票
     *
     * 文档 (线图x4)
     *
     * 实时行情 (3s)
     * 大盘指数
     * 公司信息
     * 最近交易(列表x4)
     * 最近行情(时间规模x5)
     */

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
            this.MainDockPanel.Theme.Extender.FloatWindowFactory = FloatedWindowFactory.SingleInstance;
            this.MainDockPanel.ShowDocumentIcon = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.ClassicsThemeMenuItem.Checked = true;

            this.SwitchTheme(ThemeHelper.CurrentTheme);
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
            MQHelper.Publish("MainForm", MQTopics.TopicStockSelfSelectAdd, "添加自选股票");
            return;

            try
            {
                this.GetStockQuota();
                this.GetChart();
                this.GetRecentTrades();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"获取股票数据失败：\n{ex.Message}");
            }
        }

        private void GetStockQuota()
        {
            var stockSpiderService = DIContainerHelper.Resolve<IStockSpiderService>();
            var (stock, quota) = stockSpiderService.GetStockQuota("600086", Markets.ShangHai);

            if (quota == null)
            {
                MessageBox.Show($"获取股票行情为空！");
                return;
            }

            using (var stockService = DIContainerHelper.Resolve<IStockService>())
            {
                stockService.AddOrUpdate(stock);
                stock = stockService.Find(stock.Code, stock.Market);

                quota.Stock = stock;
                stock.Quotas.Add(quota);

                stockService.SaveChanges();
            }

            MessageBox.Show($"获取股票行情成功：\n股票简称：{stock.Name}\n行情ID：{quota.ID}");
        }

        private void GetStockMarketQuota()
        {
            /* <大盘指数>
             * 上证指数：
             * var (stock, marketQuote) = stockSpiderService.GetStockMarketQuota("000001", Markets.ShangHai);
             * 深证成指：
             * var (stock, marketQuote) = stockSpiderService.GetStockMarketQuota("399001", Markets.ShenZhen);
             * 创业板指：
             * var (stock, marketQuote) = stockSpiderService.GetStockMarketQuota("399006", Markets.ShenZhen);
             */
            var stockSpiderService = DIContainerHelper.Resolve<IStockSpiderService>();
            var (stock, marketQuote) = stockSpiderService.GetStockMarketQuota("600086", Markets.ShangHai);

            if (marketQuote == null)
            {
                MessageBox.Show($"获取股票大盘指数为空！");
                return;
            }

            using (var stockService = DIContainerHelper.Resolve<IStockService>())
            {
                stockService.AddOrUpdate(stock);
                stock = stockService.Find(stock.Code, stock.Market);

                marketQuote.Stock = stock;
                stock.MarketQuotas.Add(marketQuote);

                stockService.SaveChanges();
            }

            MessageBox.Show($"获取股票大盘指数成功：\n股票简称：{stock.Name}\n大盘指数ID：{marketQuote.ID}");
        }

        private void GetChart()
        {
            var stockSpiderService = DIContainerHelper.Resolve<IStockSpiderService>();
            var image = stockSpiderService.GetChart("600086", Markets.ShangHai, Charts.Minute);
            if (image == null)
            {
                MessageBox.Show($"获取股票图表为空！");
                return;
            }

            DockFormBase form = new DocumentDockForm()
            {
                Size = image.Size,
                BackgroundImage = image,
                BackgroundImageLayout = ImageLayout.Center,
            };
            form.Show(this.MainDockPanel);
        }

        private void GetCompany()
        {
            var stockSpiderService = DIContainerHelper.Resolve<IStockSpiderService>();
            var company = stockSpiderService.GetCompany("600086", Markets.ShangHai);

            if (company == null)
            {
                MessageBox.Show($"获取公司信息为空！");
                return;
            }

            using (var stockService = DIContainerHelper.Resolve<IStockService>())
            {
                var stock = stockService.Find("600086", Markets.ShangHai);

                if (stock.Company == null)
                {
                    stock.Company = new Company();
                }

                company.CopyTo(stock.Company);
                stockService.SaveChanges();
            }

            MessageBox.Show($"获取公司信息成功：\n公司名称：{company.Position} - {company.Name}");
        }

        private void GetRecentQuotas()
        {
            var stockSpiderService = DIContainerHelper.Resolve<IStockSpiderService>();
            var quotas = stockSpiderService.GetRecentQuotas("600086", Markets.ShangHai, TimeScales.Minutes_5, 48);

            if (quotas == null ||
                quotas.Count == 0)
            {
                MessageBox.Show($"获取最近行情为空！");
                return;
            }

            MessageBox.Show($"获取最近行情成功：\n行情数量：{quotas.Count}\n最新时间：{quotas.LastOrDefault()?.DateTime}\n最早时间：{quotas.FirstOrDefault()?.DateTime}");
        }

        private void GetRecentTrades()
        {
            var stockSpiderService = DIContainerHelper.Resolve<IStockSpiderService>();
            var trades = stockSpiderService.GetRecentTrades("600086", Markets.ShangHai, TradeListTypes.Block, 10);

            if (trades == null ||
                trades.Count == 0)
            {
                MessageBox.Show($"获取最近交易为空！");
                return;
            }

            MessageBox.Show($"获取最近交易成功：\n交易数量：{trades.Count}\n最新时间：{trades.LastOrDefault()?.DateTime}\n最早时间：{trades.FirstOrDefault()?.DateTime}");
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
            /* 框架限制：切换主题需要关闭所有的 Pane (窗格)
             * 可以尝试：立即保存当前布局到文件，然后关闭所有 Pane ，切换主题后，再从文件读入以恢复布局
             */
            ThemeHelper.CurrentTheme = theme;

            if (this.MainDockPanel.Panes.Count > 0)
            {
                MessageBox.Show("下次启动后将应用新主题。");
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

            // 应用浮动窗口工厂
            this.MainDockPanel.Theme.Extender.FloatWindowFactory = FloatedWindowFactory.SingleInstance;

            ThemeHelper.CurrentThemeComponent = this.MainDockPanel.Theme;

            // 应用工具条主题
            this.MainDockPanel.Theme.ApplyTo(this.MainTopMenuStrip);
            this.MainDockPanel.Theme.ApplyTo(this.MainToolStrip);
            this.MainDockPanel.Theme.ApplyTo(this.MainStatusStrip);
        }
        #endregion

        #region 显示

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (File.Exists("CleverStocker.Layout.xml"))
            {
                this.LoadLayout();
            }
            else
            {
                this.PredeterminedLayout();
            }
        }

        /// <summary>
        /// 预设布局
        /// </summary>
        private void PredeterminedLayout()
        {
            var recentTradeForm = DIContainerHelper.Resolve<RecentTradeForm>();
            recentTradeForm.Show(this.MainDockPanel);
            var recentQuotaForm = DIContainerHelper.Resolve<RecentQuotaForm>();
            recentQuotaForm.Show(recentTradeForm.Pane, recentTradeForm);

            var marketQuotaForm = DIContainerHelper.Resolve<MarketQuotaForm>();
            marketQuotaForm.Show(recentTradeForm.Pane, DockAlignment.Top, 0.5);
            var currentQuotaForm = DIContainerHelper.Resolve<CurrentQuotaForm>();
            currentQuotaForm.Show(marketQuotaForm.Pane, marketQuotaForm);

            var recommendStockForm = DIContainerHelper.Resolve<RecommendStockForm>();
            recommendStockForm.Show(this.MainDockPanel);
            var selfSelectStockForm = DIContainerHelper.Resolve<SelfSelectStockForm>();
            selfSelectStockForm.Show(recommendStockForm.Pane, DockAlignment.Top, 0.5);
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

            if (dockForm.IsHidden ||
                !dockForm.Visible)
            {
                dockForm.Show(this.MainDockPanel);
            }
            else
            {
                dockForm.Activate();
            }
        }

        private void SaveLayoutMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveLayoute();
        }

        private void SaveLayoute()
        {
            this.MainDockPanel.SaveAsXml("CleverStocker.Layout.xml");
        }

        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            this.LoadLayout();
        }

        private void LoadLayout()
        {
            this.MainDockPanel.LoadFromXml("CleverStocker.Layout.xml", this.GetDockContent);
        }

        private IDockContent GetDockContent(string persist)
        {
            return default;
        }
        #endregion
    }
}
