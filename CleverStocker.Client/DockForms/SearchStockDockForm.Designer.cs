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
            this.MarketComboBox = new System.Windows.Forms.ComboBox();
            this.MarketLabel = new System.Windows.Forms.Label();
            this.CodeLabel = new System.Windows.Forms.Label();
            this.CodeTextBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SearchToolStrip = new System.Windows.Forms.ToolStrip();
            this.AddSelfSelectToolButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveSelfSelectToolButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveToolButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteToolButton = new System.Windows.Forms.ToolStripButton();
            this.MainStockQuotaBaseControl = new CleverStocker.Client.Controls.StockQuotaBaseControl();
            this.MainTablePanel.SuspendLayout();
            this.SearchToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTablePanel
            // 
            this.MainTablePanel.ColumnCount = 2;
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.Controls.Add(this.MarketComboBox, 1, 1);
            this.MainTablePanel.Controls.Add(this.MarketLabel, 0, 1);
            this.MainTablePanel.Controls.Add(this.CodeLabel, 0, 0);
            this.MainTablePanel.Controls.Add(this.CodeTextBox, 1, 0);
            this.MainTablePanel.Controls.Add(this.SearchButton, 0, 2);
            this.MainTablePanel.Controls.Add(this.SearchToolStrip, 0, 3);
            this.MainTablePanel.Controls.Add(this.MainStockQuotaBaseControl, 0, 4);
            this.MainTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTablePanel.Location = new System.Drawing.Point(0, 0);
            this.MainTablePanel.Name = "MainTablePanel";
            this.MainTablePanel.RowCount = 5;
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
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
            // MarketComboBox
            // 
            this.MarketComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MarketComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MarketComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MarketComboBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MarketComboBox.FormattingEnabled = true;
            this.MarketComboBox.Location = new System.Drawing.Point(90, 23);
            this.MarketComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.MarketComboBox.Name = "MarketComboBox";
            this.MarketComboBox.Size = new System.Drawing.Size(198, 25);
            this.MarketComboBox.TabIndex = 6;
            // 
            // MarketLabel
            // 
            this.MarketLabel.AutoEllipsis = true;
            this.MarketLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MarketLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MarketLabel.Location = new System.Drawing.Point(0, 23);
            this.MarketLabel.Margin = new System.Windows.Forms.Padding(0);
            this.MarketLabel.Name = "MarketLabel";
            this.MarketLabel.Size = new System.Drawing.Size(90, 25);
            this.MarketLabel.TabIndex = 2;
            this.MarketLabel.Text = "交易市场";
            this.MarketLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CodeLabel
            // 
            this.CodeLabel.AutoEllipsis = true;
            this.CodeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CodeLabel.Location = new System.Drawing.Point(0, 0);
            this.CodeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CodeLabel.Name = "CodeLabel";
            this.CodeLabel.Size = new System.Drawing.Size(90, 23);
            this.CodeLabel.TabIndex = 0;
            this.CodeLabel.Text = "股票代码";
            this.CodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CodeTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeTextBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CodeTextBox.Location = new System.Drawing.Point(90, 0);
            this.CodeTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(198, 23);
            this.CodeTextBox.TabIndex = 4;
            // 
            // SearchButton
            // 
            this.SearchButton.AutoEllipsis = true;
            this.MainTablePanel.SetColumnSpan(this.SearchButton, 2);
            this.SearchButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SearchButton.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SearchButton.Location = new System.Drawing.Point(1, 49);
            this.SearchButton.Margin = new System.Windows.Forms.Padding(1);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(286, 26);
            this.SearchButton.TabIndex = 5;
            this.SearchButton.Text = "搜索";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
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
            this.SaveToolButton,
            this.DeleteToolButton});
            this.SearchToolStrip.Location = new System.Drawing.Point(0, 76);
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
            // MainStockQuotaBaseControl
            // 
            this.MainTablePanel.SetColumnSpan(this.MainStockQuotaBaseControl, 2);
            this.MainStockQuotaBaseControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainStockQuotaBaseControl.LabelForecolor = System.Drawing.Color.Empty;
            this.MainStockQuotaBaseControl.Location = new System.Drawing.Point(3, 104);
            this.MainStockQuotaBaseControl.Name = "MainStockQuotaBaseControl";
            this.MainStockQuotaBaseControl.Quota = null;
            this.MainStockQuotaBaseControl.Size = new System.Drawing.Size(282, 280);
            this.MainStockQuotaBaseControl.Stock = null;
            this.MainStockQuotaBaseControl.TabIndex = 8;
            this.MainStockQuotaBaseControl.ValueForecolor = System.Drawing.Color.Empty;
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
        private System.Windows.Forms.Label CodeLabel;
        private System.Windows.Forms.Label MarketLabel;
        private System.Windows.Forms.TextBox CodeTextBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.ComboBox MarketComboBox;
        private System.Windows.Forms.ToolStrip SearchToolStrip;
        private System.Windows.Forms.ToolStripButton AddSelfSelectToolButton;
        private System.Windows.Forms.ToolStripButton RemoveSelfSelectToolButton;
        private System.Windows.Forms.ToolStripButton RefreshToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton SaveToolButton;
        private System.Windows.Forms.ToolStripButton DeleteToolButton;
        private Controls.StockQuotaBaseControl MainStockQuotaBaseControl;
    }
}