namespace CleverStocker.Client.Controls
{
    partial class MarketQuotaControl
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
            this.MarketValueLabel = new System.Windows.Forms.Label();
            this.MarketLabel = new System.Windows.Forms.Label();
            this.CodeLabel = new System.Windows.Forms.Label();
            this.MainTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.CodeValueLabel = new System.Windows.Forms.Label();
            this.UpdateTimeLabel = new System.Windows.Forms.Label();
            this.UpdateTimeValueLabel = new System.Windows.Forms.Label();
            this.AmountLabel = new System.Windows.Forms.Label();
            this.AmountValueLabel = new System.Windows.Forms.Label();
            this.CountLabel = new System.Windows.Forms.Label();
            this.CountValueLabel = new System.Windows.Forms.Label();
            this.FluctuatingRateLabel = new System.Windows.Forms.Label();
            this.FluctuatingRateValueLabel = new System.Windows.Forms.Label();
            this.FluctuatingRangeLabel = new System.Windows.Forms.Label();
            this.FluctuatingRangeValueLabel = new System.Windows.Forms.Label();
            this.CurrentPriceLabel = new System.Windows.Forms.Label();
            this.CurrentPriceValueLabel = new System.Windows.Forms.Label();
            this.StockNameValueLabel = new System.Windows.Forms.Label();
            this.StockNameLabel = new System.Windows.Forms.Label();
            this.MainTablePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MarketValueLabel
            // 
            this.MarketValueLabel.AutoEllipsis = true;
            this.MarketValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MarketValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MarketValueLabel.Location = new System.Drawing.Point(90, 20);
            this.MarketValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.MarketValueLabel.Name = "MarketValueLabel";
            this.MarketValueLabel.Size = new System.Drawing.Size(179, 20);
            this.MarketValueLabel.TabIndex = 30;
            this.MarketValueLabel.Text = "-";
            this.MarketValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MarketLabel
            // 
            this.MarketLabel.AutoEllipsis = true;
            this.MarketLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MarketLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MarketLabel.Location = new System.Drawing.Point(0, 20);
            this.MarketLabel.Margin = new System.Windows.Forms.Padding(0);
            this.MarketLabel.Name = "MarketLabel";
            this.MarketLabel.Size = new System.Drawing.Size(90, 20);
            this.MarketLabel.TabIndex = 29;
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
            this.CodeLabel.Size = new System.Drawing.Size(90, 20);
            this.CodeLabel.TabIndex = 27;
            this.CodeLabel.Text = "股票代码";
            this.CodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainTablePanel
            // 
            this.MainTablePanel.AutoScroll = true;
            this.MainTablePanel.ColumnCount = 2;
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.Controls.Add(this.MarketValueLabel, 1, 1);
            this.MainTablePanel.Controls.Add(this.MarketLabel, 0, 1);
            this.MainTablePanel.Controls.Add(this.CodeValueLabel, 1, 0);
            this.MainTablePanel.Controls.Add(this.CodeLabel, 0, 0);
            this.MainTablePanel.Controls.Add(this.UpdateTimeLabel, 0, 8);
            this.MainTablePanel.Controls.Add(this.UpdateTimeValueLabel, 1, 8);
            this.MainTablePanel.Controls.Add(this.AmountLabel, 0, 7);
            this.MainTablePanel.Controls.Add(this.AmountValueLabel, 1, 7);
            this.MainTablePanel.Controls.Add(this.CountLabel, 0, 6);
            this.MainTablePanel.Controls.Add(this.CountValueLabel, 1, 6);
            this.MainTablePanel.Controls.Add(this.FluctuatingRateLabel, 0, 5);
            this.MainTablePanel.Controls.Add(this.FluctuatingRateValueLabel, 1, 5);
            this.MainTablePanel.Controls.Add(this.FluctuatingRangeLabel, 0, 4);
            this.MainTablePanel.Controls.Add(this.FluctuatingRangeValueLabel, 1, 4);
            this.MainTablePanel.Controls.Add(this.CurrentPriceLabel, 0, 3);
            this.MainTablePanel.Controls.Add(this.CurrentPriceValueLabel, 1, 3);
            this.MainTablePanel.Controls.Add(this.StockNameValueLabel, 1, 2);
            this.MainTablePanel.Controls.Add(this.StockNameLabel, 0, 2);
            this.MainTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTablePanel.Location = new System.Drawing.Point(3, 3);
            this.MainTablePanel.Name = "MainTablePanel";
            this.MainTablePanel.RowCount = 10;
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainTablePanel.Size = new System.Drawing.Size(269, 232);
            this.MainTablePanel.TabIndex = 2;
            // 
            // CodeValueLabel
            // 
            this.CodeValueLabel.AutoEllipsis = true;
            this.CodeValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CodeValueLabel.Location = new System.Drawing.Point(90, 0);
            this.CodeValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CodeValueLabel.Name = "CodeValueLabel";
            this.CodeValueLabel.Size = new System.Drawing.Size(179, 20);
            this.CodeValueLabel.TabIndex = 28;
            this.CodeValueLabel.Text = "-";
            this.CodeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UpdateTimeLabel
            // 
            this.UpdateTimeLabel.AutoEllipsis = true;
            this.UpdateTimeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UpdateTimeLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UpdateTimeLabel.Location = new System.Drawing.Point(0, 160);
            this.UpdateTimeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.UpdateTimeLabel.Name = "UpdateTimeLabel";
            this.UpdateTimeLabel.Size = new System.Drawing.Size(90, 20);
            this.UpdateTimeLabel.TabIndex = 26;
            this.UpdateTimeLabel.Text = "更新时间";
            this.UpdateTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UpdateTimeValueLabel
            // 
            this.UpdateTimeValueLabel.AutoEllipsis = true;
            this.UpdateTimeValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UpdateTimeValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UpdateTimeValueLabel.Location = new System.Drawing.Point(90, 160);
            this.UpdateTimeValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.UpdateTimeValueLabel.Name = "UpdateTimeValueLabel";
            this.UpdateTimeValueLabel.Size = new System.Drawing.Size(179, 20);
            this.UpdateTimeValueLabel.TabIndex = 25;
            this.UpdateTimeValueLabel.Text = "-";
            this.UpdateTimeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmountLabel
            // 
            this.AmountLabel.AutoEllipsis = true;
            this.AmountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AmountLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AmountLabel.Location = new System.Drawing.Point(0, 140);
            this.AmountLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AmountLabel.Name = "AmountLabel";
            this.AmountLabel.Size = new System.Drawing.Size(90, 20);
            this.AmountLabel.TabIndex = 24;
            this.AmountLabel.Text = "成交金额(万元)";
            this.AmountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AmountValueLabel
            // 
            this.AmountValueLabel.AutoEllipsis = true;
            this.AmountValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AmountValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AmountValueLabel.Location = new System.Drawing.Point(90, 140);
            this.AmountValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AmountValueLabel.Name = "AmountValueLabel";
            this.AmountValueLabel.Size = new System.Drawing.Size(179, 20);
            this.AmountValueLabel.TabIndex = 23;
            this.AmountValueLabel.Text = "-";
            this.AmountValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CountLabel
            // 
            this.CountLabel.AutoEllipsis = true;
            this.CountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CountLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CountLabel.Location = new System.Drawing.Point(0, 120);
            this.CountLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(90, 20);
            this.CountLabel.TabIndex = 22;
            this.CountLabel.Text = "成交数量(手)";
            this.CountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CountValueLabel
            // 
            this.CountValueLabel.AutoEllipsis = true;
            this.CountValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CountValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CountValueLabel.Location = new System.Drawing.Point(90, 120);
            this.CountValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CountValueLabel.Name = "CountValueLabel";
            this.CountValueLabel.Size = new System.Drawing.Size(179, 20);
            this.CountValueLabel.TabIndex = 21;
            this.CountValueLabel.Text = "-";
            this.CountValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FluctuatingRateLabel
            // 
            this.FluctuatingRateLabel.AutoEllipsis = true;
            this.FluctuatingRateLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FluctuatingRateLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FluctuatingRateLabel.Location = new System.Drawing.Point(0, 100);
            this.FluctuatingRateLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FluctuatingRateLabel.Name = "FluctuatingRateLabel";
            this.FluctuatingRateLabel.Size = new System.Drawing.Size(90, 20);
            this.FluctuatingRateLabel.TabIndex = 16;
            this.FluctuatingRateLabel.Text = "涨跌比例(%)";
            this.FluctuatingRateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FluctuatingRateValueLabel
            // 
            this.FluctuatingRateValueLabel.AutoEllipsis = true;
            this.FluctuatingRateValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FluctuatingRateValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FluctuatingRateValueLabel.Location = new System.Drawing.Point(90, 100);
            this.FluctuatingRateValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FluctuatingRateValueLabel.Name = "FluctuatingRateValueLabel";
            this.FluctuatingRateValueLabel.Size = new System.Drawing.Size(179, 20);
            this.FluctuatingRateValueLabel.TabIndex = 15;
            this.FluctuatingRateValueLabel.Text = "-";
            this.FluctuatingRateValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FluctuatingRangeLabel
            // 
            this.FluctuatingRangeLabel.AutoEllipsis = true;
            this.FluctuatingRangeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FluctuatingRangeLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FluctuatingRangeLabel.Location = new System.Drawing.Point(0, 80);
            this.FluctuatingRangeLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FluctuatingRangeLabel.Name = "FluctuatingRangeLabel";
            this.FluctuatingRangeLabel.Size = new System.Drawing.Size(90, 20);
            this.FluctuatingRangeLabel.TabIndex = 14;
            this.FluctuatingRangeLabel.Text = "涨跌幅度(元)";
            this.FluctuatingRangeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FluctuatingRangeValueLabel
            // 
            this.FluctuatingRangeValueLabel.AutoEllipsis = true;
            this.FluctuatingRangeValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FluctuatingRangeValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FluctuatingRangeValueLabel.Location = new System.Drawing.Point(90, 80);
            this.FluctuatingRangeValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.FluctuatingRangeValueLabel.Name = "FluctuatingRangeValueLabel";
            this.FluctuatingRangeValueLabel.Size = new System.Drawing.Size(179, 20);
            this.FluctuatingRangeValueLabel.TabIndex = 13;
            this.FluctuatingRangeValueLabel.Text = "-";
            this.FluctuatingRangeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentPriceLabel
            // 
            this.CurrentPriceLabel.AutoEllipsis = true;
            this.CurrentPriceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentPriceLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CurrentPriceLabel.Location = new System.Drawing.Point(0, 60);
            this.CurrentPriceLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CurrentPriceLabel.Name = "CurrentPriceLabel";
            this.CurrentPriceLabel.Size = new System.Drawing.Size(90, 20);
            this.CurrentPriceLabel.TabIndex = 12;
            this.CurrentPriceLabel.Text = "当前价格(元)";
            this.CurrentPriceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CurrentPriceValueLabel
            // 
            this.CurrentPriceValueLabel.AutoEllipsis = true;
            this.CurrentPriceValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CurrentPriceValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CurrentPriceValueLabel.Location = new System.Drawing.Point(90, 60);
            this.CurrentPriceValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.CurrentPriceValueLabel.Name = "CurrentPriceValueLabel";
            this.CurrentPriceValueLabel.Size = new System.Drawing.Size(179, 20);
            this.CurrentPriceValueLabel.TabIndex = 11;
            this.CurrentPriceValueLabel.Text = "-";
            this.CurrentPriceValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StockNameValueLabel
            // 
            this.StockNameValueLabel.AutoEllipsis = true;
            this.StockNameValueLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StockNameValueLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StockNameValueLabel.Location = new System.Drawing.Point(90, 40);
            this.StockNameValueLabel.Margin = new System.Windows.Forms.Padding(0);
            this.StockNameValueLabel.Name = "StockNameValueLabel";
            this.StockNameValueLabel.Size = new System.Drawing.Size(179, 20);
            this.StockNameValueLabel.TabIndex = 10;
            this.StockNameValueLabel.Text = "-";
            this.StockNameValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StockNameLabel
            // 
            this.StockNameLabel.AutoEllipsis = true;
            this.StockNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StockNameLabel.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StockNameLabel.Location = new System.Drawing.Point(0, 40);
            this.StockNameLabel.Margin = new System.Windows.Forms.Padding(0);
            this.StockNameLabel.Name = "StockNameLabel";
            this.StockNameLabel.Size = new System.Drawing.Size(90, 20);
            this.StockNameLabel.TabIndex = 9;
            this.StockNameLabel.Text = "股票名称";
            this.StockNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MarketQuotaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MainTablePanel);
            this.Name = "MarketQuotaControl";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(275, 238);
            this.MainTablePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label MarketValueLabel;
        private System.Windows.Forms.Label MarketLabel;
        private System.Windows.Forms.Label CodeLabel;
        private System.Windows.Forms.TableLayoutPanel MainTablePanel;
        private System.Windows.Forms.Label CodeValueLabel;
        private System.Windows.Forms.Label UpdateTimeLabel;
        private System.Windows.Forms.Label UpdateTimeValueLabel;
        private System.Windows.Forms.Label AmountLabel;
        private System.Windows.Forms.Label AmountValueLabel;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Label CountValueLabel;
        private System.Windows.Forms.Label FluctuatingRateLabel;
        private System.Windows.Forms.Label FluctuatingRateValueLabel;
        private System.Windows.Forms.Label FluctuatingRangeLabel;
        private System.Windows.Forms.Label FluctuatingRangeValueLabel;
        private System.Windows.Forms.Label CurrentPriceLabel;
        private System.Windows.Forms.Label CurrentPriceValueLabel;
        private System.Windows.Forms.Label StockNameValueLabel;
        private System.Windows.Forms.Label StockNameLabel;
    }
}
