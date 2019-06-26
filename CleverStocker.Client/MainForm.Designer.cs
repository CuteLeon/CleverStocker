namespace CleverStocker.Client
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainTopMenuStrip = new System.Windows.Forms.MenuStrip();
            this.StartMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ThemeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClassicsThemeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LightThemeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BlueThemeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DarkThemeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainToolStrip = new System.Windows.Forms.ToolStrip();
            this.TestToolItem = new System.Windows.Forms.ToolStripButton();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.StateStatusItem = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressStatusItem = new System.Windows.Forms.ToolStripProgressBar();
            this.MainDockPanel = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.MainTopMenuStrip.SuspendLayout();
            this.MainToolStrip.SuspendLayout();
            this.MainStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTopMenuStrip
            // 
            this.MainTopMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartMenuItem,
            this.ThemeMenuItem});
            this.MainTopMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainTopMenuStrip.Name = "MainTopMenuStrip";
            this.MainTopMenuStrip.Size = new System.Drawing.Size(800, 25);
            this.MainTopMenuStrip.TabIndex = 0;
            // 
            // StartMenuItem
            // 
            this.StartMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitMenuItem});
            this.StartMenuItem.Name = "StartMenuItem";
            this.StartMenuItem.Size = new System.Drawing.Size(44, 21);
            this.StartMenuItem.Text = "开始";
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(100, 22);
            this.ExitMenuItem.Text = "退出";
            // 
            // ThemeMenuItem
            // 
            this.ThemeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClassicsThemeMenuItem,
            this.toolStripSeparator1,
            this.LightThemeMenuItem,
            this.BlueThemeMenuItem,
            this.DarkThemeMenuItem});
            this.ThemeMenuItem.Name = "ThemeMenuItem";
            this.ThemeMenuItem.Size = new System.Drawing.Size(44, 21);
            this.ThemeMenuItem.Text = "主题";
            // 
            // ClassicsThemeMenuItem
            // 
            this.ClassicsThemeMenuItem.Name = "ClassicsThemeMenuItem";
            this.ClassicsThemeMenuItem.Size = new System.Drawing.Size(100, 22);
            this.ClassicsThemeMenuItem.Text = "经典";
            this.ClassicsThemeMenuItem.Click += new System.EventHandler(this.ClassicsThemeMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(97, 6);
            // 
            // LightThemeMenuItem
            // 
            this.LightThemeMenuItem.Name = "LightThemeMenuItem";
            this.LightThemeMenuItem.Size = new System.Drawing.Size(100, 22);
            this.LightThemeMenuItem.Text = "浅色";
            this.LightThemeMenuItem.Click += new System.EventHandler(this.LightThemeMenuItem_Click);
            // 
            // BlueThemeMenuItem
            // 
            this.BlueThemeMenuItem.Name = "BlueThemeMenuItem";
            this.BlueThemeMenuItem.Size = new System.Drawing.Size(100, 22);
            this.BlueThemeMenuItem.Text = "蓝色";
            this.BlueThemeMenuItem.Click += new System.EventHandler(this.BlueThemeMenuItem_Click);
            // 
            // DarkThemeMenuItem
            // 
            this.DarkThemeMenuItem.Name = "DarkThemeMenuItem";
            this.DarkThemeMenuItem.Size = new System.Drawing.Size(100, 22);
            this.DarkThemeMenuItem.Text = "深色";
            this.DarkThemeMenuItem.Click += new System.EventHandler(this.DarkThemeMenuItem_Click);
            // 
            // MainToolStrip
            // 
            this.MainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TestToolItem});
            this.MainToolStrip.Location = new System.Drawing.Point(0, 25);
            this.MainToolStrip.Name = "MainToolStrip";
            this.MainToolStrip.Size = new System.Drawing.Size(800, 25);
            this.MainToolStrip.TabIndex = 2;
            // 
            // TestToolItem
            // 
            this.TestToolItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TestToolItem.Image = ((System.Drawing.Image)(resources.GetObject("TestToolItem.Image")));
            this.TestToolItem.Name = "TestToolItem";
            this.TestToolItem.Size = new System.Drawing.Size(36, 22);
            this.TestToolItem.Text = "测试";
            this.TestToolItem.Click += new System.EventHandler(this.TestToolItem_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StateStatusItem,
            this.ProgressStatusItem});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 428);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.Size = new System.Drawing.Size(800, 22);
            this.MainStatusStrip.TabIndex = 3;
            // 
            // StateStatusItem
            // 
            this.StateStatusItem.Name = "StateStatusItem";
            this.StateStatusItem.Size = new System.Drawing.Size(32, 17);
            this.StateStatusItem.Text = "状态";
            // 
            // ProgressStatusItem
            // 
            this.ProgressStatusItem.Name = "ProgressStatusItem";
            this.ProgressStatusItem.Size = new System.Drawing.Size(100, 16);
            // 
            // MainDockPanel
            // 
            this.MainDockPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainDockPanel.Location = new System.Drawing.Point(0, 50);
            this.MainDockPanel.Name = "MainDockPanel";
            this.MainDockPanel.Size = new System.Drawing.Size(800, 378);
            this.MainDockPanel.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.MainDockPanel);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.MainToolStrip);
            this.Controls.Add(this.MainTopMenuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.MainTopMenuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.MainTopMenuStrip.ResumeLayout(false);
            this.MainTopMenuStrip.PerformLayout();
            this.MainToolStrip.ResumeLayout(false);
            this.MainToolStrip.PerformLayout();
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip MainTopMenuStrip;
        private System.Windows.Forms.ToolStrip MainToolStrip;
        private System.Windows.Forms.ToolStripMenuItem StartMenuItem;
        private System.Windows.Forms.ToolStripButton TestToolItem;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripProgressBar ProgressStatusItem;
        private System.Windows.Forms.ToolStripStatusLabel StateStatusItem;
        private WeifenLuo.WinFormsUI.Docking.DockPanel MainDockPanel;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ThemeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LightThemeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BlueThemeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DarkThemeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClassicsThemeMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}