using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakerReplacementTool
{
    class EncodingFetcher
    {
        #region 文字コード取得
        /// <summary>
        /// 文字コードを判別する
        /// </summary>
        /// <remarks>
        /// Jcode.pmのgetcodeメソッドを移植したものです。
        /// Jcode.pm(http://openlab.ring.gr.jp/Jcode/index-j.html)
        /// Jcode.pmの著作権情報
        /// Copyright 1999-2005 Dan Kogai <dankogai@dan.co.jp>
        /// This library is free software; you can redistribute it and/or modify it
        ///  under the same terms as Perl itself.
        /// </remarks>
        /// <param name="bytes">文字コードを調べるデータ</param>
        /// <returns>適当と思われるEncodingオブジェクト。
        /// 判断できなかった時はnull。</returns>
        public System.Text.Encoding FetchEncoding(byte[] bytes)
        {
            const byte bEscape = 0x1B;
            const byte bAt = 0x40;
            const byte bDollar = 0x24;
            const byte bAnd = 0x26;
            const byte bOpen = 0x28;    //'('
            const byte bB = 0x42;
            const byte bD = 0x44;
            const byte bJ = 0x4A;
            const byte bI = 0x49;

            var bytesLength = bytes.Length;
            var byte1 = default(byte);
            var byte2 = default(byte);
            var byte3 = default(byte);
            var byte4 = default(byte);

            //Encode::is_utf8 は無視

            var isBinary = false;
            for (var i = 0; i < bytesLength; i++)
            {
                byte1 = bytes[i];
                if (byte1 <= 0x06 || byte1 == 0x7F || byte1 == 0xFF)
                {
                    //'binary'
                    isBinary = true;
                    if (byte1 == 0x00 && i < bytesLength - 1 && bytes[i + 1] <= 0x7F) return System.Text.Encoding.Unicode;
                }
            }
            if (isBinary) return null;

            //not Japanese
            var notJapanese = true;
            for (var i = 0; i < bytesLength; i++)
            {
                byte1 = bytes[i];
                if (byte1 == bEscape || 0x80 <= byte1)
                {
                    notJapanese = false;
                    break;
                }
            }

            if (notJapanese) return System.Text.Encoding.ASCII;

            for (var i = 0; i < bytesLength - 2; i++)
            {
                byte1 = bytes[i];
                byte2 = bytes[i + 1];
                byte3 = bytes[i + 2];

                if (byte1 == bEscape)
                {
                    if (byte2 == bDollar && byte3 == bAt) return System.Text.Encoding.GetEncoding(50220);
                    if (byte2 == bDollar && byte3 == bB) return System.Text.Encoding.GetEncoding(50220);
                    if (byte2 == bOpen && (byte3 == bB || byte3 == bJ)) return System.Text.Encoding.GetEncoding(50220);
                    if (byte2 == bOpen && byte3 == bI) return System.Text.Encoding.GetEncoding(50220);
                    if (i < bytesLength - 3)
                    {
                        byte4 = bytes[i + 3];
                        if (byte2 == bDollar && byte3 == bOpen && byte4 == bD) return System.Text.Encoding.GetEncoding(50220);
                        if (i < bytesLength - 5 &&
                            byte2 == bAnd && byte3 == bAt && byte4 == bEscape &&
                            bytes[i + 4] == bDollar && bytes[i + 5] == bB) return System.Text.Encoding.GetEncoding(50220);
                    }
                }
            }

            //should be euc|sjis|utf8
            //use of (?:) by Hiroki Ohzaki <ohzaki@iod.ricoh.co.jp>
            var characterCountSjis = default(Int32);
            var characterCountEuc = default(Int32);
            var characterCountUtf8 = default(Int32);
            for (var i = 0; i < bytesLength - 1; i++)
            {
                byte1 = bytes[i];
                byte2 = bytes[i + 1];
                if (((0x81 <= byte1 && byte1 <= 0x9F) || (0xE0 <= byte1 && byte1 <= 0xFC)) &&
                    ((0x40 <= byte2 && byte2 <= 0x7E) || (0x80 <= byte2 && byte2 <= 0xFC)))
                {
                    //SJIS_C
                    characterCountSjis += 2;
                    i++;
                }
            }
            for (var i = 0; i < bytesLength - 1; i++)
            {
                byte1 = bytes[i];
                byte2 = bytes[i + 1];
                if (((0xA1 <= byte1 && byte1 <= 0xFE) && (0xA1 <= byte2 && byte2 <= 0xFE)) ||
                    (byte1 == 0x8E && (0xA1 <= byte2 && byte2 <= 0xDF)))
                {
                    //EUC_C
                    //EUC_KANA
                    characterCountEuc += 2;
                    i++;
                }
                else if (i < bytesLength - 2)
                {
                    byte3 = bytes[i + 2];
                    if (byte1 == 0x8F && (0xA1 <= byte2 && byte2 <= 0xFE) &&
                        (0xA1 <= byte3 && byte3 <= 0xFE))
                    {
                        //EUC_0212
                        characterCountEuc += 3;
                        i += 2;
                    }
                }
            }
            for (var i = 0; i < bytesLength - 1; i++)
            {
                byte1 = bytes[i];
                byte2 = bytes[i + 1];
                if ((0xC0 <= byte1 && byte1 <= 0xDF) && (0x80 <= byte2 && byte2 <= 0xBF))
                {
                    //UTF8
                    characterCountUtf8 += 2;
                    i++;
                }
                else if (i < bytesLength - 2)
                {
                    byte3 = bytes[i + 2];
                    if ((0xE0 <= byte1 && byte1 <= 0xEF) && (0x80 <= byte2 && byte2 <= 0xBF) &&
                        (0x80 <= byte3 && byte3 <= 0xBF))
                    {
                        //UTF8
                        characterCountUtf8 += 3;
                        i += 2;
                    }
                }
            }
            //M. Takahashi's suggestion
            //utf8 += utf8 / 2;

            System.Diagnostics.Debug.WriteLine(
                string.Format("sjis = {0}, euc = {1}, utf8 = {2}", characterCountSjis, characterCountEuc, characterCountUtf8));
            if (characterCountEuc > characterCountSjis && characterCountEuc > characterCountUtf8) return System.Text.Encoding.GetEncoding(51932);
            if (characterCountSjis > characterCountEuc && characterCountSjis > characterCountUtf8) return System.Text.Encoding.GetEncoding(932);
            if (characterCountUtf8 > characterCountEuc && characterCountUtf8 > characterCountSjis) return System.Text.Encoding.UTF8;
            return null;
        }
        #endregion
    }
}
