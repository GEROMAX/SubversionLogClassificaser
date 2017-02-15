namespace SubversionLogClassificaser
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnLoadLog = new System.Windows.Forms.Button();
            this.tvLog = new System.Windows.Forms.TreeView();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.btnRequestSetting = new System.Windows.Forms.Button();
            this.btnTargetExtentionSetting = new System.Windows.Forms.Button();
            this.tvRequests = new System.Windows.Forms.TreeView();
            this.btnLinkage = new System.Windows.Forms.Button();
            this.btnUnLink = new System.Windows.Forms.Button();
            this.btnMakeList = new System.Windows.Forms.Button();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.btnLinkageALL = new System.Windows.Forms.Button();
            this.lblSelectedRequestsName = new System.Windows.Forms.Label();
            this.lblSelectedExtentions = new System.Windows.Forms.Label();
            this.btnFilterSetting = new System.Windows.Forms.Button();
            this.lblFilterName = new System.Windows.Forms.Label();
            this.btnUnLikageAll = new System.Windows.Forms.Button();
            this.btnMakeUpdateList = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.tvHide = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // btnLoadLog
            // 
            this.btnLoadLog.Location = new System.Drawing.Point(12, 12);
            this.btnLoadLog.Name = "btnLoadLog";
            this.btnLoadLog.Size = new System.Drawing.Size(125, 23);
            this.btnLoadLog.TabIndex = 0;
            this.btnLoadLog.Text = "ログ読込";
            this.toolTip.SetToolTip(this.btnLoadLog, "クリップボード、またはファイル上のSVNログ情報を読み込みます。");
            this.btnLoadLog.UseVisualStyleBackColor = true;
            this.btnLoadLog.Click += new System.EventHandler(this.btnLoadLog_Click);
            // 
            // tvLog
            // 
            this.tvLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvLog.BackColor = System.Drawing.SystemColors.Window;
            this.tvLog.HideSelection = false;
            this.tvLog.Location = new System.Drawing.Point(12, 41);
            this.tvLog.Name = "tvLog";
            this.tvLog.Size = new System.Drawing.Size(500, 709);
            this.tvLog.TabIndex = 1;
            this.toolTip.SetToolTip(this.tvLog, "拡張子設定、キーワード設定に基づいて読み込んだログ情報をリビジョン単位で表示します。");
            // 
            // btnRequestSetting
            // 
            this.btnRequestSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequestSetting.Location = new System.Drawing.Point(672, 12);
            this.btnRequestSetting.Name = "btnRequestSetting";
            this.btnRequestSetting.Size = new System.Drawing.Size(75, 23);
            this.btnRequestSetting.TabIndex = 2;
            this.btnRequestSetting.Text = "要件設定";
            this.toolTip.SetToolTip(this.btnRequestSetting, "ログ情報の紐付け先要件を設定します。");
            this.btnRequestSetting.UseVisualStyleBackColor = true;
            this.btnRequestSetting.Click += new System.EventHandler(this.btnRequestSetting_Click);
            // 
            // btnTargetExtentionSetting
            // 
            this.btnTargetExtentionSetting.Location = new System.Drawing.Point(143, 12);
            this.btnTargetExtentionSetting.Name = "btnTargetExtentionSetting";
            this.btnTargetExtentionSetting.Size = new System.Drawing.Size(75, 23);
            this.btnTargetExtentionSetting.TabIndex = 3;
            this.btnTargetExtentionSetting.Text = "拡張子設定";
            this.toolTip.SetToolTip(this.btnTargetExtentionSetting, "ログ情報を読み込む際に対象とするファイルの拡張子を設定します。");
            this.btnTargetExtentionSetting.UseVisualStyleBackColor = true;
            this.btnTargetExtentionSetting.Click += new System.EventHandler(this.btnTargetExtentionSetting_Click);
            // 
            // tvRequests
            // 
            this.tvRequests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvRequests.HideSelection = false;
            this.tvRequests.Location = new System.Drawing.Point(672, 41);
            this.tvRequests.Name = "tvRequests";
            this.tvRequests.Size = new System.Drawing.Size(500, 709);
            this.tvRequests.TabIndex = 4;
            this.toolTip.SetToolTip(this.tvRequests, "要件と、それに紐付けられたリビジョンを表示します。");
            // 
            // btnLinkage
            // 
            this.btnLinkage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkage.Location = new System.Drawing.Point(518, 41);
            this.btnLinkage.Name = "btnLinkage";
            this.btnLinkage.Size = new System.Drawing.Size(148, 100);
            this.btnLinkage.TabIndex = 6;
            this.btnLinkage.Text = "リビジョン・要件紐付け→";
            this.toolTip.SetToolTip(this.btnLinkage, "選択したリビジョンと要件を紐付けます。");
            this.btnLinkage.UseVisualStyleBackColor = true;
            this.btnLinkage.Click += new System.EventHandler(this.btnLinkage_Click);
            // 
            // btnUnLink
            // 
            this.btnUnLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnLink.Location = new System.Drawing.Point(518, 594);
            this.btnUnLink.Name = "btnUnLink";
            this.btnUnLink.Size = new System.Drawing.Size(148, 100);
            this.btnUnLink.TabIndex = 7;
            this.btnUnLink.Text = "←紐付け解除";
            this.toolTip.SetToolTip(this.btnUnLink, "選択されている紐付け情報を解除します。");
            this.btnUnLink.UseVisualStyleBackColor = true;
            this.btnUnLink.Click += new System.EventHandler(this.btnUnLink_Click);
            // 
            // btnMakeList
            // 
            this.btnMakeList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeList.Location = new System.Drawing.Point(518, 323);
            this.btnMakeList.Name = "btnMakeList";
            this.btnMakeList.Size = new System.Drawing.Size(148, 100);
            this.btnMakeList.TabIndex = 8;
            this.btnMakeList.Text = "リビジョン・要件\r\n分類データ作成";
            this.toolTip.SetToolTip(this.btnMakeList, "紐付けた情報から一覧を生成します。");
            this.btnMakeList.UseVisualStyleBackColor = true;
            this.btnMakeList.Click += new System.EventHandler(this.btnMakeList_Click);
            // 
            // sfd
            // 
            this.sfd.FileName = "紐付けデータ";
            this.sfd.Filter = "CSV|*.csv";
            // 
            // btnLinkageALL
            // 
            this.btnLinkageALL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkageALL.Location = new System.Drawing.Point(518, 147);
            this.btnLinkageALL.Name = "btnLinkageALL";
            this.btnLinkageALL.Size = new System.Drawing.Size(148, 50);
            this.btnLinkageALL.TabIndex = 9;
            this.btnLinkageALL.Text = "全リビジョン紐付け→";
            this.toolTip.SetToolTip(this.btnLinkageALL, "全リビジョンを選択した要件へ紐付けます。");
            this.btnLinkageALL.UseVisualStyleBackColor = true;
            this.btnLinkageALL.Click += new System.EventHandler(this.btnLinkageAll_Click);
            // 
            // lblSelectedRequestsName
            // 
            this.lblSelectedRequestsName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectedRequestsName.AutoSize = true;
            this.lblSelectedRequestsName.Location = new System.Drawing.Point(753, 17);
            this.lblSelectedRequestsName.Name = "lblSelectedRequestsName";
            this.lblSelectedRequestsName.Size = new System.Drawing.Size(41, 12);
            this.lblSelectedRequestsName.TabIndex = 10;
            this.lblSelectedRequestsName.Text = "未選択";
            // 
            // lblSelectedExtentions
            // 
            this.lblSelectedExtentions.AutoSize = true;
            this.lblSelectedExtentions.Location = new System.Drawing.Point(224, 17);
            this.lblSelectedExtentions.Name = "lblSelectedExtentions";
            this.lblSelectedExtentions.Size = new System.Drawing.Size(41, 12);
            this.lblSelectedExtentions.TabIndex = 11;
            this.lblSelectedExtentions.Text = "未選択";
            // 
            // btnFilterSetting
            // 
            this.btnFilterSetting.Location = new System.Drawing.Point(308, 12);
            this.btnFilterSetting.Name = "btnFilterSetting";
            this.btnFilterSetting.Size = new System.Drawing.Size(90, 23);
            this.btnFilterSetting.TabIndex = 12;
            this.btnFilterSetting.Text = "キーワード設定";
            this.toolTip.SetToolTip(this.btnFilterSetting, "ログ情報を読み込む際の抽出対象キーワードを設定します。(OR条件)");
            this.btnFilterSetting.UseVisualStyleBackColor = true;
            this.btnFilterSetting.Click += new System.EventHandler(this.btnFilterSetting_Click);
            // 
            // lblFilterName
            // 
            this.lblFilterName.AutoSize = true;
            this.lblFilterName.Location = new System.Drawing.Point(404, 17);
            this.lblFilterName.Name = "lblFilterName";
            this.lblFilterName.Size = new System.Drawing.Size(24, 12);
            this.lblFilterName.TabIndex = 13;
            this.lblFilterName.Text = "なし";
            // 
            // btnUnLikageAll
            // 
            this.btnUnLikageAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnLikageAll.Location = new System.Drawing.Point(518, 700);
            this.btnUnLikageAll.Name = "btnUnLikageAll";
            this.btnUnLikageAll.Size = new System.Drawing.Size(148, 50);
            this.btnUnLikageAll.TabIndex = 14;
            this.btnUnLikageAll.Text = "←紐付け全解除";
            this.toolTip.SetToolTip(this.btnUnLikageAll, "全紐付け情報を解除します。");
            this.btnUnLikageAll.UseVisualStyleBackColor = true;
            this.btnUnLikageAll.Click += new System.EventHandler(this.btnUnLikageAll_Click);
            // 
            // btnMakeUpdateList
            // 
            this.btnMakeUpdateList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMakeUpdateList.Location = new System.Drawing.Point(518, 429);
            this.btnMakeUpdateList.Name = "btnMakeUpdateList";
            this.btnMakeUpdateList.Size = new System.Drawing.Size(148, 50);
            this.btnMakeUpdateList.TabIndex = 15;
            this.btnMakeUpdateList.Text = "更新日時一覧作成";
            this.toolTip.SetToolTip(this.btnMakeUpdateList, "読み込んだログ情報から、ファイルの更新日時一覧を生成します。");
            this.btnMakeUpdateList.UseVisualStyleBackColor = true;
            this.btnMakeUpdateList.Click += new System.EventHandler(this.btnMakeUpdateList_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(562, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tvHide
            // 
            this.tvHide.Location = new System.Drawing.Point(391, 41);
            this.tvHide.Name = "tvHide";
            this.tvHide.Size = new System.Drawing.Size(121, 97);
            this.tvHide.TabIndex = 17;
            this.tvHide.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 762);
            this.Controls.Add(this.tvHide);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnMakeUpdateList);
            this.Controls.Add(this.btnUnLikageAll);
            this.Controls.Add(this.lblFilterName);
            this.Controls.Add(this.btnFilterSetting);
            this.Controls.Add(this.lblSelectedExtentions);
            this.Controls.Add(this.lblSelectedRequestsName);
            this.Controls.Add(this.btnLinkageALL);
            this.Controls.Add(this.btnMakeList);
            this.Controls.Add(this.btnUnLink);
            this.Controls.Add(this.btnLinkage);
            this.Controls.Add(this.tvRequests);
            this.Controls.Add(this.btnTargetExtentionSetting);
            this.Controls.Add(this.btnRequestSetting);
            this.Controls.Add(this.tvLog);
            this.Controls.Add(this.btnLoadLog);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SubversionLogClassificaser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadLog;
        private System.Windows.Forms.TreeView tvLog;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button btnRequestSetting;
        private System.Windows.Forms.Button btnTargetExtentionSetting;
        private System.Windows.Forms.TreeView tvRequests;
        private System.Windows.Forms.Button btnLinkage;
        private System.Windows.Forms.Button btnUnLink;
        private System.Windows.Forms.Button btnMakeList;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.Button btnLinkageALL;
        private System.Windows.Forms.Label lblSelectedRequestsName;
        private System.Windows.Forms.Label lblSelectedExtentions;
        private System.Windows.Forms.Button btnFilterSetting;
        private System.Windows.Forms.Label lblFilterName;
        private System.Windows.Forms.Button btnUnLikageAll;
        private System.Windows.Forms.Button btnMakeUpdateList;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView tvHide;
    }
}

