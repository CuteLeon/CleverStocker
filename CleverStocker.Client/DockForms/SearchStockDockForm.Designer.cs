namespace CleverStocker.Client.DockForms
{
    partial class SearchStockDockForm
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
            this.MainTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.StockComboBox = new System.Windows.Forms.ComboBox();
            this.SearchToolStrip = new System.Windows.Forms.ToolStrip();
            this.AddSelfSelectToolButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveSelfSelectToolButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ChartToolButton = new System.Windows.Forms.ToolStripButton();
            this.QuotaRepositoryToolButton = new System.Windows.Forms.ToolStripButton();
            this.RecentToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteToolButton = new System.Windows.Forms.ToolStripButton();
            this.MainStockQuotaControl = new CleverStocker.Client.Controls.StockQuotaControl();
            this.MainTablePanel.SuspendLayout();
            this.SearchToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTablePanel
            // 
            this.MainTablePanel.ColumnCount = 2;
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.Controls.Add(this.StockComboBox, 0, 0);
            this.MainTablePanel.Controls.Add(this.SearchToolStrip, 0, 1);
            this.MainTablePanel.Controls.Add(this.MainStockQuotaControl, 0, 2);
            this.MainTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTablePanel.Location = new System.Drawing.Point(0, 0);
            this.MainTablePanel.Name = "MainTablePanel";
            this.MainTablePanel.RowCount = 3;
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.Size = new System.Drawing.Size(288, 387);
            this.MainTablePanel.TabIndex = 0;
            // 
            // StockComboBox
            // 
            this.MainTablePanel.SetColumnSpan(this.StockComboBox, 2);
            this.StockComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StockComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StockComboBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StockComboBox.Location = new System.Drawing.Point(0, 0);
            this.StockComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.StockComboBox.MaxDropDownItems = 10;
            this.StockComboBox.Name = "StockComboBox";
            this.StockComboBox.Size = new System.Drawing.Size(288, 25);
            this.StockComboBox.TabIndex = 6;
            this.StockComboBox.SelectedValueChanged += new System.EventHandler(this.StockComboBox_SelectedValueChanged);
            this.StockComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StockComboBox_KeyDown);
            // 
            // SearchToolStrip
            // 
            this.MainTablePanel.SetColumnSpan(this.SearchToolStrip, 2);
            this.SearchToolStrip.Enabled = false;
            this.SearchToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSelfSelectToolButton,
            this.RemoveSelfSelectToolButton,
            this.RefreshToolButton,
            this.toolStripSeparator1,
            this.ChartToolButton,
            this.QuotaRepositoryToolButton,
            this.RecentToolStripButton,
            this.toolStripSeparator2,
            this.SaveToolButton,
            this.DeleteToolButton});
            this.SearchToolStrip.Location = new System.Drawing.Point(0, 25);
            this.SearchToolStrip.Name = "SearchToolStrip";
            this.SearchToolStrip.Size = new System.Drawing.Size(288, 25);
            this.SearchToolStrip.TabIndex = 7;
            this.SearchToolStrip.Text = "toolStrip1";
            // 
            // AddSelfSelectToolButton
            // 
            this.AddSelfSelectToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddSelfSelectToolButton.Image = global::CleverStocker.Client.AppResource.Add;
            this.AddSelfSelectToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddSelfSelectToolButton.Name = "AddSelfSelectToolButton";
            this.AddSelfSelectToolButton.Size = new System.Drawing.Size(23, 22);
            this.AddSelfSelectToolButton.Text = "加入自选";
            this.AddSelfSelectToolButton.Click += new System.EventHandler(this.AddSelfSelectToolButton_Click);
            // 
            // RemoveSelfSelectToolButton
            // 
            this.RemoveSelfSelectToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RemoveSelfSelectToolButton.Image = global::CleverStocker.Client.AppResource.Remove;
            this.RemoveSelfSelectToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveSelfSelectToolButton.Name = "RemoveSelfSelectToolButton";
            this.RemoveSelfSelectToolButton.Size = new System.Drawing.Size(23, 22);
            this.RemoveSelfSelectToolButton.Text = "移除自选";
            this.RemoveSelfSelectToolButton.Click += new System.EventHandler(this.RemoveSelfSelectToolButton_Click);
            // 
            // RefreshToolButton
            // 
            this.RefreshToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshToolButton.Image = global::CleverStocker.Client.AppResource.Refresh;
            this.RefreshToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshToolButton.Name = "RefreshToolButton";
            this.RefreshToolButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshToolButton.Text = "刷新";
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
            this.ChartToolButton.Image = global::CleverStocker.Client.AppResource.Chart;
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
            // RecentToolStripButton
            // 
            this.RecentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RecentToolStripButton.Image = global::CleverStocker.Client.AppResource.Clock;
            this.RecentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RecentToolStripButton.Name = "RecentToolStripButton";
            this.RecentToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.RecentToolStripButton.Text = "历史行情";
            this.RecentToolStripButton.Click += new System.EventHandler(this.RecentToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // SaveToolButton
            // 
            this.SaveToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveToolButton.Image = global::CleverStocker.Client.AppResource.Save;
            this.SaveToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolButton.Name = "SaveToolButton";
            this.SaveToolButton.Size = new System.Drawing.Size(23, 22);
            this.SaveToolButton.Text = "保存";
            this.SaveToolButton.Click += new System.EventHandler(this.SaveToolButton_Click);
            // 
            // DeleteToolButton
            // 
            this.DeleteToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteToolButton.Image = global::CleverStocker.Client.AppResource.Delete;
            this.DeleteToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteToolButton.Name = "DeleteToolButton";
            this.DeleteToolButton.Size = new System.Drawing.Size(23, 22);
            this.DeleteToolButton.Text = "删除";
            this.DeleteToolButton.Click += new System.EventHandler(this.DeleteToolButton_Click);
            // 
            // MainStockQuotaControl
            // 
            this.MainStockQuotaControl.AttachEntity = null;
            this.MainTablePanel.SetColumnSpan(this.MainStockQuotaControl, 2);
            this.MainStockQuotaControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainStockQuotaControl.LabelForecolor = System.Drawing.Color.Empty;
            this.MainStockQuotaControl.Location = new System.Drawing.Point(3, 53);
            this.MainStockQuotaControl.Name = "MainStockQuotaControl";
            this.MainStockQuotaControl.Padding = new System.Windows.Forms.Padding(3);
            this.MainStockQuotaControl.Size = new System.Drawing.Size(282, 331);
            this.MainStockQuotaControl.Stock = null;
            this.MainStockQuotaControl.TabIndex = 8;
            this.MainStockQuotaControl.ValueForecolor = System.Drawing.Color.Empty;
            // 
            // SearchStockDockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 387);
            this.Controls.Add(this.MainTablePanel);
            this.Name = "SearchStockDockForm";
            this.TabText = "搜索股票";
            this.Text = "搜索股票";
            this.Load += new System.EventHandler(this.SearchStockDockForm_Load);
            this.MainTablePanel.ResumeLayout(false);
            this.MainTablePanel.PerformLayout();
            this.SearchToolStrip.ResumeLayout(false);
            this.SearchToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTablePanel;
        private System.Windows.Forms.ComboBox StockComboBox;
        private System.Windows.Forms.ToolStrip SearchToolStrip;
        private System.Windows.Forms.ToolStripButton AddSelfSelectToolButton;
        private System.Windows.Forms.ToolStripButton RemoveSelfSelectToolButton;
        private System.Windows.Forms.ToolStripButton RefreshToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton SaveToolButton;
        private System.Windows.Forms.ToolStripButton DeleteToolButton;
        private Controls.StockQuotaControl MainStockQuotaControl;
        private System.Windows.Forms.ToolStripButton ChartToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton QuotaRepositoryToolButton;
        private System.Windows.Forms.ToolStripButton RecentToolStripButton;
    }
}