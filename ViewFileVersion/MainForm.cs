using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ViewFileVersion
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            const string linkText = "File Version";

            var startTextPos = informationLabel.Text.IndexOf(linkText);

            informationLabel.Links.Add(startTextPos, linkText.Length, "http://msdn.microsoft.com/en-us/library/ms646981(VS.85).aspx");
        }

        #region AboutForm handling

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern bool InsertMenu(IntPtr hMenu, int wPosition, int wFlags, int wIDNewItem, string lpNewItem);

        [DllImport("user32.dll")]
        private static extern int GetMenuItemCount(IntPtr hMenu);

        public const int WM_SYSCOMMAND = 0x112;
        public const int MF_SEPARATOR = 0x800;
        public const int MF_BYPOSITION = 0x400;
        public const int MF_STRING = 0x0;
        public const int IDM_ABOUT = 1000;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            var systemMenu = GetSystemMenu(Handle, false);
            var baseMenuItemPosition = GetMenuItemCount(systemMenu) - 2;

            InsertMenu(systemMenu, baseMenuItemPosition + 0, MF_BYPOSITION | MF_SEPARATOR, 0, string.Empty);
            InsertMenu(systemMenu, baseMenuItemPosition + 1, MF_BYPOSITION | MF_STRING, IDM_ABOUT, "About");
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                switch (m.WParam.ToInt32())
                {
                    case IDM_ABOUT:
                        ShowAboutForm();
                        return;
                }
            }

            base.WndProc(ref m);
        }

        private void ShowAboutForm()
        {
            using (var aboutForm = new AboutForm())
            {
                aboutForm.ShowDialog(this);
            }
        }

        #endregion

        private void informationLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (Process.Start(e.Link.LinkData.ToString()))
            {
                e.Link.Visited = true;
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            var data = e.Data;

            if (data.GetDataPresent(DataFormats.FileDrop, true))
            {
                e.Effect = DragDropEffects.Copy;
            }

            if (data.GetDataPresent(DataFormats.Text, true))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (files == null)
                {
                    var text = (string)e.Data.GetData(DataFormats.Text);
                    if (string.IsNullOrEmpty(text))
                        return;
                    files = text.Split('\n');
                }

                if (files.Length == 0)
                    return;

                // bring this form to the top.
                Activate();

                DisplayFileVersion(files);
            }
            catch (Exception ex)
            {
                Trace.WriteLine(string.Format("Error in DragDrop method: {0}", ex.Message));
                // NB: Do not show a MessageBox here; explorer is waiting.
            }
        }

        private void DisplayFileVersion(IEnumerable<string> fileNames)
        {
            treeView.Nodes.Clear();

            foreach (var fileName in fileNames)
                DisplayFileVersion(fileName);
        }

        private void DisplayFileVersion(string fileName)
        {
            Trace.WriteLine(string.Format("DisplayFileVersion {0}", fileName));

            // TODO do this in background... using some kind of manager.

            if (Directory.Exists(fileName))
            {
                // TODO recurse the directory looking for files, and display them all.
            }
            else
            {
                var versionInfo = FileVersionInfo.GetVersionInfo(fileName);

                DisplayFileVersion(versionInfo);
            }
        }

        private void DisplayFileVersion(FileVersionInfo versionInfo)
        {
            var rootNode = new TreeNode(Path.GetFileName(versionInfo.FileName)) {ToolTipText = versionInfo.FileName};

            AddNode(rootNode, "OriginalFilename", versionInfo.OriginalFilename);
            AddNode(rootNode, "InternalName", versionInfo.InternalName);
            AddNode(rootNode, "FileDescription", versionInfo.FileDescription);
            AddNode(rootNode, "ProductName", versionInfo.ProductName);
            AddNode(rootNode, "ProductVersion", versionInfo.ProductVersion);
            AddNode(rootNode, "ProductMajorPart", versionInfo.ProductMajorPart);
            AddNode(rootNode, "ProductMinorPart", versionInfo.ProductMinorPart);
            AddNode(rootNode, "ProductBuildPart", versionInfo.ProductBuildPart);
            AddNode(rootNode, "ProductPrivatePart", versionInfo.ProductPrivatePart);
            AddNode(rootNode, "FileMajorPart", versionInfo.FileMajorPart);
            AddNode(rootNode, "FileMinorPart", versionInfo.FileMinorPart);
            AddNode(rootNode, "FileBuildPart", versionInfo.FileBuildPart);
            AddNode(rootNode, "FilePrivatePart", versionInfo.FilePrivatePart);
            AddNode(rootNode, "IsDebug", versionInfo.IsDebug);
            AddNode(rootNode, "IsPatched", versionInfo.IsPatched);
            AddNode(rootNode, "IsPreRelease", versionInfo.IsPreRelease);
            AddNode(rootNode, "IsPrivateBuild", versionInfo.IsPrivateBuild);
            AddNode(rootNode, "IsSpecialBuild", versionInfo.IsSpecialBuild);
            AddNode(rootNode, "PrivateBuild", versionInfo.PrivateBuild);
            AddNode(rootNode, "SpecialBuild", versionInfo.SpecialBuild);
            AddNode(rootNode, "CompanyName", versionInfo.CompanyName);
            AddNode(rootNode, "LegalCopyright", versionInfo.LegalCopyright);
            AddNode(rootNode, "LegalTrademarks", versionInfo.LegalTrademarks);
            AddNode(rootNode, "Comments", versionInfo.Comments);
            AddNode(rootNode, "Language", versionInfo.Language);

            rootNode.ExpandAll();

            treeView.Nodes.Add(rootNode);
        }

        private static void AddNode(TreeNode rootNode, string name, object value)
        {
            if (value == null)
                return;

            var v = value.ToString();

            if (string.IsNullOrWhiteSpace(v))
                return;

            rootNode.Nodes.Add(string.Format("{0}: {1}", name, v));
        }
    }
}
