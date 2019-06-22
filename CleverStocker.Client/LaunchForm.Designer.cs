namespace CleverStocker.Client
{
    partial class LaunchForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.LaunchLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LaunchLabel
            // 
            this.LaunchLabel.AutoEllipsis = true;
            this.LaunchLabel.BackColor = System.Drawing.Color.Transparent;
            this.LaunchLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LaunchLabel.Font = new System.Drawing.Font("微软雅黑", 10.5F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LaunchLabel.ForeColor = System.Drawing.Color.White;
            this.LaunchLabel.Image = global::CleverStocker.Client.AppResource.BullSmall;
            this.LaunchLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LaunchLabel.Location = new System.Drawing.Point(0, 300);
            this.LaunchLabel.Name = "LaunchLabel";
            this.LaunchLabel.Padding = new System.Windows.Forms.Padding(20);
            this.LaunchLabel.Size = new System.Drawing.Size(640, 60);
            this.LaunchLabel.TabIndex = 0;
            this.LaunchLabel.Text = "正在启动 ...";
            this.LaunchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LaunchLabel.Paint += new System.Windows.Forms.PaintEventHandler(this.LaunchLabel_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 80);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LaunchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::CleverStocker.Client.AppResource.Launcher;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(640, 360);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LaunchLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LaunchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.LaunchForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LaunchLabel;
        private System.Windows.Forms.Button button1;
    }
}

