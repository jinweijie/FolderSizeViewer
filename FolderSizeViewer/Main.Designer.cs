namespace FolderSizeViewer
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tvFolders = new System.Windows.Forms.TreeView();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtRootFolder = new System.Windows.Forms.TextBox();
            this.lRootFolder = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lPrompt = new System.Windows.Forms.Label();
            this.cmsTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mOpenInExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvFolders
            // 
            this.tvFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvFolders.Location = new System.Drawing.Point(13, 60);
            this.tvFolders.Name = "tvFolders";
            this.tvFolders.Size = new System.Drawing.Size(601, 582);
            this.tvFolders.TabIndex = 0;
            this.tvFolders.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFolders_NodeMouseClick);
            this.tvFolders.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFolders_NodeMouseDoubleClick);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(335, 21);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 1;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtRootFolder
            // 
            this.txtRootFolder.Location = new System.Drawing.Point(139, 21);
            this.txtRootFolder.Name = "txtRootFolder";
            this.txtRootFolder.Size = new System.Drawing.Size(190, 22);
            this.txtRootFolder.TabIndex = 2;
            this.txtRootFolder.Text = "C:\\";
            // 
            // lRootFolder
            // 
            this.lRootFolder.AutoSize = true;
            this.lRootFolder.Location = new System.Drawing.Point(12, 24);
            this.lRootFolder.Name = "lRootFolder";
            this.lRootFolder.Size = new System.Drawing.Size(121, 17);
            this.lRootFolder.TabIndex = 3;
            this.lRootFolder.Text = "Folder to analyze:";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(620, 60);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(628, 582);
            this.txtLog.TabIndex = 4;
            // 
            // lPrompt
            // 
            this.lPrompt.AutoSize = true;
            this.lPrompt.Location = new System.Drawing.Point(417, 24);
            this.lPrompt.Name = "lPrompt";
            this.lPrompt.Size = new System.Drawing.Size(281, 17);
            this.lPrompt.TabIndex = 5;
            this.lPrompt.Text = "(Double click nodes to expand sub folders.)";
            // 
            // cmsTree
            // 
            this.cmsTree.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mOpenInExplorer});
            this.cmsTree.Name = "cmsTree";
            this.cmsTree.Size = new System.Drawing.Size(196, 30);
            // 
            // mOpenInExplorer
            // 
            this.mOpenInExplorer.Name = "mOpenInExplorer";
            this.mOpenInExplorer.Size = new System.Drawing.Size(195, 26);
            this.mOpenInExplorer.Text = "Open in Explorer";
            this.mOpenInExplorer.Click += new System.EventHandler(this.mOpenInExplorer_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 654);
            this.Controls.Add(this.lPrompt);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.lRootFolder);
            this.Controls.Add(this.txtRootFolder);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.tvFolders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Folder Size Viewer";
            this.cmsTree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvFolders;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtRootFolder;
        private System.Windows.Forms.Label lRootFolder;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lPrompt;
        private System.Windows.Forms.ContextMenuStrip cmsTree;
        private System.Windows.Forms.ToolStripMenuItem mOpenInExplorer;
    }
}

