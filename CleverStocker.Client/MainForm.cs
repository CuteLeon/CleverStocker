using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CleverStocker.Client.DockForms;
using CleverStocker.Client.DockForms.FloatWindows;
using CleverStocker.Client.Interfaces;
using CleverStocker.Services;
using CleverStocker.Utils;
using WeifenLuo.WinFormsUI.Docking;
using static CleverStocker.Common.CommonStandard;

namespace CleverStocker.Client
{
    /* TODO: 功能布局
     * 将股票行情固定为小浮窗（订阅[某]股票行情刷新消息，取行情以绘制）
     * 实时行情窗口，价格标签显示上升(红)下降(绿)图标
     * 公司信息
     * 最近交易(列表x4)
     * 资金流向
     * 智能分析：ML.NET=> 1.长线分析(网易财经爬虫/本地CSV文件导入)；2.短线分析(数据库行情)
     */

    /// <summary>
    /// 主窗口
    /// </summary>
    public partial class MainForm : Form, IInitializable, IThemeAppliable
    {
        #region 初始化

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();

            this.Icon = AppResource.Icon;
            this.Text = Application.ProductName;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 这部分需要在构造时机执行
            this.IsMdiContainer = true;
            this.MainDockPanel.DocumentStyle = DocumentStyle.DockingMdi;
            this.MainDockPanel.DocumentTabStripLocation = DocumentTabStripLocation.Top;
            this.MainDockPanel.Theme.Extender.FloatWindowFactory = FloatedWindowFactory.SingleInstance;
            this.MainDockPanel.ShowDocumentIcon = true;

            // 这部分需要在构造时机执行
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
        #endregion

        #region 测试

        private void TestToolItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.GetSearchStocks();
                /*
                this.GetChart();
                this.GetCompany();
                this.GetRecentQuotas();
                this.GetRecentTrades();
                 */
            }
            catch (Exception ex)
            {
                MessageBox.Show($"获取股票数据失败：\n{ex.Message}");
            }
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

        private void GetSearchStocks()
        {
            var stockSpiderService = DIContainerHelper.Resolve<IStockSpiderService>();
            var stocks = stockSpiderService.GetSearchStocks("中信");

            MessageBox.Show($"获取公司信息成功：\n总数：{stocks.Count}\n{string.Join("\n", stocks.Select(s => s.Name))}");
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

            DIContainerHelper.Resolve<ICompanyService>().AddOrUpdate(company);

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

            MessageBox.Show($"获取最近行情成功：\n行情数量：{quotas.Count}\n最新时间：{quotas.LastOrDefault()?.UpdateTime}\n最早时间：{quotas.FirstOrDefault()?.UpdateTime}");
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

            MessageBox.Show($"获取最近交易成功：\n交易数量：{trades.Count}\n最新时间：{trades.LastOrDefault()?.UpdateTime}\n最早时间：{trades.FirstOrDefault()?.UpdateTime}");
        }
        #endregion

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
            Application.DoEvents();

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
            var currentQuotaForm = DIContainerHelper.Resolve<CurrentQuotaForm>();
            currentQuotaForm.Show(recentTradeForm.Pane, recentTradeForm);

            var marketQuotaForm = DIContainerHelper.Resolve<MarketQuotaForm>();
            marketQuotaForm.Show(recentTradeForm.Pane, DockAlignment.Bottom, 0.3);

            var searchStockForm = DIContainerHelper.Resolve<SearchStockDockForm>();
            searchStockForm.Show(this.MainDockPanel);
            var hotStockForm = DIContainerHelper.Resolve<HotStockDockForm>();
            hotStockForm.Show(searchStockForm.Pane, DockAlignment.Top, 0.56);
            var selfSelectForm = DIContainerHelper.Resolve<SelfSelectStockForm>();
            selfSelectForm.Show(hotStockForm.Pane, hotStockForm);
        }
        #endregion

        #region 搜索股票

        private void SearchToolButton_Click(object sender, EventArgs e)
        {
            SearchStockDockForm dockForm = DIContainerHelper.Resolve<SearchStockDockForm>();
            if (dockForm == null)
            {
                return;
            }

            dockForm.Show(this.MainDockPanel);
        }
        #endregion

        #region 开始菜单

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "确认要退出系统吗？",
                "确认要退出",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question)
                != DialogResult.OK)
            {
                return;
            }

            Application.Exit();
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
        private DockFormBase GetDockContent(string persist)
        {
            try
            {
                string[] persists = persist.Split(new[] { '@' }, 2);
                Type type = this.GetType().Assembly.GetType(persists[0]);
                if (!(DIContainerHelper.Resolve(type) is DockFormBase dockForm))
                {
                    return default;
                }

                if (persists.Length > 1)
                {
                    dockForm.PersistValue = persists[1];
                }

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
