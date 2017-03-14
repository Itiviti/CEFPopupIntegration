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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XForm));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.lblBrokerCaption = new System.Windows.Forms.Label();
            this.lblBroker = new System.Windows.Forms.Label();
            this.btnSubscribeOrder = new System.Windows.Forms.Button();
            this.btnChart2 = new System.Windows.Forms.Button();
            this.btnChart1 = new System.Windows.Forms.Button();
            this.lblOrderCaption = new System.Windows.Forms.Label();
            this.lblOrder = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
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
            this.pnlButtons.Controls.Add(this.lblOrder);
            this.pnlButtons.Controls.Add(this.lblOrderCaption);
            this.pnlButtons.Controls.Add(this.lblBrokerCaption);
            this.pnlButtons.Controls.Add(this.lblBroker);
            this.pnlButtons.Controls.Add(this.btnSubscribeOrder);
            this.pnlButtons.Controls.Add(this.btnChart2);
            this.pnlButtons.Controls.Add(this.btnChart1);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 443);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(730, 256);
            this.pnlButtons.TabIndex = 0;
            // 
            // lblBrokerCaption
            // 
            this.lblBrokerCaption.AutoSize = true;
            this.lblBrokerCaption.Location = new System.Drawing.Point(12, 122);
            this.lblBrokerCaption.Name = "lblBrokerCaption";
            this.lblBrokerCaption.Size = new System.Drawing.Size(44, 13);
            this.lblBrokerCaption.TabIndex = 4;
            this.lblBrokerCaption.Text = "Broker :";
            // 
            // lblBroker
            // 
            this.lblBroker.AutoSize = true;
            this.lblBroker.Location = new System.Drawing.Point(62, 122);
            this.lblBroker.Name = "lblBroker";
            this.lblBroker.Size = new System.Drawing.Size(46, 13);
            this.lblBroker.TabIndex = 3;
            this.lblBroker.Text = "brokerId";
            // 
            // btnSubscribeOrder
            // 
            this.btnSubscribeOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSubscribeOrder.Location = new System.Drawing.Point(3, 40);
            this.btnSubscribeOrder.Name = "btnSubscribeOrder";
            this.btnSubscribeOrder.Size = new System.Drawing.Size(724, 31);
            this.btnSubscribeOrder.TabIndex = 2;
            this.btnSubscribeOrder.Text = "SubscribeToOrder";
            this.btnSubscribeOrder.UseVisualStyleBackColor = true;
            this.btnSubscribeOrder.Click += new System.EventHandler(this.btnSubscribeOrder_Click);
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
            // lblOrderCaption
            // 
            this.lblOrderCaption.AutoSize = true;
            this.lblOrderCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderCaption.Location = new System.Drawing.Point(12, 95);
            this.lblOrderCaption.Name = "lblOrderCaption";
            this.lblOrderCaption.Size = new System.Drawing.Size(51, 18);
            this.lblOrderCaption.TabIndex = 5;
            this.lblOrderCaption.Text = "Order";
            // 
            // lblOrder
            // 
            this.lblOrder.AutoSize = true;
            this.lblOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrder.Location = new System.Drawing.Point(62, 95);
            this.lblOrder.Name = "lblOrder";
            this.lblOrder.Size = new System.Drawing.Size(51, 18);
            this.lblOrder.TabIndex = 6;
            this.lblOrder.Text = "Order";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
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
        private System.Windows.Forms.Button btnSubscribeOrder;
        private System.Windows.Forms.Label lblBroker;
        private System.Windows.Forms.Label lblBrokerCaption;
        private System.Windows.Forms.Label lblOrder;
        private System.Windows.Forms.Label lblOrderCaption;
        private System.Windows.Forms.Timer timer;
    }
}