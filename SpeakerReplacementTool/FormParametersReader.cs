using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerReplacementTool
{
    public class FormParametersReader
    {
        #region プロパティ
        /// <summary>
        /// プロパティ
        /// </summary>
        private string FilePath { get; set; } = System.Environment.CurrentDirectory + @"\Settings\" + "FormParameters.xml";
        #endregion

        #region メソッド（リスト読取）
        /// <summary>
        /// メソッド（リスト読取）
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<FormParametersDefine> ReadParameters()
        {
            var formParameters = new List<FormParametersDefine>();
            if (System.IO.File.Exists(FilePath) == true)
            {
                var dataSet = new System.Data.DataSet();
                try
                {
                    dataSet.ReadXml(FilePath);
                    if (dataSet.Tables.Count > 0)
                    {
                        var dataTable = dataSet.Tables[0];
                        foreach(System.Data.DataRow dataRow in dataTable.Rows)
                        {
                            var formParametersDefine = new FormParametersDefine();
                            var dataTableColumns = dataTable.Columns;
                            if (dataTableColumns.Contains("FrmReplacementListDelimiter") == true)
                                formParametersDefine.FrmReplacementListDelimiter = Convert.ToString(dataRow["FrmReplacementListDelimiter"]);
                            if (dataTableColumns.Contains("FrmMainDelimiter") == true)
                                formParametersDefine.FrmMainDelimiter = Convert.ToString(dataRow["FrmMainDelimiter"]);
                            formParameters.Add(formParametersDefine);
                        }
                    }
                }
                catch (Exception exception)
                {
                    System.Console.WriteLine(exception.Message);
                }
            }
            return formParameters;
        }
        #endregion
    }
}
