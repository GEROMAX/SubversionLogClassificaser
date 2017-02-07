using MyCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubversionLogClassificaser
{
    public partial class TreeSelectForm : Form
    {
        public TreeSelectForm()
        {
            InitializeComponent();
        }

        private void TreeSelectForm_Load(object sender, EventArgs e)
        {
            //ツリーに見やすい色設定
            this.tvDirectory.BackColor = Color.Gray;
            this.tvDirectory.ForeColor = Color.Lime;
            this.tvDirectory.LineColor = Color.White;
        }

        public string TargetTree
        {
            get
            {
                return this.tvDirectory.SelectedNode == null ? string.Empty : this.tvDirectory.SelectedNode.FullPath;
            }
        }

        public DialogResult SelectTargetTree(SubversionLogs logs)
        {
            foreach (SubversionLogInfo log in logs)
            {
                foreach (ModifyFileInfo mfi in log.ModifyFiles)
                {
                    this.AddNode(this.tvDirectory.Nodes, mfi.FilePath.Split("\\".ToCharArray(), StringSplitOptions.RemoveEmptyEntries));
                }
            }
            this.tvDirectory.ExpandAll();

            return this.ShowDialog();
        }

        private void AddNode(TreeNodeCollection rootNodes, string[] dirs)
        {
            TreeNodeCollection nodes = rootNodes;
            foreach (string dir in dirs)
            {
                //リポジトリ上で外設・内設フォルダ名を変えてしまったことへの対応
                //ダサいが自動処理に支障をきたすため、仕方ない
                string dirName;
                dirName = dir.Equals("050_外部設計書") ? "外部設計書" : dir;
                dirName = dir.Equals("060_内部設計書") ? "内部設計書" : dir;

                if (nodes.ContainsKey(dirName))
                {
                    nodes = nodes[dirName].Nodes;
                }
                else
                {
                    nodes = nodes.Add(dirName, dirName).Nodes;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
