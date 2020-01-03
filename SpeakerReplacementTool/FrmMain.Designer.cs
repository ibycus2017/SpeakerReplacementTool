namespace SpeakerReplacementTool
{
    partial class FrmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.txtDelimiter = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFileReplacement = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnPreview = new System.Windows.Forms.Button();
            this.tlpBody = new System.Windows.Forms.TableLayoutPanel();
            this.lnkReplacementList = new System.Windows.Forms.LinkLabel();
            this.dgvOld = new System.Windows.Forms.DataGridView();
            this.colOldValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNew = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEncoding = new System.Windows.Forms.Label();
            this.tlpBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNew)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDelimiter
            // 
            this.tlpBody.SetColumnSpan(this.txtDelimiter, 18);
            this.txtDelimiter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDelimiter.Location = new System.Drawing.Point(39, 112);
            this.txtDelimiter.Margin = new System.Windows.Forms.Padding(0);
            this.txtDelimiter.Name = "txtDelimiter";
            this.txtDelimiter.Size = new System.Drawing.Size(702, 23);
            this.txtDelimiter.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tlpBody.SetColumnSpan(this.label2, 18);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(39, 84);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(702, 28);
            this.label2.TabIndex = 6;
            this.label2.Text = "区切り文字";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFileReplacement
            // 
            this.tlpBody.SetColumnSpan(this.btnFileReplacement, 4);
            this.btnFileReplacement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFileReplacement.Location = new System.Drawing.Point(585, 140);
            this.btnFileReplacement.Margin = new System.Windows.Forms.Padding(0);
            this.btnFileReplacement.Name = "btnFileReplacement";
            this.btnFileReplacement.Size = new System.Drawing.Size(156, 28);
            this.btnFileReplacement.TabIndex = 6;
            this.btnFileReplacement.Text = "置換";
            this.btnFileReplacement.UseVisualStyleBackColor = true;
            this.btnFileReplacement.Click += new System.EventHandler(this.btnFileReplacement_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tlpBody.SetColumnSpan(this.lblTitle, 20);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(3);
            this.tlpBody.SetRowSpan(this.lblTitle, 2);
            this.lblTitle.Size = new System.Drawing.Size(784, 56);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "発言者置換ツール";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPreview
            // 
            this.tlpBody.SetColumnSpan(this.btnPreview, 4);
            this.btnPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPreview.Location = new System.Drawing.Point(429, 140);
            this.btnPreview.Margin = new System.Windows.Forms.Padding(0);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(156, 28);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "プレビュー";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // tlpBody
            // 
            this.tlpBody.AutoScroll = true;
            this.tlpBody.ColumnCount = 20;
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.997705F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.997705F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.000256F));
            this.tlpBody.Controls.Add(this.label1, 1, 17);
            this.tlpBody.Controls.Add(this.btnPreview, 11, 5);
            this.tlpBody.Controls.Add(this.lblTitle, 0, 0);
            this.tlpBody.Controls.Add(this.btnFileReplacement, 15, 5);
            this.tlpBody.Controls.Add(this.label2, 1, 3);
            this.tlpBody.Controls.Add(this.txtDelimiter, 1, 4);
            this.tlpBody.Controls.Add(this.lnkReplacementList, 1, 5);
            this.tlpBody.Controls.Add(this.dgvOld, 1, 6);
            this.tlpBody.Controls.Add(this.dgvNew, 10, 6);
            this.tlpBody.Controls.Add(this.lblEncoding, 1, 18);
            this.tlpBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBody.Location = new System.Drawing.Point(0, 0);
            this.tlpBody.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBody.Name = "tlpBody";
            this.tlpBody.RowCount = 20;
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBody.Size = new System.Drawing.Size(784, 561);
            this.tlpBody.TabIndex = 0;
            // 
            // lnkReplacementList
            // 
            this.lnkReplacementList.AutoSize = true;
            this.tlpBody.SetColumnSpan(this.lnkReplacementList, 4);
            this.lnkReplacementList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lnkReplacementList.Location = new System.Drawing.Point(42, 140);
            this.lnkReplacementList.Name = "lnkReplacementList";
            this.lnkReplacementList.Size = new System.Drawing.Size(150, 28);
            this.lnkReplacementList.TabIndex = 4;
            this.lnkReplacementList.TabStop = true;
            this.lnkReplacementList.Text = "置換リスト";
            this.lnkReplacementList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkReplacementList.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkReplacementList_LinkClicked);
            // 
            // dgvOld
            // 
            this.dgvOld.AllowUserToAddRows = false;
            this.dgvOld.AllowUserToDeleteRows = false;
            this.dgvOld.AllowUserToResizeColumns = false;
            this.dgvOld.AllowUserToResizeRows = false;
            this.dgvOld.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOld.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colOldValue});
            this.tlpBody.SetColumnSpan(this.dgvOld, 9);
            this.dgvOld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOld.EnableHeadersVisualStyles = false;
            this.dgvOld.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.dgvOld.Location = new System.Drawing.Point(39, 168);
            this.dgvOld.Margin = new System.Windows.Forms.Padding(0);
            this.dgvOld.Name = "dgvOld";
            this.dgvOld.ReadOnly = true;
            this.dgvOld.RowHeadersVisible = false;
            this.dgvOld.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tlpBody.SetRowSpan(this.dgvOld, 11);
            this.dgvOld.RowTemplate.Height = 21;
            this.dgvOld.Size = new System.Drawing.Size(351, 308);
            this.dgvOld.TabIndex = 7;
            // 
            // colOldValue
            // 
            this.colOldValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colOldValue.HeaderText = "置換前の文字列";
            this.colOldValue.Name = "colOldValue";
            this.colOldValue.ReadOnly = true;
            this.colOldValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colOldValue.Width = 3000;
            // 
            // dgvNew
            // 
            this.dgvNew.AllowUserToAddRows = false;
            this.dgvNew.AllowUserToDeleteRows = false;
            this.dgvNew.AllowUserToResizeColumns = false;
            this.dgvNew.AllowUserToResizeRows = false;
            this.dgvNew.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNew.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3});
            this.tlpBody.SetColumnSpan(this.dgvNew, 9);
            this.dgvNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNew.EnableHeadersVisualStyles = false;
            this.dgvNew.ImeMode = System.Windows.Forms.ImeMode.Hiragana;
            this.dgvNew.Location = new System.Drawing.Point(390, 168);
            this.dgvNew.Margin = new System.Windows.Forms.Padding(0);
            this.dgvNew.Name = "dgvNew";
            this.dgvNew.ReadOnly = true;
            this.dgvNew.RowHeadersVisible = false;
            this.dgvNew.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tlpBody.SetRowSpan(this.dgvNew, 11);
            this.dgvNew.RowTemplate.Height = 21;
            this.dgvNew.Size = new System.Drawing.Size(351, 308);
            this.dgvNew.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.HeaderText = "置換後の文字列";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 3000;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tlpBody.SetColumnSpan(this.label1, 18);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(39, 476);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(702, 28);
            this.label1.TabIndex = 17;
            this.label1.Text = "文字コード";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEncoding
            // 
            this.lblEncoding.AutoSize = true;
            this.lblEncoding.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tlpBody.SetColumnSpan(this.lblEncoding, 18);
            this.lblEncoding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEncoding.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblEncoding.Location = new System.Drawing.Point(39, 504);
            this.lblEncoding.Margin = new System.Windows.Forms.Padding(0);
            this.lblEncoding.Name = "lblEncoding";
            this.lblEncoding.Size = new System.Drawing.Size(702, 28);
            this.lblEncoding.TabIndex = 19;
            this.lblEncoding.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tlpBody);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = "発言者置換ツール";
            this.Load += new System.EventHandler(this.Form_Load);
            this.tlpBody.ResumeLayout(false);
            this.tlpBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNew)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDelimiter;
        private System.Windows.Forms.TableLayoutPanel tlpBody;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnFileReplacement;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel lnkReplacementList;
        private System.Windows.Forms.DataGridView dgvOld;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOldValue;
        private System.Windows.Forms.DataGridView dgvNew;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEncoding;
    }
}

