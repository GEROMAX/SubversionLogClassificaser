using MyCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SubversionLogClassificaser
{
    public partial class SLCSettingForm : SettingFormBase
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public SLCSettingForm()
        {
            InitializeComponent();
        }

        #region プロパティ

        /// <summary>
        /// 要件名リスト
        /// </summary>
        private List<Settings> RequestNames { get; set; }

        /// <summary>
        /// 選択されている要件名リストを取得します
        /// </summary>
        public Settings SelectedRequestNames
        {
            get
            {
                return this.RequestNames.Find(match => match.IsSelected);
            }
        }

        /// <summary>
        /// 対象拡張子リスト
        /// </summary>
        private List<Settings> TargetExtensions { get; set; }

        /// <summary>
        /// 選択されている拡張子リストを取得します
        /// </summary>
        public Settings SelectedTargetExtensions
        {
            get
            {
                return this.TargetExtensions.Find(match => match.IsSelected);
            }
        }

        /// <summary>
        /// フィルタリスト
        /// </summary>
        private List<Settings> CommentFilters { get; set; }

        /// <summary>
        /// 選択されているフィルタを取得します
        /// </summary>
        public Settings SelectedCommentFilter
        {
            get
            {
                return this.CommentFilters.Find(match => match.IsSelected);
            }
        }

        #endregion

        #region メソッド

        /// <summary>
        /// 設定読込
        /// </summary>
        protected override void LoadSettings()
        {
            this.RequestNames = this.LoadSettingFromFile("要件名設定");
            this.TargetExtensions = this.LoadSettingFromFile("対象拡張子設定");
            this.CommentFilters = this.LoadSettingFromFile("フィルタ設定");
        }

        /// <summary>
        /// 要件名の設定
        /// </summary>
        /// <returns></returns>
        public DialogResult SettingRequestNames()
        {
            this.Text = "要件名設定";
            this.ActiveSettings = this.RequestNames;
            return this.StartSetting();
        }

        /// <summary>
        /// 対象拡張子の設定
        /// </summary>
        /// <returns></returns>
        public DialogResult SettingTargetExtensions()
        {
            this.Text = "対象拡張子設定";
            this.ActiveSettings = this.TargetExtensions;
            return this.StartSetting();
        }

        /// <summary>
        /// フィルタの設定
        /// </summary>
        /// <returns></returns>
        public DialogResult SettingCommentFilters()
        {
            this.Text = "フィルタ設定";
            this.ActiveSettings = this.CommentFilters;
            return this.StartSetting();
        }

        #endregion
    }
}
