namespace wsdlGenerate
{
    partial class DetailWindow
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.detial_cancel = new System.Windows.Forms.Button();
            this.detial_ok = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1203, 917);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.detial_cancel);
            this.splitContainer1.Panel2.Controls.Add(this.detial_ok);
            this.splitContainer1.Size = new System.Drawing.Size(1203, 917);
            this.splitContainer1.SplitterDistance = 769;
            this.splitContainer1.TabIndex = 1;
            // 
            // richTextBox
            // 
            this.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox.Location = new System.Drawing.Point(0, 0);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(1203, 769);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            // 
            // detial_cancel
            // 
            this.detial_cancel.Location = new System.Drawing.Point(749, 40);
            this.detial_cancel.Name = "detial_cancel";
            this.detial_cancel.Size = new System.Drawing.Size(271, 62);
            this.detial_cancel.TabIndex = 1;
            this.detial_cancel.Text = "取消";
            this.detial_cancel.UseVisualStyleBackColor = true;
            this.detial_cancel.Click += new System.EventHandler(this.detial_cancel_Click);
            // 
            // detial_ok
            // 
            this.detial_ok.Location = new System.Drawing.Point(184, 40);
            this.detial_ok.Name = "detial_ok";
            this.detial_ok.Size = new System.Drawing.Size(271, 62);
            this.detial_ok.TabIndex = 0;
            this.detial_ok.Text = "确定";
            this.detial_ok.UseVisualStyleBackColor = true;
            this.detial_ok.Click += new System.EventHandler(this.detial_ok_Click);
            // 
            // DetailWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 917);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "DetailWindow";
            this.Text = "DetialWindow";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Button detial_cancel;
        private System.Windows.Forms.Button detial_ok;

    }
}