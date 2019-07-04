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
            this.MainStockQuotaBaseControl = new CleverStocker.Client.Controls.StockQuotaBaseControl();
            this.SuspendLayout();
            // 
            // MainStockQuotaBaseControl
            // 
            this.MainStockQuotaBaseControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainStockQuotaBaseControl.LabelForecolor = System.Drawing.Color.Empty;
            this.MainStockQuotaBaseControl.Location = new System.Drawing.Point(0, 0);
            this.MainStockQuotaBaseControl.Name = "MainStockQuotaBaseControl";
            this.MainStockQuotaBaseControl.Quota = null;
            this.MainStockQuotaBaseControl.Size = new System.Drawing.Size(349, 240);
            this.MainStockQuotaBaseControl.Stock = null;
            this.MainStockQuotaBaseControl.TabIndex = 0;
            this.MainStockQuotaBaseControl.ValueForecolor = System.Drawing.Color.Empty;
            // 
            // CurrentQuotaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 240);
            this.Controls.Add(this.MainStockQuotaBaseControl);
            this.Name = "CurrentQuotaForm";
            this.TabText = "实时行情";
            this.Text = "实时行情";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CurrentQuotaForm_FormClosed);
            this.Load += new System.EventHandler(this.CurrentQuotaForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.StockQuotaBaseControl MainStockQuotaBaseControl;
    }
}