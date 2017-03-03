namespace CefSharp.WinForms.Example.Minimal
{
    partial class XForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.txtChart2 = new System.Windows.Forms.TextBox();
            this.txtChart1 = new System.Windows.Forms.TextBox();
            this.btnChart2 = new System.Windows.Forms.Button();
            this.btnChart1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Size = new System.Drawing.Size(730, 699);
            this.splitContainer.SplitterDistance = 362;
            this.splitContainer.TabIndex = 2;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.txtChart2);
            this.pnlButtons.Controls.Add(this.txtChart1);
            this.pnlButtons.Controls.Add(this.btnChart2);
            this.pnlButtons.Controls.Add(this.btnChart1);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 443);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(730, 256);
            this.pnlButtons.TabIndex = 0;
            // 
            // txtChart2
            // 
            this.txtChart2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChart2.Location = new System.Drawing.Point(371, 41);
            this.txtChart2.Multiline = true;
            this.txtChart2.Name = "txtChart2";
            this.txtChart2.Size = new System.Drawing.Size(356, 203);
            this.txtChart2.TabIndex = 3;
            this.txtChart2.Text = "var windowId = windowManager.openWindow(\'container2\');         $(\'#open-window-li" +
    "st\').append(\'<li class=\"window-item\" data-window=\"\' + windowId + \'\">Close Window" +
    " \' + windowId + \'</li>\');";
            // 
            // txtChart1
            // 
            this.txtChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtChart1.Location = new System.Drawing.Point(3, 41);
            this.txtChart1.Multiline = true;
            this.txtChart1.Name = "txtChart1";
            this.txtChart1.Size = new System.Drawing.Size(356, 203);
            this.txtChart1.TabIndex = 2;
            this.txtChart1.Text = "var windowId = windowManager.openWindow(\'container1\');\r\n        $(\'#open-window-l" +
    "ist\').append(\'<li class=\"window-item\" data-window=\"\' + windowId + \'\">Close Windo" +
    "w \' + windowId + \'</li>\');";
            // 
            // btnChart2
            // 
            this.btnChart2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChart2.Location = new System.Drawing.Point(368, 3);
            this.btnChart2.Name = "btnChart2";
            this.btnChart2.Size = new System.Drawing.Size(359, 31);
            this.btnChart2.TabIndex = 1;
            this.btnChart2.Text = "Open Chart 2";
            this.btnChart2.UseVisualStyleBackColor = true;
            this.btnChart2.Click += new System.EventHandler(this.btnChart2_Click);
            // 
            // btnChart1
            // 
            this.btnChart1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChart1.Location = new System.Drawing.Point(3, 3);
            this.btnChart1.Name = "btnChart1";
            this.btnChart1.Size = new System.Drawing.Size(359, 31);
            this.btnChart1.TabIndex = 0;
            this.btnChart1.Text = "Open Chart 1";
            this.btnChart1.UseVisualStyleBackColor = true;
            this.btnChart1.Click += new System.EventHandler(this.btnChart1_Click);
            // 
            // XForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 699);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.splitContainer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "XForm";
            this.Text = "Xilix";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.pnlButtons.ResumeLayout(false);
            this.pnlButtons.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnChart2;
        private System.Windows.Forms.Button btnChart1;
        private System.Windows.Forms.TextBox txtChart2;
        private System.Windows.Forms.TextBox txtChart1;
    }
}