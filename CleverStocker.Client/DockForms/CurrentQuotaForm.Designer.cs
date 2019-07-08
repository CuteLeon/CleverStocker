namespace CleverStocker.Client.DockForms
{
    partial class CurrentQuotaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.CurrentQuotaToolStrip = new System.Windows.Forms.ToolStrip();
            this.AutoRefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ChartToolButton = new System.Windows.Forms.ToolStripButton();
            this.QuotaRepositoryToolButton = new System.Windows.Forms.ToolStripButton();
            this.MainStockQuotaControl = new CleverStocker.Client.Controls.StockQuotaControl();
            this.MainFiveGearControl = new CleverStocker.Client.Controls.StockQuotaFiveGearControl();
            this.CurrentQuotaToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutoRefreshTimer
            // 
            this.AutoRefreshTimer.Interval = 3000;
            this.AutoRefreshTimer.Tick += new System.EventHandler(this.AutoRefreshTimer_Tick);
            // 
            // CurrentQuotaToolStrip
            // 
            this.CurrentQuotaToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AutoRefreshToolButton,
            this.RefreshToolButton,
            this.toolStripSeparator1,
            this.ChartToolButton,
            this.QuotaRepositoryToolButton});
            this.CurrentQuotaToolStrip.Location = new System.Drawing.Point(0, 0);
            this.CurrentQuotaToolStrip.Name = "CurrentQuotaToolStrip";
            this.CurrentQuotaToolStrip.Size = new System.Drawing.Size(349, 25);
            this.CurrentQuotaToolStrip.TabIndex = 1;
            // 
            // AutoRefreshToolButton
            // 
            this.AutoRefreshToolButton.Checked = true;
            this.AutoRefreshToolButton.CheckOnClick = true;
            this.AutoRefreshToolButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoRefreshToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AutoRefreshToolButton.Image = global::CleverStocker.Client.AppResource.Service;
            this.AutoRefreshToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AutoRefreshToolButton.Name = "AutoRefreshToolButton";
            this.AutoRefreshToolButton.Size = new System.Drawing.Size(23, 22);
            this.AutoRefreshToolButton.Text = "自动刷新行情";
            this.AutoRefreshToolButton.CheckedChanged += new System.EventHandler(this.AutoRefreshToolButton_CheckedChanged);
            // 
            // RefreshToolButton
            // 
            this.RefreshToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshToolButton.Image = global::CleverStocker.Client.AppResource.Refresh;
            this.RefreshToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshToolButton.Name = "RefreshToolButton";
            this.RefreshToolButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshToolButton.Text = "立即刷新行情";
            this.RefreshToolButton.Click += new System.EventHandler(this.RefreshToolButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ChartToolButton
            // 
            this.ChartToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ChartToolButton.Image = global::CleverStocker.Client.AppResource.Quota;
            this.ChartToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ChartToolButton.Name = "ChartToolButton";
            this.ChartToolButton.Size = new System.Drawing.Size(23, 22);
            this.ChartToolButton.Text = "图表";
            this.ChartToolButton.Click += new System.EventHandler(this.ChartToolButton_Click);
            // 
            // QuotaRepositoryToolButton
            // 
            this.QuotaRepositoryToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.QuotaRepositoryToolButton.Image = global::CleverStocker.Client.AppResource.Context;
            this.QuotaRepositoryToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuotaRepositoryToolButton.Name = "QuotaRepositoryToolButton";
            this.QuotaRepositoryToolButton.Size = new System.Drawing.Size(23, 22);
            this.QuotaRepositoryToolButton.Text = "行情仓库";
            this.QuotaRepositoryToolButton.Click += new System.EventHandler(this.QuotaRepositoryToolButton_Click);
            // 
            // MainStockQuotaControl
            // 
            this.MainStockQuotaControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainStockQuotaControl.LabelForecolor = System.Drawing.Color.Empty;
            this.MainStockQuotaControl.Location = new System.Drawing.Point(0, 25);
            this.MainStockQuotaControl.Name = "MainStockQuotaControl";
            this.MainStockQuotaControl.Padding = new System.Windows.Forms.Padding(3);
            this.MainStockQuotaControl.Size = new System.Drawing.Size(349, 185);
            this.MainStockQuotaControl.TabIndex = 2;
            this.MainStockQuotaControl.ValueForecolor = System.Drawing.Color.Empty;
            // 
            // MainFiveGearControl
            // 
            this.MainFiveGearControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainFiveGearControl.LabelForecolor = System.Drawing.Color.Empty;
            this.MainFiveGearControl.Location = new System.Drawing.Point(0, 210);
            this.MainFiveGearControl.Name = "MainFiveGearControl";
            this.MainFiveGearControl.Padding = new System.Windows.Forms.Padding(3);
            this.MainFiveGearControl.Size = new System.Drawing.Size(349, 152);
            this.MainFiveGearControl.TabIndex = 3;
            this.MainFiveGearControl.ValueForecolor = System.Drawing.Color.Empty;
            // 
            // CurrentQuotaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 361);
            this.Controls.Add(this.MainFiveGearControl);
            this.Controls.Add(this.MainStockQuotaControl);
            this.Controls.Add(this.CurrentQuotaToolStrip);
            this.Name = "CurrentQuotaForm";
            this.ShowHint = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            this.TabText = "实时行情";
            this.Text = "实时行情";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CurrentQuotaForm_FormClosed);
            this.Load += new System.EventHandler(this.CurrentQuotaForm_Load);
            this.CurrentQuotaToolStrip.ResumeLayout(false);
            this.CurrentQuotaToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer AutoRefreshTimer;
        private System.Windows.Forms.ToolStrip CurrentQuotaToolStrip;
        private System.Windows.Forms.ToolStripButton AutoRefreshToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton RefreshToolButton;
        private System.Windows.Forms.ToolStripButton QuotaRepositoryToolButton;
        private System.Windows.Forms.ToolStripButton ChartToolButton;
        private Controls.StockQuotaControl MainStockQuotaControl;
        private Controls.StockQuotaFiveGearControl MainFiveGearControl;
    }
}