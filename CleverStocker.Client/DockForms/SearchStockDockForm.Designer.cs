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
            this.SuspendLayout();
            // 
            // MainTablePanel
            // 
            this.MainTablePanel.ColumnCount = 2;
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTablePanel.Location = new System.Drawing.Point(140, 99);
            this.MainTablePanel.Name = "MainTablePanel";
            this.MainTablePanel.RowCount = 2;
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTablePanel.Size = new System.Drawing.Size(200, 100);
            this.MainTablePanel.TabIndex = 0;
            // 
            // SearchStockDockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 294);
            this.Controls.Add(this.MainTablePanel);
            this.Name = "SearchStockDockForm";
            this.TabText = "搜索股票";
            this.Text = "搜索股票";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTablePanel;
    }
}