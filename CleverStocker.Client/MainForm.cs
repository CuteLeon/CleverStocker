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
using CleverStocker.Model.Extensions;
using CleverStocker.Services;
using CleverStocker.Utils;
using WeifenLuo.WinFormsUI.Docking;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Client
{
    /// <summary>
    /// 主窗口
    /// </summary>
    public partial class MainForm : Form, IInitializable, IThemeAppliable
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
            this.ApplyTheme();
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
            MQHelper.Publish("MainForm", MQTopics.TopicStockSelfSelectAdd, new Stock("000004", Markets.ShangHai, "测试股票-4").GetFullCode());
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

        private void ThemeMenuItem_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripMenuItem menuItem) ||
                menuItem.Checked)
            {
                return;
            }

            Themes theme = (Themes)menuItem.Tag;
            ThemeHelper.SaveNextTheme(theme);

            MessageBox.Show($"下次启动将使用 {theme.ToString()} 主题。", "更换主题", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 应用主题
        /// </summary>
        public void ApplyTheme()
        {
            this.LightThemeMenuItem.Tag = Themes.Light;
            this.BlueThemeMenuItem.Tag = Themes.Blue;
            this.DarkThemeMenuItem.Tag = Themes.Dark;

            switch (ThemeHelper.CurrentTheme)
            {
                case Themes.Light:
                    {
                        this.LightThemeMenuItem.Checked = true;
                        break;
                    }

                case Themes.Blue:
                    {
                        this.BlueThemeMenuItem.Checked = true;
                        break;
                    }

                case Themes.Dark:
                    {
                        this.DarkThemeMenuItem.Checked = true;
                        break;
                    }
            }

            // 应用主题
            this.MainDockPanel.Theme = ThemeHelper.CurrentThemeComponent;

            // 应用浮动窗口工厂
            this.MainDockPanel.Theme.Extender.FloatWindowFactory = FloatedWindowFactory.SingleInstance;

            // 应用工具条主题
            this.MainDockPanel.Theme.ApplyTo(this.MainTopMenuStrip);
            this.MainDockPanel.Theme.ApplyTo(this.MainToolStrip);
            this.MainDockPanel.Theme.ApplyTo(this.MainStatusStrip);
        }
        #endregion

        #region 显示

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (File.Exists(ConfigHelper.GetLayoutFileName()))
            {
                try
                {
                    this.LoadLayout();
                }
                catch (Exception ex)
                {
                    LogHelper<MainForm>.ErrorException(ex, "从文件恢复布局失败：");

                    this.PredeterminedLayout();
                }
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

            MessageBox.Show($"保存布局成功，下次启动将应用此布局！", "保存布局", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 从文件加载布局
        /// </summary>
        private void LoadLayout()
        {
            this.MainDockPanel.LoadFromXml(ConfigHelper.GetLayoutFileName(), this.GetDockContent);
        }

        /// <summary>
        /// 保存布局到文件
        /// </summary>
        private void SaveLayoute()
        {
            this.MainDockPanel.SaveAsXml(ConfigHelper.GetLayoutFileName());
        }

        /// <summary>
        /// 使用持久化ID创建实例
        /// </summary>
        /// <param name="persist"></param>
        /// <returns></returns>
        private IDockContent GetDockContent(string persist)
        {
            try
            {
                Type type = this.GetType().Assembly.GetType(persist);
                var dockForm = DIContainerHelper.Resolve(type) as IDockContent;
                return dockForm;
            }
            catch (Exception ex)
            {
                LogHelper<MainForm>.ErrorException(ex, $"从持久化ID {persist} 恢复界面实例失败：");
                return default;
            }
        }
        #endregion
    }
}
