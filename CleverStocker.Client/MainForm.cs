using System;
using System.Linq;
using System.Windows.Forms;
using CleverStocker.Client.Configs;
using CleverStocker.Model;
using CleverStocker.Services;
using DarkUI.Forms;

namespace CleverStocker.Client
{
    /// <summary>
    /// 主窗口
    /// </summary>
    public partial class MainForm : DarkForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.Icon = AppResource.Icon;
            this.Text = Application.ProductName;

            this.InitializeComponent();
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            var stockService = DIContainer.Resolve<IStockerSpiderService>();
            var stocks = stockService.GetStocks();

            // MessageBox.Show(stocks.Count().ToString());
            var service = new StockerService();
            var count = service.Transact<Func<int>, int>(() => service.AsQueryable().Count());
            service.Add(new Stock() { Code = Guid.NewGuid().ToString(), Market = "sz", Name = "深圳123" });
        }
    }
}
