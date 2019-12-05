namespace CleverStocker.Client.DockForms
{
    partial class RecentQuotaDocumentForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RecentQuotaGridView = new System.Windows.Forms.DataGridView();
            this.codeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.marketDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openningPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.closingPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highestPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowestPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.updateTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecentQuotaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RecentQuotaToolStrip = new System.Windows.Forms.ToolStrip();
            this.StockInfoToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TimeScaleToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.TimeScaleToolComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.QuotaLengthToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.QueryToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ExportToolButton = new System.Windows.Forms.ToolStripButton();
            this.QuotaLengthNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.RecentQuotaGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecentQuotaBindingSource)).BeginInit();
            this.RecentQuotaToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuotaLengthNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // RecentQuotaGridView
            // 
            this.RecentQuotaGridView.AllowUserToAddRows = false;
            this.RecentQuotaGridView.AllowUserToDeleteRows = false;
            this.RecentQuotaGridView.AllowUserToOrderColumns = true;
            this.RecentQuotaGridView.AllowUserToResizeRows = false;
            this.RecentQuotaGridView.AutoGenerateColumns = false;
            this.RecentQuotaGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.RecentQuotaGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RecentQuotaGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.RecentQuotaGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.RecentQuotaGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RecentQuotaGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codeDataGridViewTextBoxColumn,
            this.marketDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.openningPriceDataGridViewTextBoxColumn,
            this.closingPriceDataGridViewTextBoxColumn,
            this.highestPriceDataGridViewTextBoxColumn,
            this.lowestPriceDataGridViewTextBoxColumn,
            this.volumeDataGridViewTextBoxColumn,
            this.updateTimeDataGridViewTextBoxColumn});
            this.RecentQuotaGridView.DataSource = this.RecentQuotaBindingSource;
            this.RecentQuotaGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RecentQuotaGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.RecentQuotaGridView.Location = new System.Drawing.Point(0, 25);
            this.RecentQuotaGridView.Name = "RecentQuotaGridView";
            this.RecentQuotaGridView.ReadOnly = true;
            this.RecentQuotaGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.RecentQuotaGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.RecentQuotaGridView.RowTemplate.Height = 23;
            this.RecentQuotaGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RecentQuotaGridView.Size = new System.Drawing.Size(522, 324);
            this.RecentQuotaGridView.TabIndex = 3;
            // 
            // codeDataGridViewTextBoxColumn
            // 
            this.codeDataGridViewTextBoxColumn.DataPropertyName = "Code";
            this.codeDataGridViewTextBoxColumn.Frozen = true;
            this.codeDataGridViewTextBoxColumn.HeaderText = "代码";
            this.codeDataGridViewTextBoxColumn.Name = "codeDataGridViewTextBoxColumn";
            this.codeDataGridViewTextBoxColumn.ReadOnly = true;
            this.codeDataGridViewTextBoxColumn.Width = 51;
            // 
            // marketDataGridViewTextBoxColumn
            // 
            this.marketDataGridViewTextBoxColumn.DataPropertyName = "Market";
            this.marketDataGridViewTextBoxColumn.Frozen = true;
            this.marketDataGridViewTextBoxColumn.HeaderText = "市场";
            this.marketDataGridViewTextBoxColumn.Name = "marketDataGridViewTextBoxColumn";
            this.marketDataGridViewTextBoxColumn.ReadOnly = true;
            this.marketDataGridViewTextBoxColumn.Width = 51;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.Frozen = true;
            this.nameDataGridViewTextBoxColumn.HeaderText = "名称";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 51;
            // 
            // openningPriceDataGridViewTextBoxColumn
            // 
            this.openningPriceDataGridViewTextBoxColumn.DataPropertyName = "OpenningPrice";
            this.openningPriceDataGridViewTextBoxColumn.HeaderText = "今日开盘价(元)";
            this.openningPriceDataGridViewTextBoxColumn.Name = "openningPriceDataGridViewTextBoxColumn";
            this.openningPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.openningPriceDataGridViewTextBoxColumn.Width = 88;
            // 
            // closingPriceDataGridViewTextBoxColumn
            // 
            this.closingPriceDataGridViewTextBoxColumn.DataPropertyName = "ClosingPrice";
            this.closingPriceDataGridViewTextBoxColumn.HeaderText = "今日收盘价(元)";
            this.closingPriceDataGridViewTextBoxColumn.Name = "closingPriceDataGridViewTextBoxColumn";
            this.closingPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.closingPriceDataGridViewTextBoxColumn.Width = 88;
            // 
            // highestPriceDataGridViewTextBoxColumn
            // 
            this.highestPriceDataGridViewTextBoxColumn.DataPropertyName = "HighestPrice";
            this.highestPriceDataGridViewTextBoxColumn.HeaderText = "今日最高价(元)";
            this.highestPriceDataGridViewTextBoxColumn.Name = "highestPriceDataGridViewTextBoxColumn";
            this.highestPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.highestPriceDataGridViewTextBoxColumn.Width = 88;
            // 
            // lowestPriceDataGridViewTextBoxColumn
            // 
            this.lowestPriceDataGridViewTextBoxColumn.DataPropertyName = "LowestPrice";
            this.lowestPriceDataGridViewTextBoxColumn.HeaderText = "今日最低价(元)";
            this.lowestPriceDataGridViewTextBoxColumn.Name = "lowestPriceDataGridViewTextBoxColumn";
            this.lowestPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.lowestPriceDataGridViewTextBoxColumn.Width = 88;
            // 
            // volumeDataGridViewTextBoxColumn
            // 
            this.volumeDataGridViewTextBoxColumn.DataPropertyName = "Volume";
            this.volumeDataGridViewTextBoxColumn.HeaderText = "交易量";
            this.volumeDataGridViewTextBoxColumn.Name = "volumeDataGridViewTextBoxColumn";
            this.volumeDataGridViewTextBoxColumn.ReadOnly = true;
            this.volumeDataGridViewTextBoxColumn.Width = 61;
            // 
            // updateTimeDataGridViewTextBoxColumn
            // 
            this.updateTimeDataGridViewTextBoxColumn.DataPropertyName = "UpdateTime";
            dataGridViewCellStyle1.Format = "yyyy-MM-dd HH:mm:ss";
            this.updateTimeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.updateTimeDataGridViewTextBoxColumn.HeaderText = "更新时间";
            this.updateTimeDataGridViewTextBoxColumn.Name = "updateTimeDataGridViewTextBoxColumn";
            this.updateTimeDataGridViewTextBoxColumn.ReadOnly = true;
            this.updateTimeDataGridViewTextBoxColumn.Width = 61;
            // 
            // RecentQuotaBindingSource
            // 
            this.RecentQuotaBindingSource.DataSource = typeof(CleverStocker.Model.RecentQuota);
            // 
            // RecentQuotaToolStrip
            // 
            this.RecentQuotaToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StockInfoToolLabel,
            this.toolStripSeparator1,
            this.TimeScaleToolLabel,
            this.TimeScaleToolComboBox,
            this.QuotaLengthToolLabel,
            this.toolStripSeparator2,
            this.QueryToolButton,
            this.toolStripSeparator3,
            this.ExportToolButton});
            this.RecentQuotaToolStrip.Location = new System.Drawing.Point(0, 0);
            this.RecentQuotaToolStrip.Name = "RecentQuotaToolStrip";
            this.RecentQuotaToolStrip.Size = new System.Drawing.Size(522, 25);
            this.RecentQuotaToolStrip.TabIndex = 2;
            // 
            // StockInfoToolLabel
            // 
            this.StockInfoToolLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StockInfoToolLabel.Name = "StockInfoToolLabel";
            this.StockInfoToolLabel.Size = new System.Drawing.Size(0, 22);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TimeScaleToolLabel
            // 
            this.TimeScaleToolLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TimeScaleToolLabel.Name = "TimeScaleToolLabel";
            this.TimeScaleToolLabel.Size = new System.Drawing.Size(56, 22);
            this.TimeScaleToolLabel.Text = "时间跨度";
            // 
            // TimeScaleToolComboBox
            // 
            this.TimeScaleToolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeScaleToolComboBox.Name = "TimeScaleToolComboBox";
            this.TimeScaleToolComboBox.Size = new System.Drawing.Size(121, 25);
            // 
            // QuotaLengthToolLabel
            // 
            this.QuotaLengthToolLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.QuotaLengthToolLabel.Name = "QuotaLengthToolLabel";
            this.QuotaLengthToolLabel.Size = new System.Drawing.Size(56, 22);
            this.QuotaLengthToolLabel.Text = "行情数量";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // QueryToolButton
            // 
            this.QueryToolButton.Image = global::CleverStocker.Client.AppResource.Search;
            this.QueryToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QueryToolButton.Name = "QueryToolButton";
            this.QueryToolButton.Size = new System.Drawing.Size(52, 22);
            this.QueryToolButton.Text = "查询";
            this.QueryToolButton.Click += new System.EventHandler(this.QueryToolButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ExportToolButton
            // 
            this.ExportToolButton.Image = global::CleverStocker.Client.AppResource.Exchange;
            this.ExportToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExportToolButton.Name = "ExportToolButton";
            this.ExportToolButton.Size = new System.Drawing.Size(52, 22);
            this.ExportToolButton.Text = "导出";
            this.ExportToolButton.Click += new System.EventHandler(this.ExportToolButton_Click);
            // 
            // QuotaLengthNumeric
            // 
            this.QuotaLengthNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.QuotaLengthNumeric.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.QuotaLengthNumeric.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.QuotaLengthNumeric.Location = new System.Drawing.Point(224, 149);
            this.QuotaLengthNumeric.Maximum = new decimal(new int[] {
            2400,
            0,
            0,
            0});
            this.QuotaLengthNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QuotaLengthNumeric.Name = "QuotaLengthNumeric";
            this.QuotaLengthNumeric.Size = new System.Drawing.Size(120, 22);
            this.QuotaLengthNumeric.TabIndex = 4;
            this.QuotaLengthNumeric.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // RecentQuotaDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 349);
            this.Controls.Add(this.QuotaLengthNumeric);
            this.Controls.Add(this.RecentQuotaGridView);
            this.Controls.Add(this.RecentQuotaToolStrip);
            this.Name = "RecentQuotaDocumentForm";
            this.TabText = "RecentQuotaDocumentForm";
            this.Text = "RecentQuotaDocumentForm";
            this.Load += new System.EventHandler(this.RecentQuotaDocumentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RecentQuotaGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RecentQuotaBindingSource)).EndInit();
            this.RecentQuotaToolStrip.ResumeLayout(false);
            this.RecentQuotaToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuotaLengthNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView RecentQuotaGridView;
        private System.Windows.Forms.ToolStrip RecentQuotaToolStrip;
        private System.Windows.Forms.ToolStripLabel StockInfoToolLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton QueryToolButton;
        private System.Windows.Forms.ToolStripLabel TimeScaleToolLabel;
        private System.Windows.Forms.ToolStripComboBox TimeScaleToolComboBox;
        private System.Windows.Forms.ToolStripLabel QuotaLengthToolLabel;
        private System.Windows.Forms.NumericUpDown QuotaLengthNumeric;
        private System.Windows.Forms.DataGridViewTextBoxColumn codeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn marketDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn openningPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn closingPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn highestPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowestPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn updateTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource RecentQuotaBindingSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton ExportToolButton;
    }
}