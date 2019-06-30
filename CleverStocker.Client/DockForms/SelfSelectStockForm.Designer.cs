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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SelfSelectStockToolStrip = new System.Windows.Forms.ToolStrip();
            this.SelfSelectStockGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.SelfSelectStockGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SelfSelectStockToolStrip
            // 
            this.SelfSelectStockToolStrip.Location = new System.Drawing.Point(0, 0);
            this.SelfSelectStockToolStrip.Name = "SelfSelectStockToolStrip";
            this.SelfSelectStockToolStrip.Size = new System.Drawing.Size(254, 25);
            this.SelfSelectStockToolStrip.TabIndex = 0;
            this.SelfSelectStockToolStrip.Text = "toolStrip1";
            // 
            // SelfSelectStockGridView
            // 
            this.SelfSelectStockGridView.AllowUserToAddRows = false;
            this.SelfSelectStockGridView.AllowUserToDeleteRows = false;
            this.SelfSelectStockGridView.AllowUserToOrderColumns = true;
            this.SelfSelectStockGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SelfSelectStockGridView.BackgroundColor = System.Drawing.SystemColors.Control;
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
            this.SelfSelectStockGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelfSelectStockGridView.Location = new System.Drawing.Point(0, 25);
            this.SelfSelectStockGridView.MultiSelect = false;
            this.SelfSelectStockGridView.Name = "SelfSelectStockGridView";
            this.SelfSelectStockGridView.ReadOnly = true;
            this.SelfSelectStockGridView.RowHeadersVisible = false;
            this.SelfSelectStockGridView.RowTemplate.Height = 23;
            this.SelfSelectStockGridView.Size = new System.Drawing.Size(254, 256);
            this.SelfSelectStockGridView.TabIndex = 1;
            // 
            // SelfSelectStockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 281);
            this.Controls.Add(this.SelfSelectStockGridView);
            this.Controls.Add(this.SelfSelectStockToolStrip);
            this.Name = "SelfSelectStockForm";
            this.TabText = "自选股票";
            this.Text = "自选股票";
            this.Load += new System.EventHandler(this.SelfSelectStockForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SelfSelectStockGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip SelfSelectStockToolStrip;
        private System.Windows.Forms.DataGridView SelfSelectStockGridView;
    }
}