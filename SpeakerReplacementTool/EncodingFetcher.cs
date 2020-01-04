using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerReplacementTool
{
    public class EncodingFetcher
    {
        #region メンバ変数
        /// <summary>
        /// メンバ変数
        /// </summary>
        private static readonly byte ESCAPE_BYTE = 0x1B;
        private static readonly byte ATMARK_BYTE = 0x40;
        private static readonly byte DOLLAR_BYTE = 0x24;
        private static readonly byte AND_BYTE = 0x26;
        private static readonly byte OPEN_BYTE = 0x28;
        private static readonly byte B_BYTE = 0x42;
        private static readonly byte D_BYTE = 0x44;
        private static readonly byte J_BYTE = 0x4A;
        private static readonly byte I_BYTE = 0x49;
        #endregion

        #region メソッド（文字コード取得）
        /// <summary>
        /// メソッド（文字コード取得）
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public System.Text.Encoding FetchEncoding(byte[] bytes)
        {
            var byteLength = bytes.Length;
            var byte1 = default(byte);

            var isBinary = false;
            for (var byteIndex = 0; byteIndex < byteLength; byteIndex++)
            {
                byte1 = bytes[byteIndex];
                if (byte1 <= 0x06 || 
                    byte1 == 0x7F || 
                    byte1 == 0xFF)
                {
                    isBinary = true;
                    if (byte1 == 0x00 && 
                        byteIndex < byteLength - 1 && 
                        bytes[byteIndex + 1] <= 0x7F)
                        return System.Text.Encoding.Unicode;
                }
            }
            if (isBinary == true) return default(System.Text.Encoding);

            //not Japanese
            var notJapanese = true;
            for (var byteIndex = 0; byteIndex < byteLength; byteIndex++)
            {
                byte1 = bytes[byteIndex];
                if (byte1 == ESCAPE_BYTE ||
                    0x80 <= byte1)
                {
                    notJapanese = false;
                    break;
                }
            }
            if (notJapanese == true) return System.Text.Encoding.ASCII;

            var byte2 = default(byte);
            var byte3 = default(byte);
            var byte4 = default(byte);
            for (var byteIndex = 0; byteIndex < byteLength - 2; byteIndex++)
            {
                byte1 = bytes[byteIndex];
                byte2 = bytes[byteIndex + 1];
                byte3 = bytes[byteIndex + 2];

                if (byte1 == ESCAPE_BYTE)
                {
                    //JIS_0208 1978
                    if (byte2 == DOLLAR_BYTE && 
                        byte3 == ATMARK_BYTE) 
                        return System.Text.Encoding.GetEncoding(50220);

                    //JIS_0208 1983
                    if (byte2 == DOLLAR_BYTE && 
                        byte3 == B_BYTE) 
                        return System.Text.Encoding.GetEncoding(50220);

                    //JIS_ASC
                    if (byte2 == OPEN_BYTE && 
                       (byte3 == B_BYTE || 
                        byte3 == J_BYTE)) 
                        return System.Text.Encoding.GetEncoding(50220);

                    //JIS_KANA
                    if (byte2 == OPEN_BYTE && 
                        byte3 == I_BYTE) 
                        return System.Text.Encoding.GetEncoding(50220);

                    if (byteIndex < byteLength - 3)
                    {
                        byte4 = bytes[byteIndex + 3];

                        //JIS_0212
                        if (byte2 == DOLLAR_BYTE && 
                            byte3 == OPEN_BYTE && 
                            byte4 == D_BYTE)
                            return System.Text.Encoding.GetEncoding(50220);

                        //JIS_0208 1990
                        if (byteIndex < byteLength - 5 &&
                            byte2 == AND_BYTE && 
                            byte3 == ATMARK_BYTE && 
                            byte4 == ESCAPE_BYTE &&
                            bytes[byteIndex + 4] == DOLLAR_BYTE && 
                            bytes[byteIndex + 5] == B_BYTE)
                            return System.Text.Encoding.GetEncoding(50220);
                    }
                }
            }

            var countSjis = default(Int32);
            var countEuc = default(Int32);
            var countUtf8 = default(Int32);
            for (var byteIndex = 0; byteIndex < byteLength - 1; byteIndex++)
            {
                byte1 = bytes[byteIndex];
                byte2 = bytes[byteIndex + 1];
                if (((0x81 <= byte1 && byte1 <= 0x9F) || 
                     (0xE0 <= byte1 && byte1 <= 0xFC)) &&
                    ((0x40 <= byte2 && byte2 <= 0x7E) || 
                     (0x80 <= byte2 && byte2 <= 0xFC)))
                {
                    //SJIS_C
                    countSjis += 2;
                    byteIndex++;
                }
            }
            for (var byteIndex = 0; byteIndex < byteLength - 1; byteIndex++)
            {
                byte1 = bytes[byteIndex];
                byte2 = bytes[byteIndex + 1];
                if (((0xA1 <= byte1 && byte1 <= 0xFE) && 
                     (0xA1 <= byte2 && byte2 <= 0xFE)) ||
                    (byte1 == 0x8E && 
                     (0xA1 <= byte2 && byte2 <= 0xDF)))
                {
                    //EUC_C
                    //EUC_KANA
                    countEuc += 2;
                    byteIndex++;
                }
                else if (byteIndex < byteLength - 2)
                {
                    byte3 = bytes[byteIndex + 2];
                    if (byte1 == 0x8F && 
                        (0xA1 <= byte2 && byte2 <= 0xFE) &&
                        (0xA1 <= byte3 && byte3 <= 0xFE))
                    {
                        //EUC_0212
                        countEuc += 3;
                        byteIndex += 2;
                    }
                }
            }
            for (int byteIndex = 0; byteIndex < byteLength - 1; byteIndex++)
            {
                byte1 = bytes[byteIndex];
                byte2 = bytes[byteIndex + 1];
                if ((0xC0 <= byte1 && byte1 <= 0xDF) && 
                    (0x80 <= byte2 && byte2 <= 0xBF))
                {
                    //UTF8
                    countUtf8 += 2;
                    byteIndex++;
                }
                else if (byteIndex < byteLength - 2)
                {
                    byte3 = bytes[byteIndex + 2];
                    if ((0xE0 <= byte1 && byte1 <= 0xEF) && 
                        (0x80 <= byte2 && byte2 <= 0xBF) &&
                        (0x80 <= byte3 && byte3 <= 0xBF))
                    {
                        //UTF8
                        countUtf8 += 3;
                        byteIndex += 2;
                    }
                }
            }

            //EUC
            if (countEuc > countSjis && 
                countEuc > countUtf8) 
                return System.Text.Encoding.GetEncoding(51932);

            //SJIS
            if (countSjis > countEuc && 
                countSjis > countUtf8) 
                return System.Text.Encoding.GetEncoding(932);

            //UTF8
            if (countUtf8 > countEuc && 
                countUtf8 > countSjis) 
                return System.Text.Encoding.UTF8;

            return default(System.Text.Encoding);
        }
        #endregion
    }
}