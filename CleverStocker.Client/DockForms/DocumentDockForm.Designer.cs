using WeifenLuo.WinFormsUI.Docking;

namespace CleverStocker.Client.DockForms
{
    partial class DocumentDockForm
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
            this.SuspendLayout();
            // 
            // DocumentDockForm
            // 
            this.DockAreas = DockAreas.Document | DockAreas.Float;
            this.ShowHint = DockState.Document;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "DocumentDockForm";
            this.TabText = "文档";
            this.Text = "文档";
            this.ResumeLayout(false);
        }

        #endregion
    }
}