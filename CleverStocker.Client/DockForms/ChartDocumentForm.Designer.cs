namespace CleverStocker.Client.DockForms
{
    partial class ChartDocumentForm
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
            this.ChartRepositoryToolStrip = new System.Windows.Forms.ToolStrip();
            this.StockInfoToolLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ChartTypeToolComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.ChartPictureBox = new System.Windows.Forms.PictureBox();
            this.ChartRepositoryToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ChartRepositoryToolStrip
            // 
            this.ChartRepositoryToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StockInfoToolLabel,
            this.toolStripSeparator1,
            this.ChartTypeToolComboBox,
            this.toolStripSeparator2,
            this.RefreshToolButton});
            this.ChartRepositoryToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ChartRepositoryToolStrip.Name = "ChartRepositoryToolStrip";
            this.ChartRepositoryToolStrip.Size = new System.Drawing.Size(800, 25);
            this.ChartRepositoryToolStrip.TabIndex = 1;
            this.ChartRepositoryToolStrip.Text = "toolStrip1";
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
            // ChartTypeToolComboBox
            // 
            this.ChartTypeToolComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChartTypeToolComboBox.Name = "ChartTypeToolComboBox";
            this.ChartTypeToolComboBox.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // ChartPictureBox
            // 
            this.ChartPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChartPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChartPictureBox.Location = new System.Drawing.Point(0, 25);
            this.ChartPictureBox.Name = "ChartPictureBox";
            this.ChartPictureBox.Size = new System.Drawing.Size(800, 425);
            this.ChartPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ChartPictureBox.TabIndex = 2;
            this.ChartPictureBox.TabStop = false;
            // 
            // ChartDocumentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChartPictureBox);
            this.Controls.Add(this.ChartRepositoryToolStrip);
            this.Name = "ChartDocumentForm";
            this.TabText = "图表";
            this.Text = "图表";
            this.Shown += new System.EventHandler(this.ChartDocumentForm_Shown);
            this.ChartRepositoryToolStrip.ResumeLayout(false);
            this.ChartRepositoryToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ChartPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ChartRepositoryToolStrip;
        private System.Windows.Forms.ToolStripLabel StockInfoToolLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton RefreshToolButton;
        private System.Windows.Forms.ToolStripComboBox ChartTypeToolComboBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.PictureBox ChartPictureBox;
    }
}