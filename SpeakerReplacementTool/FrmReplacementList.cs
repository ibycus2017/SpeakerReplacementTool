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
    public partial class FrmReplacementList : Form
    {
        #region 変数定義
        /// <summary>
        /// 変数定義
        /// </summary>
        private static readonly int COLS_IDX_NO = 0;
        private static readonly int COLS_IDX_OLD_VALUE = 1;
        private static readonly int COLS_IDX_NEW_VALUE = 2;
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public FrmReplacementList()
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

        #region イベント（フォームクロージング）
        /// <summary>
        /// イベント（フォームクロージング）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SaveReplacementList();
        }
        #endregion

        #region イベント（1行増やす）
        /// <summary>
        /// イベント（1行増やす）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIncrease_Click(object sender, EventArgs e)
        {
            this.IncreaseRow();
        }
        #endregion

        #region イベント（1行減らす）
        /// <summary>
        /// イベント（1行減らす）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReduction_Click(object sender, EventArgs e)
        {
            this.ReductionRow();
        }
        #endregion

        #region イベント（ボタンクリック：取込）
        /// <summary>
        /// イベント（ボタンクリック：取込）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImport_Click(object sender, EventArgs e)
        {
            this.ImportFile();
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
        }
        #endregion

        #region メソッド（コンボボックス作成）
        /// <summary>
        /// メソッド（コンボボックス作成）
        /// </summary>
        private void MakeComboBox()
        {
            this.MakecboDemiliter();
        }
        #endregion

        #region メソッド（コンボボックス作成：区切り文字）
        /// <summary>
        /// メソッド（コンボボックス作成：区切り文字）
        /// </summary>
        private void MakecboDemiliter()
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("code", typeof(string));
            dataTable.Columns.Add("name", typeof(string));

            var dataRow = dataTable.NewRow();
            dataRow["code"] = "\t";
            dataRow["name"] = "タブ";
            dataTable.Rows.Add(dataRow);

            dataRow = dataTable.NewRow();
            dataRow["code"] = ";";
            dataRow["name"] = "セミコロン（;）";
            dataTable.Rows.Add(dataRow);

            dataRow = dataTable.NewRow();
            dataRow["code"] = @",";
            dataRow["name"] = @"カンマ（,）";
            dataTable.Rows.Add(dataRow);

            dataRow = dataTable.NewRow();
            dataRow["code"] = @" ";
            dataRow["name"] = @"スペース";
            dataTable.Rows.Add(dataRow);

            this.cboDelimiter.ValueMember = "code";
            this.cboDelimiter.DisplayMember = "name";
            this.cboDelimiter.DataSource = dataTable;
        }
        #endregion

        #region メソッド（データグリッドビュー作成）
        /// <summary>
        /// メソッド（データグリッドビュー作成）
        /// </summary>
        private void MakeDataGridView()
        {
            dgvMain.Rows.Clear();
            var list = new ReplacementListReader().ReadList();
            if (list.Count == 0) return;
            foreach(ReplacementListDefine define in list)
            {
                dgvMain.Rows.Add();
                dgvMain.Rows[dgvMain.Rows.Count - 1].Cells[COLS_IDX_NO].Value = Convert.ToString(dgvMain.Rows.Count);
                dgvMain.Rows[dgvMain.Rows.Count - 1].Cells[COLS_IDX_OLD_VALUE].Value = define.OldValue;
                dgvMain.Rows[dgvMain.Rows.Count - 1].Cells[COLS_IDX_NEW_VALUE].Value = define.NewValue;
            }
        }
        #endregion

        #region メソッド（置換リストを保存する）
        /// <summary>
        /// メソッド（置換リストを保存する）
        /// </summary>
        private void SaveReplacementList()
        {
            var dataTable = new System.Data.DataTable();
            foreach (DataGridViewColumn dataGridViewColumn in dgvMain.Columns)
                dataTable.Columns.Add(dataGridViewColumn.Name);

            foreach (DataGridViewRow dataGridViewRow in dgvMain.Rows)
            {
                var dataTableRow = dataTable.NewRow();
                foreach (DataGridViewColumn dataGridViewColumn in dgvMain.Columns)
                    dataTableRow[dataGridViewColumn.Index] = dataGridViewRow.Cells[dataGridViewColumn.Index].Value;

                dataTable.Rows.Add(dataTableRow);
            }
            dataTable.TableName = "replacement_list";

            var replacementListWriter = new ReplacementListWriter();
            replacementListWriter.SourceData = dataTable;
            replacementListWriter.WriteList();
        }
        #endregion

        #region メソッド（1行増やす）
        /// <summary>
        /// メソッド（1行増やす）
        /// </summary>
        private void IncreaseRow()
        {
            dgvMain.Rows.Add();
            dgvMain.Rows[dgvMain.Rows.Count - 1].Cells[COLS_IDX_NO].Value = Convert.ToString(dgvMain.Rows.Count);
            dgvMain.Rows[dgvMain.Rows.Count - 1].Cells[COLS_IDX_OLD_VALUE].Value = System.String.Empty;
            dgvMain.Rows[dgvMain.Rows.Count - 1].Cells[COLS_IDX_NEW_VALUE].Value = System.String.Empty;
        }
        #endregion

        #region メソッド（1行減らす）
        /// <summary>
        /// メソッド（1行減らす）
        /// </summary>
        private void ReductionRow()
        {
            if (dgvMain.Rows.Count <= 0) return;
            dgvMain.Rows.RemoveAt(dgvMain.Rows.Count - 1);
        }
        #endregion

        #region CSVファイル取込
        /// <summary>
        /// CSVファイル取込
        /// </summary>
        private void ImportFile()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TEXTファイル(*.txt)|*.txt|CSVファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "ファイルを選択してください";
            if (openFileDialog.ShowDialog() == DialogResult.Cancel) return;
            var selectedFileName = openFileDialog.FileName;

            var encoding = new EncodingFetcher().FetchEncoding(System.IO.File.ReadAllBytes(selectedFileName));
            if (encoding == null) return;
            this.lblEncoding.Text = encoding.EncodingName;
            var readLines = (IReadOnlyList<string>)System.IO.File.ReadAllLines(selectedFileName, encoding);
            this.dgvMain.Rows.Clear();
            foreach (var readLine in readLines)
            {
                var readValues = new List<string>();
                readValues.AddRange(readLine.Split(Convert.ToChar(this.cboDelimiter.SelectedValue)));

                this.dgvMain.Rows.Add();
                var dgvRows = this.dgvMain.Rows[this.dgvMain.Rows.Count - 1];
                dgvRows.Cells[COLS_IDX_NO].Value = Convert.ToString(this.dgvMain.Rows.Count);
                if (0 <= readValues.Count - 1) dgvRows.Cells[COLS_IDX_OLD_VALUE].Value = Convert.ToString(readValues[0]);
                if (1 <= readValues.Count - 1) dgvRows.Cells[COLS_IDX_NEW_VALUE].Value = Convert.ToString(readValues[1]);
            }
        }
        #endregion
    }
}
