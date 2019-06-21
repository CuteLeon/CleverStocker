using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CleverStocker.Client
{
    public partial class LaunchForm : Form
    {
        public LaunchForm()
        {
            this.InitializeComponent();

            this.Shown += this.LaunchForm_Shown;
        }

        private async void LaunchForm_Shown(object sender, EventArgs e)
        {
            await Task.Delay(2000);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
