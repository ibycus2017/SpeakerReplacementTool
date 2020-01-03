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
    public partial class FrmSub : Form
    {
        #region プロパティ
        /// <summary>
        /// プロパティ
        /// </summary>
        public string Memo { get; set; } = System.String.Empty;
        #endregion

        public FrmSub()
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
            this.txtMain.Text = this.Memo;
        }
        #endregion
    }
}
