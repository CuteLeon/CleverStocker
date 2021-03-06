﻿namespace CleverStocker.Client.DockForms
{
    partial class MarketQuotaForm
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
            this.MarketQuotaToolStrip = new System.Windows.Forms.ToolStrip();
            this.AutoRefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MainMarketQuotaControl = new CleverStocker.Client.Controls.MarketQuotaControl();
            this.AutoRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.MarketQuotaToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MarketQuotaToolStrip
            // 
            this.MarketQuotaToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AutoRefreshToolButton,
            this.RefreshToolButton,
            this.toolStripSeparator1});
            this.MarketQuotaToolStrip.Location = new System.Drawing.Point(0, 0);
            this.MarketQuotaToolStrip.Name = "MarketQuotaToolStrip";
            this.MarketQuotaToolStrip.Size = new System.Drawing.Size(330, 25);
            this.MarketQuotaToolStrip.TabIndex = 2;
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
            // MainMarketQuotaControl
            // 
            this.MainMarketQuotaControl.AttachEntity = null;
            this.MainMarketQuotaControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainMarketQuotaControl.LabelForecolor = System.Drawing.Color.Empty;
            this.MainMarketQuotaControl.Location = new System.Drawing.Point(0, 25);
            this.MainMarketQuotaControl.Name = "MainMarketQuotaControl";
            this.MainMarketQuotaControl.Padding = new System.Windows.Forms.Padding(3);
            this.MainMarketQuotaControl.Size = new System.Drawing.Size(330, 197);
            this.MainMarketQuotaControl.Stock = null;
            this.MainMarketQuotaControl.TabIndex = 3;
            this.MainMarketQuotaControl.ValueForecolor = System.Drawing.Color.Empty;
            // 
            // AutoRefreshTimer
            // 
            this.AutoRefreshTimer.Interval = 5000;
            this.AutoRefreshTimer.Tick += new System.EventHandler(this.AutoRefreshTimer_Tick);
            // 
            // MarketQuotaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 222);
            this.Controls.Add(this.MainMarketQuotaControl);
            this.Controls.Add(this.MarketQuotaToolStrip);
            this.Name = "MarketQuotaForm";
            this.TabText = "大盘指数";
            this.Text = "大盘指数";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MarketQuotaForm_FormClosed);
            this.Load += new System.EventHandler(this.MarketQuotaForm_Load);
            this.MarketQuotaToolStrip.ResumeLayout(false);
            this.MarketQuotaToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MarketQuotaToolStrip;
        private System.Windows.Forms.ToolStripButton AutoRefreshToolButton;
        private System.Windows.Forms.ToolStripButton RefreshToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private Controls.MarketQuotaControl MainMarketQuotaControl;
        private System.Windows.Forms.Timer AutoRefreshTimer;
    }
}