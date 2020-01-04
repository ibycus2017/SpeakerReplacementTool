using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerReplacementTool
{
    public class FormParametersWriter
    {
        #region プロパティ
        /// <summary>
        /// プロパティ
        /// </summary>
        private static readonly string SaveDirectoryPath = System.Environment.CurrentDirectory + @"\Settings";
        private static readonly string SaveFilePath = System.Environment.CurrentDirectory + @"\Settings\" + "FormParameters.xml";
        public IList<FormParametersDefine> SourceList { get; set; } = new List<FormParametersDefine>();
        #endregion

        #region メソッド（リスト書込）
        /// <summary>
        /// メソッド（リスト書込）
        /// </summary>
        /// <returns></returns>
        public void WriteParameters()
        {
            if (System.IO.Directory.Exists(SaveDirectoryPath) == false)
                System.IO.Directory.CreateDirectory(SaveDirectoryPath);

            var dataTable = new System.Data.DataTable();
            dataTable.Columns.Add("FrmReplacementListDelimiter");
            dataTable.Columns.Add("FrmMainDelimiter");
            var dataRow = dataTable.NewRow();
            foreach (FormParametersDefine formParametersDefine in SourceList)
            {
                dataRow["FrmReplacementListDelimiter"] = formParametersDefine.FrmReplacementListDelimiter;
                dataRow["FrmMainDelimiter"] = formParametersDefine.FrmMainDelimiter;
            }
            dataTable.Rows.Add(dataRow);
            dataTable.TableName = "form_parametes";
            dataTable.WriteXml(SaveFilePath);
        }
        #endregion
    }
}
