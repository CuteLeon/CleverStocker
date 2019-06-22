using System;
using System.Linq;
using System.Windows.Forms;
using CleverStocker.Client.Configs;
using CleverStocker.Services;

namespace CleverStocker.Client
{
    /// <summary>
    /// 主窗口
    /// </summary>
    public partial class MainForm : Form
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
            var stockService = DIContainer.Resolve<IStockerService>();
            var stocks = stockService.GetStocks();
            MessageBox.Show(stocks.Count().ToString());
        }
    }
}
