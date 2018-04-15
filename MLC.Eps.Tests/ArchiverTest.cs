using FluentAssertions;
using NUnit.Framework;

namespace MLC.Eps.Tests
{
    [TestFixture]
    public class ArchiverTest
    {
        [Test]
        public void SmokeTest()
        {
            var fileName = "TestFile.txt";
            var sourceStr = "Simple text";
            var sourceBytes = GetBytes(sourceStr);
            var archiver = new Archiver();

            var compressBytes = archiver.Archive(sourceBytes, fileName);
            var decompressBytes = archiver.Decompress(compressBytes, fileName);

            var resString = GetString(decompressBytes[fileName]);
            resString.ShouldBeEquivalentTo(sourceStr);
        }

        private static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
