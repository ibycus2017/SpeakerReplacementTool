using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerReplacementTool
{
    public class ReplacementListReader
    {
        #region プロパティ
        /// <summary>
        /// プロパティ
        /// </summary>
        private string FilePath { get; set; } = System.Environment.CurrentDirectory + @"\Save\" + "ReplacementList.xml";
        #endregion

        #region メソッド（リスト読取）
        /// <summary>
        /// メソッド（リスト読取）
        /// </summary>
        /// <returns></returns>
        public IReadOnlyList<ReplacementListDefine> ReadList()
        {
            var list = new List<ReplacementListDefine>();
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
                            var define = new ReplacementListDefine();
                            if (dataTable.Columns.Contains("colOldValue") == true) define.OldValue = Convert.ToString(dataRow["colOldValue"]);
                            if (dataTable.Columns.Contains("colNewValue") == true) define.NewValue = Convert.ToString(dataRow["colNewValue"]);
                            list.Add(define);
                        }
                    }
                }
                catch (Exception exception)
                {
                    System.Console.WriteLine(exception.Message);
                }
            }
            return list;
        }
        #endregion
    }
}
