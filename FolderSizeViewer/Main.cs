using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FolderSizeViewer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void PopluateFolderSizeInfo(TreeNode node, string folder)
        {
            node.Nodes.Clear();

            string[] subFolders = Directory.GetDirectories(folder);

            List<FolderInfo> fis = new List<FolderInfo>();

            foreach (var sf in subFolders)
            {
                var fi = GetFolderInfo(sf);
                if (fi != null)
                    fis.Add(fi);
            }

            fis = fis.OrderByDescending(f => f.Size).ToList();

            foreach (var fi in fis)
            {
                node.Nodes.Add(fi.FullPath, fi.Display);
            }

            node.ExpandAll();
        }

        #region event handler

        private void btnRun_Click(object sender, EventArgs e)
        {
            var rootFolder = this.txtRootFolder.Text.Trim();
            if(!Directory.Exists(rootFolder))
                return;

            var di = new DirectoryInfo(rootFolder);

            this.tvFolders.Nodes.Clear();
            this.tvFolders.Nodes.Add(rootFolder, di.Name);

            PopluateFolderSizeInfo(this.tvFolders.TopNode, rootFolder);
        }

        private void mOpenInExplorer_Click(object sender, EventArgs e)
        {
            var selectedNode = this.tvFolders.SelectedNode;
            if (selectedNode != null)
                Process.Start(selectedNode.Name);
        }

        private void tvFolders_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            PopluateFolderSizeInfo(e.Node, e.Node.Name);
        }

        private void tvFolders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.tvFolders.SelectedNode = e.Node;
                this.cmsTree.Show(this.tvFolders, e.Location);
            }
        }

        #endregion

        #region Helper Methods
       
        public static string GetSizeString(long bytesCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB

            if (bytesCount == 0)
                return "0" + suf[0];

            long bytes = Math.Abs(bytesCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return Math.Sign(bytesCount) * num + suf[place];
        }

        public FolderInfo GetFolderInfo(string path)
        {
            if (!Directory.Exists(path))
                return null;

            Int64 dirSize = -1;
            try
            {
                Scripting.FileSystemObject fso = new Scripting.FileSystemObject();
                Scripting.Folder folder = fso.GetFolder(path);
                dirSize = (Int64)folder.Size;
            }
            catch (Exception ex)
            {
                Log(path + " : " + ex.Message);
            }

            DirectoryInfo dir = new DirectoryInfo(path);

            return new FolderInfo
            {
                Name = dir.Name,
                FullPath = path,
                Size = dirSize
            };
        }

        
        public void Log(string msg)
        {
            this.txtLog.Text += msg + "\r\n";
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        public class FolderInfo
        {
            public string Name { get; set; }
            public string FullPath { get; set; }
            public long Size { get; set; } = 0;
            public string SizeDisplay => GetSizeString(this.Size);
            //public string Display => $"{this.Name,-10} - {this.SizeDisplay,5}";

            public string Display => $"{this.Name} ( {this.SizeDisplay} )";
        }
        #endregion

    }
}
