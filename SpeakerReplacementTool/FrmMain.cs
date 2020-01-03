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
        #region 変数定義
        /// <summary>
        /// 変数定義
        /// </summary>
        private static readonly int COLS_IDX_NO = 0;
        private static readonly int COLS_IDX_OLD_VALUE = 1;
        private static readonly int COLS_IDX_NEW_VALUE = 2;
        private static readonly string SaveDirectoryPath = System.Environment.CurrentDirectory + @"\Save";
        private static readonly string SaveFilePath = System.Environment.CurrentDirectory + @"\Save\" + "ReplacementList.xml";
        #endregion

        #region 構造体（置換リスト）
        /// <summary>
        /// 構造体（置換リスト）
        /// </summary>
        private struct ReplacementListRow
        {
            public string oldValue;
            public string newValue;
        }
        #endregion

        public FrmMain()
        {
            InitializeComponent();
        }

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

        #region メソッド（画面作成）
        /// <summary>
        /// メソッド（画面作成）
        /// </summary>
        private void MakeScreen()
        {
            this.MakeComboBox();
            this.MakeDataGridView();
            this.txtDelimiter.Text = "：";
        }
        #endregion

        #region メソッド（データグリッドビュー作成）
        /// <summary>
        /// メソッド（データグリッドビュー作成）
        /// </summary>
        private void MakeDataGridView()
        {
            if (System.IO.File.Exists(SaveFilePath) == true)
            {
                var dataSet = new DataSet();
                dataSet.ReadXml(SaveFilePath);
                var dataTable = dataSet.Tables[0];
                dataTable = dataSet.Tables[0];
                if(dataTable.Rows.Count > 0)
                {
                    foreach(DataRow dataRow in dataTable.Rows)
                    {
                        this.dgvMain.Rows.Add();
                        this.dgvMain.Rows[this.dgvMain.Rows.Count - 1].Cells[COLS_IDX_NO].Value = Convert.ToString(this.dgvMain.Rows.Count);
                        this.dgvMain.Rows[this.dgvMain.Rows.Count - 1].Cells[COLS_IDX_OLD_VALUE].Value = Convert.ToString(dataRow[dgvMain.Columns[COLS_IDX_OLD_VALUE].Name]);
                        this.dgvMain.Rows[this.dgvMain.Rows.Count - 1].Cells[COLS_IDX_NEW_VALUE].Value = Convert.ToString(dataRow[dgvMain.Columns[COLS_IDX_NEW_VALUE].Name]);
                    }
                }
            }
            else
            {
                var repeatCount = 30;
                for (var i = 1; i <= repeatCount; i++)
                {
                    this.dgvMain.Rows.Add();
                    this.dgvMain.Rows[this.dgvMain.Rows.Count - 1].Cells[COLS_IDX_NO].Value = Convert.ToString(this.dgvMain.Rows.Count);
                    this.dgvMain.Rows[this.dgvMain.Rows.Count - 1].Cells[COLS_IDX_OLD_VALUE].Value = System.String.Empty;
                    this.dgvMain.Rows[this.dgvMain.Rows.Count - 1].Cells[COLS_IDX_NEW_VALUE].Value = System.String.Empty;
                }
            }

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


        #region メソッド（ファイル置換）
        /// <summary>
        /// メソッド（ファイル置換）
        /// </summary>
        private void ReplaceFile(in bool IsPreview )
        {
            var replacementList = this.FetchReplacementList();
            if (replacementList.Count == 0) return;

            var selectedFileName = this.FetchSelectedFileName();
            if (selectedFileName == System.String.Empty) return;

            var encoding = System.Text.Encoding.GetEncoding(Convert.ToString(this.cboEncoding.SelectedValue));
            if (encoding == null) return;

            var readLines = this.ReadFileAllLines(selectedFileName, encoding);
            var replacedLines = this.ReplaceFileAllLines(txtDelimiter.Text, (IReadOnlyList<string>)readLines, replacementList);
            if(IsPreview == true)
            {
                var frm = new FrmSub();
                frm.Memo = string.Join(Environment.NewLine, readLines);
                frm.ShowDialog();
            }
            else
            {
                this.WriteFileAllLines(selectedFileName, encoding, replacedLines);
            }
            this.SaveReplacementList();
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

        #region メソッド（置換リストを取得する）
        /// <summary>
        /// メソッド（置換リストを取得する）
        /// </summary>
        /// <returns></returns>
        private List<ReplacementListRow> FetchReplacementList()
        {
            var replacementList = new List<ReplacementListRow>();
            if (dgvMain.Rows.Count <= 1) return replacementList;
            foreach (DataGridViewRow dataGridViewRow in dgvMain.Rows)
            {
                var oldValue = Convert.ToString(dataGridViewRow.Cells[COLS_IDX_OLD_VALUE].Value);
                var newValue = Convert.ToString(dataGridViewRow.Cells[COLS_IDX_NEW_VALUE].Value);

                if (oldValue.Length > 0 || newValue.Length > 0)
                {
                    replacementList.Add(new ReplacementListRow
                    {
                        oldValue = oldValue,
                        newValue = newValue
                    });
                }
            }
            return replacementList;
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
        private IReadOnlyList<string>ReplaceFileAllLines( in string delimiterValue , IReadOnlyList<string> readLines, in IReadOnlyList<ReplacementListRow> replacementList)
        {
            var fileAllLines = (IList<string>)readLines;
            if(replacementList.Count == 0) return (IReadOnlyList<string>)fileAllLines;

            foreach (ReplacementListRow replacementListRow in replacementList)
            {
                if (fileAllLines.Count > 0)
                {
                    var newAllLines = new List<string>();
                    foreach (var fileLine in fileAllLines)
                    {
                        var findValue = replacementListRow.oldValue + delimiterValue;
                        if (fileLine.StartsWith(findValue) == true)
                        {
                            var primaryString = fileLine.Substring(0, findValue.Length);
                            var seconderyString = System.String.Empty;
                            var seconderyStringLength = fileLine.Length - findValue.Length;
                            if (seconderyStringLength > 1) seconderyString = fileLine.Substring(findValue.Length + 1 - 1, seconderyStringLength);
                            primaryString = replacementListRow.newValue + delimiterValue;
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

        #region メソッド（コンボボックス作成）
        /// <summary>
        /// メソッド（コンボボックス作成）
        /// </summary>
        private void MakeComboBox()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("code", typeof(string));
            dataTable.Columns.Add("name", typeof(string));

            var dataRow = dataTable.NewRow();
            dataRow["code"] = "utf-8";
            dataRow["name"] = "UTF-8";
            dataTable.Rows.Add(dataRow);

            dataRow = dataTable.NewRow();
            dataRow["code"] = "shift_jis";
            dataRow["name"] = "シフトJIS";
            dataTable.Rows.Add(dataRow);

            cboEncoding.ValueMember = "code";
            cboEncoding.DisplayMember = "name";
            cboEncoding.DataSource = dataTable;
        }
        #endregion

        #region メソッド（置換リストを保存する）
        /// <summary>
        /// メソッド（置換リストを保存する）
        /// </summary>
        private void SaveReplacementList()
        {
            if (System.IO.Directory.Exists(SaveDirectoryPath) == false) 
                System.IO.Directory.CreateDirectory(SaveDirectoryPath);

            var dataTable = new DataTable();
            foreach(DataGridViewColumn dataGridViewColumn in dgvMain.Columns)
                dataTable.Columns.Add(dataGridViewColumn.Name);

            foreach (DataGridViewRow dataGridViewRow in dgvMain.Rows)
            {
                var dataTableRow = dataTable.NewRow();
                foreach (DataGridViewColumn dataGridViewColumn in dgvMain.Columns)
                    dataTableRow[dataGridViewColumn.Index] = dataGridViewRow.Cells[dataGridViewColumn.Index].Value;

                dataTable.Rows.Add(dataTableRow);
            }
            dataTable.TableName = "replacement_list";
            dataTable.WriteXml(SaveFilePath);

        }
        #endregion

    }
}
