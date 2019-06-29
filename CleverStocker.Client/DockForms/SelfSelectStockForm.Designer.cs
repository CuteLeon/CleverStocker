namespace CleverStocker.Client.DockForms
{
    partial class SelfSelectStockForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SelfSelectStockGridView = new System.Windows.Forms.DataGridView();
            this.StockCodeGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockMarketGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockNameGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SelfSelectStockGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // SelfSelectStockGridView
            // 
            this.SelfSelectStockGridView.AllowUserToAddRows = false;
            this.SelfSelectStockGridView.AllowUserToDeleteRows = false;
            this.SelfSelectStockGridView.AllowUserToOrderColumns = true;
            this.SelfSelectStockGridView.AutoGenerateColumns = false;
            this.SelfSelectStockGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SelfSelectStockGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.SelfSelectStockGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelfSelectStockGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SelfSelectStockGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SelfSelectStockGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SelfSelectStockGridView.ColumnHeadersVisible = false;
            this.SelfSelectStockGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockCodeGridViewColumn,
            this.StockMarketGridViewColumn,
            this.StockNameGridViewColumn});
            this.SelfSelectStockGridView.DataSource = this.stockBindingSource;
            this.SelfSelectStockGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelfSelectStockGridView.Location = new System.Drawing.Point(0, 0);
            this.SelfSelectStockGridView.MultiSelect = false;
            this.SelfSelectStockGridView.Name = "SelfSelectStockGridView";
            this.SelfSelectStockGridView.ReadOnly = true;
            this.SelfSelectStockGridView.RowHeadersVisible = false;
            this.SelfSelectStockGridView.RowTemplate.Height = 23;
            this.SelfSelectStockGridView.Size = new System.Drawing.Size(254, 281);
            this.SelfSelectStockGridView.TabIndex = 0;
            // 
            // StockCodeGridViewColumn
            // 
            this.StockCodeGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StockCodeGridViewColumn.DataPropertyName = "Code";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.StockCodeGridViewColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.StockCodeGridViewColumn.HeaderText = "股票代码";
            this.StockCodeGridViewColumn.Name = "StockCodeGridViewColumn";
            this.StockCodeGridViewColumn.ReadOnly = true;
            // 
            // StockMarketGridViewColumn
            // 
            this.StockMarketGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StockMarketGridViewColumn.DataPropertyName = "Market";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StockMarketGridViewColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.StockMarketGridViewColumn.HeaderText = "交易市场";
            this.StockMarketGridViewColumn.Name = "StockMarketGridViewColumn";
            this.StockMarketGridViewColumn.ReadOnly = true;
            // 
            // StockNameGridViewColumn
            // 
            this.StockNameGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StockNameGridViewColumn.DataPropertyName = "Name";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.NullValue = null;
            this.StockNameGridViewColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.StockNameGridViewColumn.HeaderText = "股票名称";
            this.StockNameGridViewColumn.Name = "StockNameGridViewColumn";
            this.StockNameGridViewColumn.ReadOnly = true;
            // 
            // stockBindingSource
            // 
            this.stockBindingSource.DataSource = typeof(CleverStocker.Model.Stock);
            // 
            // SelfSelectStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 281);
            this.Controls.Add(this.SelfSelectStockGridView);
            this.Name = "SelfSelectStockForm";
            this.TabText = "自选股票";
            this.Text = "自选股票";
            this.Load += new System.EventHandler(this.SelfSelectStockForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SelfSelectStockGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView SelfSelectStockGridView;
        private System.Windows.Forms.BindingSource stockBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockCodeGridViewColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockMarketGridViewColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockNameGridViewColumn;
    }
}