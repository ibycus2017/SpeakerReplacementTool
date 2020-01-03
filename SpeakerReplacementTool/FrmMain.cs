using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeakerReplacementTool
{
    public partial class FrmMain : Form
    {
        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント（フォームロード）
        /// <summary>
        /// イベント（フォームロード）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Load(object sender, EventArgs e)
        {
            this.MakeScreen();
        }
        #endregion

        #region イベント（ボタンクリック：ファイル置換）
        /// <summary>
        /// イベント（ボタンクリック：ファイル置換）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFileReplacement_Click(object sender, EventArgs e)
        {
            this.ReplaceFile(false);
            MessageBox.Show("完了しました", this.Text);
        }
        #endregion

        #region イベント（ボタンクリック：プレビュー）
        /// <summary>
        /// イベント（ボタンクリック：プレビュー）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.ReplaceFile(true);
        }
        #endregion

        #region イベント（リンククリック：置換リスト）
        /// <summary>
        /// イベント（リンククリック：置換リスト）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lnkReplacementList_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.ShowDialogFrmReplacementList();
        }
        #endregion

        #region メソッド（画面作成）
        /// <summary>
        /// メソッド（画面作成）
        /// </summary>
        private void MakeScreen()
        {
            this.txtDelimiter.Text = "：";
        }
        #endregion

        #region メソッド（ファイル置換）
        /// <summary>
        /// メソッド（ファイル置換）
        /// </summary>
        private void ReplaceFile(in bool IsPreview )
        {
            var replacementList = new ReplacementListReader().ReadList();
            if (replacementList.Count == 0) return;

            var selectedFileName = this.FetchSelectedFileName();
            if (selectedFileName == System.String.Empty) return;

            var encoding = new EncodingFetcher().FetchEncoding(System.IO.File.ReadAllBytes(selectedFileName));
            if (encoding == null) return;
            this.lblEncoding.Text = encoding.EncodingName;

            var readLines = this.ReadFileAllLines(selectedFileName, encoding);
            var replacedLines = this.ReplaceFileAllLines(txtDelimiter.Text, (IReadOnlyList<string>)readLines, replacementList);
            this.dgvOld.Rows.Clear();
            foreach (var readLine in readLines) {
                this.dgvOld.Rows.Add();
                this.dgvOld.Rows[dgvOld.Rows.Count - 1].Cells[0].Value = Convert.ToString(readLine);
            }
            this.dgvNew.Rows.Clear();
            foreach (var replacedLine in replacedLines)
            {
                this.dgvNew.Rows.Add();
                this.dgvNew.Rows[dgvNew.Rows.Count - 1].Cells[0].Value = Convert.ToString(replacedLine);
            }
            foreach(DataGridViewRow dataGridViewRow in this.dgvNew.Rows)
            {
                var newValueString = Convert.ToString(dataGridViewRow.Cells[0].Value);
                var oldValueString = (this.dgvOld.Rows.Count - 1 >= dataGridViewRow.Index) ?
                    Convert.ToString(dgvOld.Rows[dataGridViewRow.Index].Cells[0].Value) : System.String.Empty;
                if (newValueString != oldValueString) {
                    dataGridViewRow.Cells[0].Style.BackColor = System.Drawing.Color.Yellow;
                }
            }
            if (IsPreview == false) this.WriteFileAllLines(selectedFileName, encoding, replacedLines);
        }
        #endregion

        #region メソッド（選択されたファイル名を取得する）
        /// <summary>
        /// メソッド（選択されたファイル名を取得する）
        /// </summary>
        /// <returns></returns>
        private string FetchSelectedFileName()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TEXTファイル(*.txt)|*.txt|HTMLファイル(*.html)|*.html|すべてのファイル(*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "ファイルを選択してください";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return System.String.Empty;
            return openFileDialog.FileName;
        }
        #endregion

        #region メソッド（ファイル全行読み込み）
        /// <summary>
        /// メソッド（ファイル全行読み込み）
        /// </summary>
        /// <param name="selectedFileName"></param>
        /// <returns></returns>
        private IReadOnlyList<string> ReadFileAllLines(in string selectedFileName, in Encoding encoding)
        {
            return System.IO.File.ReadAllLines(selectedFileName, encoding);
        }
        #endregion

        #region メソッド（ファイル全行書き込み）
        /// <summary>
        /// メソッド（ファイル全行読み込み）
        /// </summary>
        /// <param name="selectedFileName"></param>
        /// <returns></returns>
        private void WriteFileAllLines(in string selectedFileName, in Encoding encoding, in IReadOnlyList<string> fileAllLines)
        {
            System.IO.File.WriteAllText(selectedFileName, string.Join(Environment.NewLine, fileAllLines), encoding);
        }
        #endregion

        #region メソッド（ファイルを置換する）
        /// <summary>
        /// メソッド（ファイルを置換する）
        /// </summary>
        private IReadOnlyList<string>ReplaceFileAllLines( in string delimiterValue , IReadOnlyList<string> readLines, in IReadOnlyList<ReplacementListDefine> replacementList)
        {
            var fileAllLines = (IList<string>)readLines;
            if(replacementList.Count == 0) return (IReadOnlyList<string>)fileAllLines;

            foreach (ReplacementListDefine deifne in replacementList)
            {
                if (fileAllLines.Count > 0)
                {
                    var newAllLines = new List<string>();
                    foreach (var fileLine in fileAllLines)
                    {
                        var findValue = deifne.OldValue + delimiterValue;
                        if (fileLine.StartsWith(findValue) == true)
                        {
                            var primaryString = fileLine.Substring(0, findValue.Length);
                            var seconderyString = System.String.Empty;
                            var seconderyStringLength = fileLine.Length - findValue.Length;
                            if (seconderyStringLength > 1) seconderyString = fileLine.Substring(findValue.Length + 1 - 1, seconderyStringLength);
                            primaryString = deifne.NewValue + delimiterValue;
                            newAllLines.Add(primaryString + seconderyString);
                        }
                        else
                        {
                            newAllLines.Add(fileLine);
                        }
                    }
                    fileAllLines = newAllLines;
                }
            }
            return (IReadOnlyList<string>)fileAllLines;
        }
        #endregion

        #region メソッド（ダイアログ表示：置換リスト）
        /// <summary>
        /// メソッド（ダイアログ表示：置換リスト）
        /// </summary>
        private void ShowDialogFrmReplacementList()
        {
            var form = new FrmReplacementList();
            form.ShowDialog();
            form.Dispose();
        }
        #endregion
    }
}
