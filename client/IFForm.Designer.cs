using System.Windows.Forms;

namespace CefSharp.WinForms.Example.Minimal
{
    partial class IFForm : Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IFForm));
            this.pnlWebBrowser = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlWebBrowser
            // 
            this.pnlWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWebBrowser.Location = new System.Drawing.Point(0, 0);
            this.pnlWebBrowser.Name = "pnlWebBrowser";
            this.pnlWebBrowser.Size = new System.Drawing.Size(730, 699);
            this.pnlWebBrowser.TabIndex = 0;
            // 
            // IFForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 699);
            this.Controls.Add(this.pnlWebBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IFForm";
            this.Text = "IFForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlWebBrowser;
    }
}