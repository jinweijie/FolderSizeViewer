using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FolderSizeViewer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            var rootFolder = this.txtRootFolder.Text.Trim();
            if(!Directory.Exists(rootFolder))
                return;

            var di = new DirectoryInfo(rootFolder);

            this.tvFolders.Nodes.Add(rootFolder, di.Name);

            Process(this.tvFolders.TopNode, rootFolder);
        }


        private void tvFolders_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Process(e.Node, e.Node.Name);
        }
        private void tvFolders_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        }

        private void Process(TreeNode node, string folder)
        {
            node.Nodes.Clear();

            string[] subFolders = Directory.GetDirectories(folder);//new string[1]{"c:\\windows"};

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
                Log(path + " + " + ex.Message);
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
