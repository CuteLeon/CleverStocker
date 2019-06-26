using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CleverStocker.Client.Interfaces;
using CleverStocker.Model;
using CleverStocker.Services;
using CleverStocker.Utils;

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
            this.Icon = AppResource.Icon;
            this.Text = Application.ProductName;

            this.InitializeComponent();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Initialize()
        {
            for (int index = 0; index < 3; index++)
            {
                Thread.Sleep(1000);
                yield return index.ToString();
            }

            // throw new InvalidOperationException("凉凉");

            yield break;
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            var stockService = DIContainerHelper.Resolve<IStockerSpiderService>();
            var stocks = stockService.GetStocks();

            var service = new StockerService();
            service.Add(new Stock() { Code = Guid.NewGuid().ToString(), Market = "sz", Name = "深圳123" });
            var count = service.Transact<Func<int>, int>(() => service.AsQueryable().Count());

            MessageBox.Show($"{stockService.GetType().FullName} => {stocks.Count()}\n{service.GetType().FullName} => {count}");
        }
    }
}
