using MyCommon;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubversionLogClassificaser
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #region プロパティ

        /// <summary>
        /// SVNログ情報を取得または設定します
        /// </summary>
        private SubversionLogs Logs { get; set; }

        /// <summary>
        /// 各種設定画面
        /// </summary>
        private SLCSettingForm settingForm { get; set; }

        #endregion

        #region イベント

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.settingForm = new SLCSettingForm();
            if (null != this.settingForm.SelectedTargetExtensions)
            {
                this.lblSelectedExtentions.Text = this.settingForm.SelectedTargetExtensions.Name;
            }
            if (null != this.settingForm.SelectedFilteringKeyWord)
            {
                this.lblFilterName.Text = this.settingForm.SelectedFilteringKeyWord.Name;
            }

            //ツリーに見やすい色設定
            this.tvLog.BackColor = Color.Black;
            this.tvLog.ForeColor = Color.LimeGreen;
            this.tvLog.LineColor = Color.White;
            this.tvRequests.BackColor = Color.Black;
            this.tvRequests.ForeColor = Color.LimeGreen;
            this.tvRequests.LineColor = Color.White;
        }

        /// <summary>
        /// SVNログ読込
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadLog_Click(object sender, EventArgs e)
        {
            if (null == this.settingForm.SelectedTargetExtensions)
            {
                MessageBox.Show("ログから抽出するファイル拡張子を設定してください");
                return;
            }

            //クリップボードorファイルからの読込
            string data = (string)Clipboard.GetData("Text");
            if (!SubversionLogs.IsSubversionLogData(data))
            {
                if (!DialogResult.OK.Equals(ofd.ShowDialog()))
                {
                    return;
                }

                data = File.ReadAllText(ofd.FileName, Encoding.Default);
                if (!SubversionLogs.IsSubversionLogData(data))
                {
                    MessageBox.Show("ファイルはSVNのログではありません");
                    return;
                }
            }

            //ログ解析と表示
            this.tvLog.Nodes.Clear();
            this.Logs = SubversionLogs.CreateSubversionLogs(data,
                                                            this.settingForm.SelectedTargetExtensions.Values,
                                                            this.settingForm.SelectedFilteringKeyWord == null ? new List<string>() : this.settingForm.SelectedFilteringKeyWord.Values);
            this.Logs.ForEach(log => this.AddLogForTreeView(this.tvLog, log));
            this.tvLog.ExpandAll();
            this.TopLogShow();

            if (this.tvLog.Nodes.Count <= 0)
            {
                MessageBox.Show("対象ログなし");
            }
        }

        /// <summary>
        /// 拡張子設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTargetExtentionSetting_Click(object sender, EventArgs e)
        {
            if (!DialogResult.OK.Equals(this.settingForm.SettingTargetExtensions()))
            {
                return;
            }

            this.lblSelectedExtentions.Text = this.settingForm.SelectedTargetExtensions.Name;
        }

        /// <summary>
        /// キーワード設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKeyWordSetting_Click(object sender, EventArgs e)
        {
            if (!DialogResult.OK.Equals(this.settingForm.SettingFilteringKeyWords()))
            {
                return;
            }

            this.lblFilterName.Text = this.settingForm.SelectedFilteringKeyWord.Name;
        }

        /// <summary>
        /// 要件設定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRequestSetting_Click(object sender, EventArgs e)
        {
            if (!DialogResult.OK.Equals(this.settingForm.SettingRequestNames()))
            {
                return;
            }

            this.lblSelectedRequestsName.Text = this.settingForm.SelectedRequestNames.Name;
            this.tvRequests.Nodes.Clear();
            foreach (string requestName in this.settingForm.SelectedRequestNames.Values)
            {
                TreeNode reqParent = this.tvRequests.Nodes.Add(requestName, requestName);
            }
            this.tvRequests.ExpandAll();
        }

        /// <summary>
        /// 紐付け
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLinkage_Click(object sender, EventArgs e)
        {
            if (null == this.tvLog.SelectedNode)
            {
                return;
            }
            if (null == this.tvRequests.SelectedNode)
            {
                return;
            }

            TreeNode revParent = this.tvLog.SelectedNode;
            while (revParent.Level > 0)
            {
                revParent = revParent.Parent;
            }
            TreeNode reqParent = this.tvRequests.SelectedNode;
            while (reqParent.Level > 0)
            {
                reqParent = reqParent.Parent;
            }
            reqParent.Nodes.Add((TreeNode)revParent.Clone());
            revParent.Collapse(true);
            this.tvLog.Nodes.Remove(revParent);

            this.Logs.Find(log => log.Revision.Text.Equals(revParent.Text)).Conbined = true;
        }

        /// <summary>
        /// 全紐付け
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLinkageAll_Click(object sender, EventArgs e)
        {
            if (null == this.tvRequests.SelectedNode)
            {
                return;
            }

            TreeNode reqParent = this.tvRequests.SelectedNode;
            while (reqParent.Level > 0)
            {
                reqParent = reqParent.Parent;
            }
            var lstConbine = new List<string>();
            foreach (TreeNode node in this.tvLog.Nodes)
            {
                reqParent.Nodes.Add((TreeNode)node.Clone());
                lstConbine.Add(node.Text);
            }
            reqParent.ExpandAll();
            this.tvLog.Nodes.Clear();

            this.Logs.FindAll(log => lstConbine.Contains(log.Revision.Text)).ForEach(matchLog => matchLog.Conbined = true);
            //this.Logs.ForEach(log => log.Conbined = true);
        }

        /// <summary>
        /// 紐付け解除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnLink_Click(object sender, EventArgs e)
        {
            if (null == this.tvRequests.SelectedNode || this.tvRequests.SelectedNode.Level <= 0)
            {
                return;
            }

            TreeNode reqParent = this.tvRequests.SelectedNode;
            while (reqParent.Level > 1)
            {
                reqParent = reqParent.Parent;
            }
            this.tvLog.Nodes.Add((TreeNode)reqParent.Clone());
            this.tvRequests.Nodes.Remove(reqParent);

            this.Logs.Find(log => log.Revision.Text.Equals(reqParent.Text)).Conbined = false;
        }

        /// <summary>
        /// 紐付け全解除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnLikageAll_Click(object sender, EventArgs e)
        {
            if (null == this.tvRequests.SelectedNode)
            {
                return;
            }

            TreeNode reqParent = this.tvRequests.SelectedNode;
            while (reqParent.Level > 0)
            {
                reqParent = reqParent.Parent;
            }
            foreach (TreeNode node in reqParent.Nodes)
            {
                this.tvLog.Nodes.Add((TreeNode)node.Clone());
            }
            reqParent.Nodes.Clear();

            this.Logs.ForEach(log => log.Conbined = false);
        }

        /// <summary>
        /// ログ・要件分類データ作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMakeList_Click(object sender, EventArgs e)
        {
            sfd.FileName = "リビジョン・要件分類データ";
            if (!DialogResult.OK.Equals(sfd.ShowDialog()))
            {
                return;
            }

            LinkageInfos linkages = LinkageInfos.CreateAllLinkageInformation(this.Logs, this.settingForm.SelectedRequestNames.Values);
            foreach (string requestName in linkages.ReqestNames)
            {
                TreeNode req = this.tvRequests.Nodes.Find(requestName, false)[0];
                foreach (TreeNode rev in req.Nodes)
                {
                    int revision = Convert.ToInt32(rev.Tag);
                    SubversionLogInfo log = this.Logs.Find(match => revision.Equals(match.Revision.Value));
                    foreach (ModifyFileInfo mfi in log.ModifyFiles)
                    {
                        //既に紐付け済みのコミット日時のほうが新しい場合はスキップ
                        var li = linkages.Find(match => match.ModuleName.Equals(mfi.ModuleName));
                        if (li.RequestSupport[mfi.FileName][requestName].CommitDate.HasValue &&
                            li.RequestSupport[mfi.FileName][requestName].CommitDate.Value > log.CommitDate.Value.Value)
                        {
                            continue;
                        }

                        //現時点でコミット日時とその出力情報を設定
                        string val = string.Concat(log.Revision.Text, "\r\n", log.CommitDate.Value.Value.ToString("yyyy/MM/dd HH:mm:ss"), "\r\n", log.Comment);
                        li.RequestSupport[mfi.FileName][requestName].CommitDate = log.CommitDate.Value;
                        li.RequestSupport[mfi.FileName][requestName].Value = val;
                    }
                }
            }
            linkages.WriteSupportData(sfd.FileName);

            MessageBox.Show("出力しました");
        }

        /// <summary>
        /// 更新日時一覧作成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMakeUpdateList_Click(object sender, EventArgs e)
        {
            if (null == this.Logs)
            {
                return;
            }

            TreeSelectForm form = new TreeSelectForm();
            if (!DialogResult.OK.Equals(form.SelectTargetTree(this.Logs)))
            {
                return;
            }
            sfd.FileName = "ファイル更新日時一覧";
            if (!DialogResult.OK.Equals(sfd.ShowDialog()))
            {
                return;
            }

            Dictionary<string, DateTime> dic = new Dictionary<string, DateTime>();
            foreach (SubversionLogInfo log in this.Logs)
            {
                foreach (ModifyFileInfo mfi in log.ModifyFiles)
                {
                    if (!mfi.FilePath.Contains(form.TargetTree))
                    {
                        continue;
                    }

                    if (!dic.ContainsKey(mfi.FilePath))
                    {
                        dic.Add(mfi.FilePath, log.CommitDate.Value.Value);
                    }
                    else if (dic[mfi.FilePath] < log.CommitDate.Value.Value)
                    {
                        dic[mfi.FilePath] = log.CommitDate.Value.Value;
                    }
                }
            }

            CSVBuilder csv = new CSVBuilder();
            csv.AppendStart().Append(Path.GetFileName(form.TargetTree)).Append("ファイル").Append("最終更新日時").AppendEnd();
            foreach (KeyValuePair<string, DateTime> kvp in dic.OrderBy(data => data.Key))
            {
                csv.AppendStart();
                csv.Append(Path.GetDirectoryName(kvp.Key));
                csv.Append(Path.GetFileName(kvp.Key));
                csv.Append(kvp.Value.ToString("yyyy/MM/dd HH:mm:ss"));
                csv.AppendEnd();
            }
            File.WriteAllText(sfd.FileName, csv.ToString(), Encoding.Default);

            MessageBox.Show("出力しました");
        }

        /// <summary>
        /// 検索ワードKeyDown
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMoreFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter.Equals(e.KeyCode))
            {
                this.btnMoreFiltering.PerformClick();
            }
        }

        /// <summary>
        /// 絞込み
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMoreFiltering_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtMoreFilter.Text))
            {
                return;
            }
            var filters = this.txtMoreFilter.Text.Replace("　", " ").Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            //ログ解析と表示
            this.tvLog.Nodes.Clear();
            var filteringLogs = this.Logs.FindAll(log => !log.Conbined & log.ExistsWords(filters));
            filteringLogs.ForEach(log => this.AddLogForTreeView(this.tvLog, log));
            this.tvLog.ExpandAll();
            this.TopLogShow();

            if (this.tvLog.Nodes.Count <= 0)
            {
                MessageBox.Show("見つかりません。");
            }
        }

        /// <summary>
        /// 絞込みクリア
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearMoreFilter_Click(object sender, EventArgs e)
        {
            //ログ解析と表示
            this.txtMoreFilter.Clear();
            this.tvLog.Nodes.Clear();
            var unbinedLogs = this.Logs.FindAll(log => !log.Conbined);
            unbinedLogs.ForEach(log => this.AddLogForTreeView(this.tvLog, log));
            this.tvLog.ExpandAll();
            this.TopLogShow();
        }

        #endregion

        #region メソッド

        private void AddLogForTreeView(TreeView tv, SubversionLogInfo log)
        {
            TreeNode revParent = tv.Nodes.Add(log.Revision.Text);
            revParent.Nodes.Add(log.Comment);
            revParent.Nodes.Add(log.Author.Text);
            revParent.Nodes.Add(log.CommitDate.Text);
            revParent.Tag = log.Revision.Value;
            log.ModifyFiles.ForEach(mfi => revParent.Nodes.Add(mfi.FileName));
        }

        /// <summary>
        /// 先頭ログの表示
        /// </summary>
        private void TopLogShow()
        {
            if (this.tvLog.Nodes.Count > 0)
            {
                this.tvLog.Nodes[0].EnsureVisible();
            }
        }

        #endregion

        #region 紐付け処理クラス

        /// <summary>
        /// モジュール要件紐付け情報リスト
        /// </summary>
        public class LinkageInfos : List<LinkageInfo>
        {
            /// <summary>
            /// 要件名リスト
            /// </summary>
            public List<string> ReqestNames { get; set; }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="requests">要件リスト</param>
            private LinkageInfos(List<string> requests)
            {
                this.ReqestNames = requests;
            }

            /// <summary>
            /// 紐付け情報ベースリスト生成
            /// </summary>
            /// <param name="logs">ログ情報</param>
            /// <param name="requests">要件リスト</param>
            /// <returns></returns>
            internal static LinkageInfos CreateAllLinkageInformation(SubversionLogs logs, List<string> requests)
            {
                LinkageInfos lst = new LinkageInfos(requests);

                foreach (SubversionLogInfo log in logs)
                {
                    foreach (ModifyFileInfo mfi in log.ModifyFiles)
                    {
                        string moduleName = mfi.ModuleName;
                        string fileName = mfi.FileName;

                        LinkageInfo li = lst.Find(match => match.ModuleName.Equals(moduleName));
                        if (null == li)
                        {
                            li = new LinkageInfo(moduleName);
                            lst.Add(li);
                        }
                        if (!li.FileNames.Exists(match => match.Equals(fileName)))
                        {
                            li.FileNames.Add(fileName);
                        }
                    }
                }
                //分類情報格納辞書生成
                lst.ForEach(li => li.CreateRequestSupport(requests));

                //モジュールとファイル名で並べ替え
                lst.Sort((liA, liB) => liA.CompareTo(liB));
                lst.ForEach(li => li.FileNames.Sort());

                return lst;
            }

            /// <summary>
            /// 全モジュール分の要件紐付け情報出力
            /// </summary>
            /// <param name="filePath">出力ファイルパス</param>
            public void WriteSupportData(string filePath)
            {
                CSVBuilder csv = new CSVBuilder();

                //ヘッダ生成
                csv.AppendStart();
                csv.Append("モジュール").Append("ファイル");
                this.ReqestNames.ForEach(requestName => csv.Append(requestName));
                csv.AppendEnd();

                //各モジュールの情報生成
                foreach (LinkageInfo li in this)
                {
                    foreach (string fileName in li.FileNames)
                    {
                        csv.AppendStart();
                        csv.Append(li.ModuleName).Append(fileName);
                        this.ReqestNames.ForEach(requestName => csv.Append(li.RequestSupport[fileName][requestName].Value));
                        csv.AppendEnd();
                    }
                }

                File.WriteAllText(filePath, csv.ToString(), Encoding.Default);
            }
        }

        /// <summary>
        /// 1モジュール分の要件紐付け情報
        /// </summary>
        public class LinkageInfo
        {
            /// <summary>
            /// モジュール名
            /// </summary>
            public string ModuleName { get; set; }

            /// <summary>
            /// ファイル名リスト
            /// </summary>
            public List<string> FileNames { get; set; }

            /// <summary>
            /// [ファイル名][要件名][コミット日時][出力内容]対応状況辞書
            /// </summary>
            public Dictionary<string, Dictionary<string, OutputData>> RequestSupport { get; set; }

            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="moduleName"></param>
            public LinkageInfo(string moduleName)
            {
                this.ModuleName = moduleName;
                this.FileNames = new List<string>();
            }

            /// <summary>
            /// 対応状況辞書生成
            /// </summary>
            public void CreateRequestSupport(List<string> requestNames)
            {
                this.RequestSupport = new Dictionary<string, Dictionary<string, OutputData>>();
                foreach (string fileName in this.FileNames)
                {
                    this.RequestSupport[fileName] = new Dictionary<string, OutputData>();
                    foreach (string requestName in requestNames)
                    {
                        this.RequestSupport[fileName][requestName] = new OutputData(null, string.Empty);
                    }
                }
            }

            /// <summary>
            /// このインスタンスと指定のインスタンスをモジュール名で比較します
            /// </summary>
            /// <param name="li">比較対象</param>
            /// <returns></returns>
            public int CompareTo(LinkageInfo li)
            {
                return this.ModuleName.CompareTo(li.ModuleName);
            }

            public class OutputData
            {
                public DateTime? CommitDate { get; set; }
                public string Value { get; set; }

                public OutputData(DateTime? dtm, string val)
                {
                    this.CommitDate = dtm;
                    this.Value = val;
                }
            }
        }

        #endregion
    }
}
