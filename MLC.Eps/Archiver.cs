using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using Ionic.Zip;
using Ionic.Zlib;

namespace MLC.Eps
{
    public class Archiver
    {
        public const int DefaultCompressionLevel = 1;
        public static readonly Encoding DefaultEncoding = Encoding.UTF8;

        public byte[] Archive(byte[] data, string nodeName, int compressionLevel = DefaultCompressionLevel, Encoding alternateEncoding = null)
        {
            Contract.Requires(!string.IsNullOrEmpty(nodeName));
            Contract.Requires(data != null && data.Length > 0);

            var encoding = alternateEncoding ?? DefaultEncoding;

            using (var zip = new ZipFile())
            {
                using (var stream = new MemoryStream())
                {
                    zip.CompressionLevel = CompressionLevel(compressionLevel);
                    zip.AlternateEncoding = encoding;
                    zip.AlternateEncodingUsage = ZipOption.Always;
                    zip.AddEntry(nodeName, data);
                    zip.Save(stream);
                    return stream.GetBuffer();
                }
            }
        }

        public Dictionary<string, byte[]> Decompress(byte[] data, string nodeName = null, Encoding alternateEncoding = null)
        {
            Contract.Requires(data != null && data.Length > 0);

            var encoding = alternateEncoding ?? DefaultEncoding;

            using (var stream = new MemoryStream(data))
            using(var zip = ZipFile.Read(stream, new ReadOptions {Encoding = encoding}))
            {
                return zip.Where(i => nodeName == null ||
                                      string.Equals(i.FileName, nodeName, StringComparison.InvariantCultureIgnoreCase))
                          .ToDictionary(i => i.FileName, ExtractEntry);
            }
        }

        private static byte[] ExtractEntry(ZipEntry entry)
        {
            using (var tempS = new MemoryStream())
            {
                entry.Extract(tempS);
                var buffer = new byte[entry.UncompressedSize];
                tempS.Position = 0;
                tempS.Read(buffer, 0, buffer.Length);
                return buffer;
            }
        }

        /// <summary>
        /// ��������� ������ ���������
        /// </summary>
        /// <param name="level">������</param>
        /// <returns>������� ���������</returns>
        private static CompressionLevel CompressionLevel(int level)
        {
            CompressionLevel compressionLevel;
            switch (level)
            {
                case 0:
                    compressionLevel = Ionic.Zlib.CompressionLevel.None;
                    break;
                case 1:
                    compressionLevel = Ionic.Zlib.CompressionLevel.Level9;
                    break;
                case 2:
                    compressionLevel = Ionic.Zlib.CompressionLevel.Level8;
                    break;
                case 3:
                    compressionLevel = Ionic.Zlib.CompressionLevel.Level7;
                    break;
                case 4:
                    compressionLevel = Ionic.Zlib.CompressionLevel.Level6;
                    break;
                case 5:
                    compressionLevel = Ionic.Zlib.CompressionLevel.Level5;
                    break;
                case 6:
                    compressionLevel = Ionic.Zlib.CompressionLevel.Level4;
                    break;
                case 7:
                    compressionLevel = Ionic.Zlib.CompressionLevel.Level3;
                    break;
                case 8:
                    compressionLevel = Ionic.Zlib.CompressionLevel.Level2;
                    break;
                case 9:
                    compressionLevel = Ionic.Zlib.CompressionLevel.Level1;
                    break;
                case 10:
                    compressionLevel = Ionic.Zlib.CompressionLevel.Level0;
                    break;
                default:
                    compressionLevel = Ionic.Zlib.CompressionLevel.Default;
                    break;
            }
            return compressionLevel;
        }
    }
}