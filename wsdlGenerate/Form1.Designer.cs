namespace wsdlGenerate
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeView = new System.Windows.Forms.TreeView();
            this.generateRoot = new System.Windows.Forms.Button();
            this.export = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.insert = new System.Windows.Forms.ToolStripMenuItem();
            this.delete = new System.Windows.Forms.ToolStripMenuItem();
            this.addInputCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.addOutputCollection = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.addQuiryStandardAttribute = new System.Windows.Forms.ToolStripMenuItem();
            this.addImportStandardAttribute = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.treeView);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.generateRoot);
            this.splitContainer.Panel2.Controls.Add(this.export);
            this.splitContainer.Size = new System.Drawing.Size(2041, 1210);
            this.splitContainer.SplitterDistance = 1026;
            this.splitContainer.TabIndex = 0;
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView.Location = new System.Drawing.Point(0, 0);
            this.treeView.Name = "treeView";
            this.treeView.Size = new System.Drawing.Size(2041, 1026);
            this.treeView.TabIndex = 0;
            this.treeView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView_MouseDown);
            // 
            // generateRoot
            // 
            this.generateRoot.Location = new System.Drawing.Point(105, 20);
            this.generateRoot.Name = "generateRoot";
            this.generateRoot.Size = new System.Drawing.Size(293, 70);
            this.generateRoot.TabIndex = 2;
            this.generateRoot.Text = "生成请求及响应节点";
            this.generateRoot.UseVisualStyleBackColor = true;
            this.generateRoot.Click += new System.EventHandler(this.generateRoot_Click);
            // 
            // export
            // 
            this.export.Location = new System.Drawing.Point(1159, 20);
            this.export.Name = "export";
            this.export.Size = new System.Drawing.Size(298, 70);
            this.export.TabIndex = 1;
            this.export.Text = "导出";
            this.export.UseVisualStyleBackColor = true;
            this.export.Click += new System.EventHandler(this.export_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insert,
            this.delete,
            this.addInputCollection,
            this.addOutputCollection,
            this.addQuiryStandardAttribute,
            this.addImportStandardAttribute});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(338, 306);
            // 
            // insert
            // 
            this.insert.Enabled = false;
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(337, 42);
            this.insert.Text = "插入";
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // delete
            // 
            this.delete.Enabled = false;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(337, 42);
            this.delete.Text = "删除";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // addInputCollection
            // 
            this.addInputCollection.Name = "addInputCollection";
            this.addInputCollection.Size = new System.Drawing.Size(337, 42);
            this.addInputCollection.Text = "添加输入集合";
            this.addInputCollection.Visible = false;
            this.addInputCollection.Click += new System.EventHandler(this.addInputCollection_Click);
            // 
            // addOutputCollection
            // 
            this.addOutputCollection.Name = "addOutputCollection";
            this.addOutputCollection.Size = new System.Drawing.Size(337, 42);
            this.addOutputCollection.Text = "添加输出集合";
            this.addOutputCollection.Visible = false;
            this.addOutputCollection.Click += new System.EventHandler(this.addOutputCollection_Click);
            // 
            // addQuiryStandardAttribute
            // 
            this.addQuiryStandardAttribute.Name = "addQuiryStandardAttribute";
            this.addQuiryStandardAttribute.Size = new System.Drawing.Size(337, 42);
            this.addQuiryStandardAttribute.Text = "添加标准查询参数";
            this.addQuiryStandardAttribute.Click += new System.EventHandler(this.addQuiryStandardAttribute_Click);
            // 
            // addImportStandardAttribute
            // 
            this.addImportStandardAttribute.Name = "addImportStandardAttribute";
            this.addImportStandardAttribute.Size = new System.Drawing.Size(337, 42);
            this.addImportStandardAttribute.Text = "添加标准导入参数";
            this.addImportStandardAttribute.Click += new System.EventHandler(this.addImportStandardAttribute_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2041, 1210);
            this.Controls.Add(this.splitContainer);
            this.Name = "Form1";
            this.Text = "wsdl_generate";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem insert;
        private System.Windows.Forms.ToolStripMenuItem delete;
        private System.Windows.Forms.Button export;
        private System.Windows.Forms.Button generateRoot;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripMenuItem addInputCollection;
        private System.Windows.Forms.ToolStripMenuItem addOutputCollection;
        private System.Windows.Forms.ToolStripMenuItem addQuiryStandardAttribute;
        private System.Windows.Forms.ToolStripMenuItem addImportStandardAttribute;
    }
}

