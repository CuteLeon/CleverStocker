namespace CleverStocker.Client.Controls
{
    partial class StockQuotaControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.AmountValueLabel = new System.Windows.Forms.Label();
            this.CountLabel = new System.Windows.Forms.Label();
            this.CountValueLabel = new System.Windows.Forms.Label();
            this.DayLowPriceValueLabel = new System.Windows.Forms.Label();
            this.DayHighPriceValueLabel = new System.Windows.Forms.Label();
            this.OpeningPriceTodayValueLabel = new System.Windows.Forms.Label();
            this.ClosingPriceYesterdayLabel = new System.Windows.Forms.Label();
            this.ClosingPriceYesterdayValueLabel = new System.Windows.Forms.Label();
            this.OpeningPriceTodayLabel = new System.Windows.Forms.Label();
            this.StockNameValueLabel = new System.Windows.Forms.Label();
            this.MainTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.DayLowPriceLabel = new System.Windows.Forms.Label();
            this.DayHighPriceLabel = new System.Windows.Forms.Label();
            this.SeparatorLabel1 = new System.Windows.Forms.Label();
            this.UpdateTimeValueLabel = new System.Windows.Forms.Label();
            this.MarketValueLabel = new System.Windows.Forms.Label();
            this.CodeValueLabel = new System.Windows.Forms.Label();
            this.CurrentPriceValueLabel = new CleverStocker.Client.Controls.PriceControl();
            this.MainTablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoEllipsis = true;
            this.MainTablePanel.SetColumnSpan(this.AmountLabel, 2);
            this.AmountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AmountLabel.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.AmountLabel.Location = new System.Drawing.Point(145, 141);
            this.AmountLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(145, 18);
            this.AmountLabel.TabIndex = 24;
            this.AmountLabel.Text = "成交金额(元)";
            this.AmountLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // AmountValueLabel
            // 
            this.AmountValueLabel.AutoEllipsis = true;
            this.MainTablePanel.SetColumnSpan(this.AmountValueLabel, 2);
            this.AmountValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AmountValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AmountValueLabel.Location = new System.Drawing.Point(145, 159);
            this.AmountValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AmountValueLabel.Name = "AmountValueLabel";
            this.AmountValueLabel.Size = new System.Drawing.Size(145, 20);
            this.AmountValueLabel.TabIndex = 23;
            this.AmountValueLabel.Text = "-";
            this.AmountValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CountLabel
            // 
            this.CountLabel.AutoEllipsis = true;
            this.CountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CountLabel.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.CountLabel.Location = new System.Drawing.Point(0, 141);
            this.CountLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(145, 18);
            this.CountLabel.TabIndex = 22;
            this.CountLabel.Text = "成交数量(股)";
            this.CountLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // CountValueLabel
            // 
            this.CountValueLabel.AutoEllipsis = true;
            this.CountValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CountValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CountValueLabel.Location = new System.Drawing.Point(0, 159);
            this.CountValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CountValueLabel.Name = "CountValueLabel";
            this.CountValueLabel.Size = new System.Drawing.Size(145, 20);
            this.CountValueLabel.TabIndex = 21;
            this.CountValueLabel.Text = "-";
            this.CountValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DayLowPriceValueLabel
            // 
            this.DayLowPriceValueLabel.AutoEllipsis = true;
            this.MainTablePanel.SetColumnSpan(this.DayLowPriceValueLabel, 2);
            this.DayLowPriceValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DayLowPriceValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DayLowPriceValueLabel.Location = new System.Drawing.Point(145, 83);
            this.DayLowPriceValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.DayLowPriceValueLabel.Name = "DayLowPriceValueLabel";
            this.DayLowPriceValueLabel.Size = new System.Drawing.Size(145, 20);
            this.DayLowPriceValueLabel.TabIndex = 19;
            this.DayLowPriceValueLabel.Text = "-";
            this.DayLowPriceValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DayHighPriceValueLabel
            // 
            this.DayHighPriceValueLabel.AutoEllipsis = true;
            this.DayHighPriceValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DayHighPriceValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.DayHighPriceValueLabel.Location = new System.Drawing.Point(0, 83);
            this.DayHighPriceValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.DayHighPriceValueLabel.Name = "DayHighPriceValueLabel";
            this.DayHighPriceValueLabel.Size = new System.Drawing.Size(145, 20);
            this.DayHighPriceValueLabel.TabIndex = 17;
            this.DayHighPriceValueLabel.Text = "-";
            this.DayHighPriceValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpeningPriceTodayValueLabel
            // 
            this.OpeningPriceTodayValueLabel.AutoEllipsis = true;
            this.MainTablePanel.SetColumnSpan(this.OpeningPriceTodayValueLabel, 2);
            this.OpeningPriceTodayValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpeningPriceTodayValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OpeningPriceTodayValueLabel.Location = new System.Drawing.Point(145, 121);
            this.OpeningPriceTodayValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.OpeningPriceTodayValueLabel.Name = "OpeningPriceTodayValueLabel";
            this.OpeningPriceTodayValueLabel.Size = new System.Drawing.Size(145, 20);
            this.OpeningPriceTodayValueLabel.TabIndex = 15;
            this.OpeningPriceTodayValueLabel.Text = "-";
            this.OpeningPriceTodayValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClosingPriceYesterdayLabel
            // 
            this.ClosingPriceYesterdayLabel.AutoEllipsis = true;
            this.ClosingPriceYesterdayLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClosingPriceYesterdayLabel.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.ClosingPriceYesterdayLabel.Location = new System.Drawing.Point(0, 103);
            this.ClosingPriceYesterdayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ClosingPriceYesterdayLabel.Name = "ClosingPriceYesterdayLabel";
            this.ClosingPriceYesterdayLabel.Size = new System.Drawing.Size(145, 18);
            this.ClosingPriceYesterdayLabel.TabIndex = 14;
            this.ClosingPriceYesterdayLabel.Text = "昨日收盘价(元)";
            this.ClosingPriceYesterdayLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // ClosingPriceYesterdayValueLabel
            // 
            this.ClosingPriceYesterdayValueLabel.AutoEllipsis = true;
            this.ClosingPriceYesterdayValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClosingPriceYesterdayValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClosingPriceYesterdayValueLabel.Location = new System.Drawing.Point(0, 121);
            this.ClosingPriceYesterdayValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.ClosingPriceYesterdayValueLabel.Name = "ClosingPriceYesterdayValueLabel";
            this.ClosingPriceYesterdayValueLabel.Size = new System.Drawing.Size(145, 20);
            this.ClosingPriceYesterdayValueLabel.TabIndex = 13;
            this.ClosingPriceYesterdayValueLabel.Text = "-";
            this.ClosingPriceYesterdayValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OpeningPriceTodayLabel
            // 
            this.OpeningPriceTodayLabel.AutoEllipsis = true;
            this.MainTablePanel.SetColumnSpan(this.OpeningPriceTodayLabel, 2);
            this.OpeningPriceTodayLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpeningPriceTodayLabel.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.OpeningPriceTodayLabel.Location = new System.Drawing.Point(145, 103);
            this.OpeningPriceTodayLabel.Margin = new System.Windows.Forms.Padding(0);
            this.OpeningPriceTodayLabel.Name = "OpeningPriceTodayLabel";
            this.OpeningPriceTodayLabel.Size = new System.Drawing.Size(145, 18);
            this.OpeningPriceTodayLabel.TabIndex = 16;
            this.OpeningPriceTodayLabel.Text = "今日开盘价(元)";
            this.OpeningPriceTodayLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // StockNameValueLabel
            // 
            this.StockNameValueLabel.AutoEllipsis = true;
            this.StockNameValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StockNameValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StockNameValueLabel.Location = new System.Drawing.Point(203, 40);
            this.StockNameValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.StockNameValueLabel.Name = "StockNameValueLabel";
            this.StockNameValueLabel.Size = new System.Drawing.Size(87, 20);
            this.StockNameValueLabel.TabIndex = 10;
            this.StockNameValueLabel.Text = "-";
            this.StockNameValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainTablePanel
            // 
            this.MainTablePanel.AutoScroll = true;
            this.MainTablePanel.ColumnCount = 3;
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.MainTablePanel.Controls.Add(this.DayLowPriceLabel, 1, 4);
            this.MainTablePanel.Controls.Add(this.DayHighPriceLabel, 0, 4);
            this.MainTablePanel.Controls.Add(this.SeparatorLabel1, 0, 3);
            this.MainTablePanel.Controls.Add(this.UpdateTimeValueLabel, 0, 2);
            this.MainTablePanel.Controls.Add(this.MarketValueLabel, 2, 1);
            this.MainTablePanel.Controls.Add(this.CodeValueLabel, 2, 0);
            this.MainTablePanel.Controls.Add(this.AmountLabel, 1, 8);
            this.MainTablePanel.Controls.Add(this.AmountValueLabel, 1, 9);
            this.MainTablePanel.Controls.Add(this.CountLabel, 0, 8);
            this.MainTablePanel.Controls.Add(this.CountValueLabel, 0, 9);
            this.MainTablePanel.Controls.Add(this.DayLowPriceValueLabel, 1, 5);
            this.MainTablePanel.Controls.Add(this.DayHighPriceValueLabel, 0, 5);
            this.MainTablePanel.Controls.Add(this.OpeningPriceTodayLabel, 1, 6);
            this.MainTablePanel.Controls.Add(this.OpeningPriceTodayValueLabel, 1, 7);
            this.MainTablePanel.Controls.Add(this.ClosingPriceYesterdayLabel, 0, 6);
            this.MainTablePanel.Controls.Add(this.ClosingPriceYesterdayValueLabel, 0, 7);
            this.MainTablePanel.Controls.Add(this.StockNameValueLabel, 2, 2);
            this.MainTablePanel.Controls.Add(this.CurrentPriceValueLabel, 0, 0);
            this.MainTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTablePanel.Location = new System.Drawing.Point(3, 3);
            this.MainTablePanel.Name = "MainTablePanel";
            this.MainTablePanel.RowCount = 11;
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.Size = new System.Drawing.Size(290, 194);
            this.MainTablePanel.TabIndex = 1;
            // 
            // DayLowPriceLabel
            // 
            this.DayLowPriceLabel.AutoEllipsis = true;
            this.MainTablePanel.SetColumnSpan(this.DayLowPriceLabel, 2);
            this.DayLowPriceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DayLowPriceLabel.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.DayLowPriceLabel.Location = new System.Drawing.Point(145, 65);
            this.DayLowPriceLabel.Margin = new System.Windows.Forms.Padding(0);
            this.DayLowPriceLabel.Name = "DayLowPriceLabel";
            this.DayLowPriceLabel.Size = new System.Drawing.Size(145, 18);
            this.DayLowPriceLabel.TabIndex = 37;
            this.DayLowPriceLabel.Text = "今日最低价(元)";
            this.DayLowPriceLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // DayHighPriceLabel
            // 
            this.DayHighPriceLabel.AutoEllipsis = true;
            this.DayHighPriceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DayHighPriceLabel.Font = new System.Drawing.Font("微软雅黑", 8F);
            this.DayHighPriceLabel.Location = new System.Drawing.Point(0, 65);
            this.DayHighPriceLabel.Margin = new System.Windows.Forms.Padding(0);
            this.DayHighPriceLabel.Name = "DayHighPriceLabel";
            this.DayHighPriceLabel.Size = new System.Drawing.Size(145, 18);
            this.DayHighPriceLabel.TabIndex = 36;
            this.DayHighPriceLabel.Text = "今日最高价(元)";
            this.DayHighPriceLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // SeparatorLabel1
            // 
            this.SeparatorLabel1.AutoSize = true;
            this.SeparatorLabel1.BackColor = System.Drawing.Color.Gray;
            this.MainTablePanel.SetColumnSpan(this.SeparatorLabel1, 3);
            this.SeparatorLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SeparatorLabel1.Location = new System.Drawing.Point(10, 62);
            this.SeparatorLabel1.Margin = new System.Windows.Forms.Padding(10, 2, 10, 2);
            this.SeparatorLabel1.Name = "SeparatorLabel1";
            this.SeparatorLabel1.Size = new System.Drawing.Size(270, 1);
            this.SeparatorLabel1.TabIndex = 35;
            // 
            // UpdateTimeValueLabel
            // 
            this.UpdateTimeValueLabel.AutoEllipsis = true;
            this.MainTablePanel.SetColumnSpan(this.UpdateTimeValueLabel, 2);
            this.UpdateTimeValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UpdateTimeValueLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UpdateTimeValueLabel.Location = new System.Drawing.Point(0, 40);
            this.UpdateTimeValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.UpdateTimeValueLabel.Name = "UpdateTimeValueLabel";
            this.UpdateTimeValueLabel.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.UpdateTimeValueLabel.Size = new System.Drawing.Size(203, 20);
            this.UpdateTimeValueLabel.TabIndex = 34;
            this.UpdateTimeValueLabel.Text = "-";
            this.UpdateTimeValueLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // MarketValueLabel
            // 
            this.MarketValueLabel.AutoEllipsis = true;
            this.MarketValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MarketValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MarketValueLabel.Location = new System.Drawing.Point(203, 20);
            this.MarketValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.MarketValueLabel.Name = "MarketValueLabel";
            this.MarketValueLabel.Size = new System.Drawing.Size(87, 20);
            this.MarketValueLabel.TabIndex = 30;
            this.MarketValueLabel.Text = "-";
            this.MarketValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CodeValueLabel
            // 
            this.CodeValueLabel.AutoEllipsis = true;
            this.CodeValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CodeValueLabel.Location = new System.Drawing.Point(203, 0);
            this.CodeValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CodeValueLabel.Name = "CodeValueLabel";
            this.CodeValueLabel.Size = new System.Drawing.Size(87, 20);
            this.CodeValueLabel.TabIndex = 28;
            this.CodeValueLabel.Text = "-";
            this.CodeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CurrentPriceValueLabel
            // 
            this.CurrentPriceValueLabel.Accuracy = ((byte)(4));
            this.CurrentPriceValueLabel.AutoEllipsis = true;
            this.CurrentPriceValueLabel.AutoSize = true;
            this.CurrentPriceValueLabel.BasePrice = 0D;
            this.MainTablePanel.SetColumnSpan(this.CurrentPriceValueLabel, 2);
            this.CurrentPriceValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentPriceValueLabel.FallForeColor = System.Drawing.Color.LimeGreen;
            this.CurrentPriceValueLabel.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.CurrentPriceValueLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CurrentPriceValueLabel.ImageIndex = 0;
            this.CurrentPriceValueLabel.Location = new System.Drawing.Point(0, 0);
            this.CurrentPriceValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CurrentPriceValueLabel.Name = "CurrentPriceValueLabel";
            this.CurrentPriceValueLabel.Price = double.NaN;
            this.CurrentPriceValueLabel.RiseForeColor = System.Drawing.Color.Crimson;
            this.MainTablePanel.SetRowSpan(this.CurrentPriceValueLabel, 2);
            this.CurrentPriceValueLabel.Size = new System.Drawing.Size(203, 40);
            this.CurrentPriceValueLabel.StaticForecolor = System.Drawing.Color.Black;
            this.CurrentPriceValueLabel.TabIndex = 38;
            this.CurrentPriceValueLabel.Text = "-";
            this.CurrentPriceValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StockQuotaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTablePanel);
            this.Name = "StockQuotaControl";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(296, 200);
            this.MainTablePanel.ResumeLayout(false);
            this.MainTablePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.Label AmountValueLabel;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Label CountValueLabel;
        private System.Windows.Forms.Label DayLowPriceValueLabel;
        private System.Windows.Forms.Label DayHighPriceValueLabel;
        private System.Windows.Forms.Label OpeningPriceTodayValueLabel;
        private System.Windows.Forms.Label ClosingPriceYesterdayLabel;
        private System.Windows.Forms.Label ClosingPriceYesterdayValueLabel;
        private System.Windows.Forms.Label OpeningPriceTodayLabel;
        private System.Windows.Forms.Label StockNameValueLabel;
        private System.Windows.Forms.TableLayoutPanel MainTablePanel;
        private System.Windows.Forms.Label MarketValueLabel;
        private System.Windows.Forms.Label CodeValueLabel;
        private System.Windows.Forms.Label UpdateTimeValueLabel;
        private System.Windows.Forms.Label SeparatorLabel1;
        private System.Windows.Forms.Label DayHighPriceLabel;
        private System.Windows.Forms.Label DayLowPriceLabel;
        private PriceControl CurrentPriceValueLabel;
    }
}
