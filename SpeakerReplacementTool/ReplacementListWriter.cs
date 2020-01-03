using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerReplacementTool
{
    class ReplacementListWriter
    {
        #region プロパティ
        /// <summary>
        /// プロパティ
        /// </summary>
        private static readonly string SaveDirectoryPath = System.Environment.CurrentDirectory + @"\Save";
        private static readonly string SaveFilePath = System.Environment.CurrentDirectory + @"\Save\" + "ReplacementList.xml";
        public System.Data.DataTable SourceData { get; set; } = new System.Data.DataTable();
        #endregion

        #region メソッド（リスト書込）
        /// <summary>
        /// メソッド（リスト書込）
        /// </summary>
        /// <returns></returns>
        public void WriteList()
        {
            if (System.IO.Directory.Exists(SaveDirectoryPath) == false)
                System.IO.Directory.CreateDirectory(SaveDirectoryPath);

            this.SourceData.WriteXml(SaveFilePath);
        }
        #endregion
    }
}
