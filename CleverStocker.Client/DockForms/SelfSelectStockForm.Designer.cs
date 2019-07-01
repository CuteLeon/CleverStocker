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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelfSelectStockForm));
            this.SelfSelectStockToolStrip = new System.Windows.Forms.ToolStrip();
            this.AddToolButton = new System.Windows.Forms.ToolStripButton();
            this.RemoveToolButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshToolButton = new System.Windows.Forms.ToolStripButton();
            this.SelfSelectStockGridView = new System.Windows.Forms.DataGridView();
            this.StockCodeGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockMarketGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockNameGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelfSelectStockBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SelfSelectGridViewMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelfSelectStockToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelfSelectStockGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelfSelectStockBindingSource)).BeginInit();
            this.SelfSelectGridViewMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelfSelectStockToolStrip
            // 
            this.SelfSelectStockToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolButton,
            this.RemoveToolButton,
            this.RefreshToolButton});
            this.SelfSelectStockToolStrip.Location = new System.Drawing.Point(0, 0);
            this.SelfSelectStockToolStrip.Name = "SelfSelectStockToolStrip";
            this.SelfSelectStockToolStrip.Size = new System.Drawing.Size(254, 25);
            this.SelfSelectStockToolStrip.TabIndex = 0;
            // 
            // AddToolButton
            // 
            this.AddToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddToolButton.Image = ((System.Drawing.Image)(resources.GetObject("AddToolButton.Image")));
            this.AddToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddToolButton.Name = "AddToolButton";
            this.AddToolButton.Size = new System.Drawing.Size(36, 22);
            this.AddToolButton.Text = "添加";
            // 
            // RemoveToolButton
            // 
            this.RemoveToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RemoveToolButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveToolButton.Image")));
            this.RemoveToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RemoveToolButton.Name = "RemoveToolButton";
            this.RemoveToolButton.Size = new System.Drawing.Size(36, 22);
            this.RemoveToolButton.Text = "删除";
            // 
            // RefreshToolButton
            // 
            this.RefreshToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.RefreshToolButton.Image = ((System.Drawing.Image)(resources.GetObject("RefreshToolButton.Image")));
            this.RefreshToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshToolButton.Name = "RefreshToolButton";
            this.RefreshToolButton.Size = new System.Drawing.Size(36, 22);
            this.RefreshToolButton.Text = "刷新";
            // 
            // SelfSelectStockGridView
            // 
            this.SelfSelectStockGridView.AllowUserToAddRows = false;
            this.SelfSelectStockGridView.AllowUserToDeleteRows = false;
            this.SelfSelectStockGridView.AllowUserToOrderColumns = true;
            this.SelfSelectStockGridView.AllowUserToResizeColumns = false;
            this.SelfSelectStockGridView.AllowUserToResizeRows = false;
            this.SelfSelectStockGridView.AutoGenerateColumns = false;
            this.SelfSelectStockGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SelfSelectStockGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.SelfSelectStockGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SelfSelectStockGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.SelfSelectStockGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.SelfSelectStockGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SelfSelectStockGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StockCodeGridViewColumn,
            this.StockMarketGridViewColumn,
            this.StockNameGridViewColumn});
            this.SelfSelectStockGridView.DataSource = this.SelfSelectStockBindingSource;
            this.SelfSelectStockGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelfSelectStockGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.SelfSelectStockGridView.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.SelfSelectStockGridView.Location = new System.Drawing.Point(0, 25);
            this.SelfSelectStockGridView.MultiSelect = false;
            this.SelfSelectStockGridView.Name = "SelfSelectStockGridView";
            this.SelfSelectStockGridView.ReadOnly = true;
            this.SelfSelectStockGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.SelfSelectStockGridView.RowHeadersVisible = false;
            this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SelfSelectStockGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SelfSelectStockGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SelfSelectStockGridView.Size = new System.Drawing.Size(254, 256);
            this.SelfSelectStockGridView.TabIndex = 1;
            this.SelfSelectStockGridView.SelectionChanged += new System.EventHandler(this.SelfSelectStockGridView_SelectionChanged);
            // 
            // StockCodeGridViewColumn
            // 
            this.StockCodeGridViewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.StockCodeGridViewColumn.DataPropertyName = "Code";
            this.StockCodeGridViewColumn.HeaderText = "代码";
            this.StockCodeGridViewColumn.Name = "StockCodeGridViewColumn";
            this.StockCodeGridViewColumn.ReadOnly = true;
            // 
            // StockMarketGridViewColumn
            // 
            this.StockMarketGridViewColumn.DataPropertyName = "Market";
            this.StockMarketGridViewColumn.HeaderText = "市场";
            this.StockMarketGridViewColumn.Name = "StockMarketGridViewColumn";
            this.StockMarketGridViewColumn.ReadOnly = true;
            // 
            // StockNameGridViewColumn
            // 
            this.StockNameGridViewColumn.DataPropertyName = "Name";
            this.StockNameGridViewColumn.HeaderText = "名称";
            this.StockNameGridViewColumn.Name = "StockNameGridViewColumn";
            this.StockNameGridViewColumn.ReadOnly = true;
            // 
            // SelfSelectStockBindingSource
            // 
            this.SelfSelectStockBindingSource.DataSource = typeof(CleverStocker.Model.Stock);
            // 
            // SelfSelectGridViewMenuStrip
            // 
            this.SelfSelectGridViewMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddMenuItem,
            this.RemoveMenuItem,
            this.RefreshMenuItem});
            this.SelfSelectGridViewMenuStrip.Name = "SelfSelectGridViewMenuStrip";
            this.SelfSelectGridViewMenuStrip.Size = new System.Drawing.Size(101, 70);
            // 
            // AddMenuItem
            // 
            this.AddMenuItem.Name = "AddMenuItem";
            this.AddMenuItem.Size = new System.Drawing.Size(100, 22);
            this.AddMenuItem.Text = "添加";
            // 
            // RemoveMenuItem
            // 
            this.RemoveMenuItem.Name = "RemoveMenuItem";
            this.RemoveMenuItem.Size = new System.Drawing.Size(100, 22);
            this.RemoveMenuItem.Text = "移除";
            // 
            // RefreshMenuItem
            // 
            this.RefreshMenuItem.Name = "RefreshMenuItem";
            this.RefreshMenuItem.Size = new System.Drawing.Size(100, 22);
            this.RefreshMenuItem.Text = "刷新";
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
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SelfSelectStockForm_FormClosed);
            this.Load += new System.EventHandler(this.SelfSelectStockForm_Load);
            this.SelfSelectStockToolStrip.ResumeLayout(false);
            this.SelfSelectStockToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelfSelectStockGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelfSelectStockBindingSource)).EndInit();
            this.SelfSelectGridViewMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip SelfSelectStockToolStrip;
        private System.Windows.Forms.DataGridView SelfSelectStockGridView;
        private System.Windows.Forms.ToolStripButton RefreshToolButton;
        private System.Windows.Forms.ContextMenuStrip SelfSelectGridViewMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RefreshMenuItem;
        private System.Windows.Forms.ToolStripButton AddToolButton;
        private System.Windows.Forms.ToolStripButton RemoveToolButton;
        private System.Windows.Forms.ToolStripMenuItem AddMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveMenuItem;
        private System.Windows.Forms.BindingSource SelfSelectStockBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockCodeGridViewColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockMarketGridViewColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockNameGridViewColumn;
    }
}