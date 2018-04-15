using System.Security.Cryptography;
using System.Text;

namespace MLC.Wms.Common.Helpers
{
    public static class HashHelper
    {
        /// <summary>
        /// Creates hash data of SHA512
        /// </summary>
        /// <param name="data">Input string</param>
        /// <returns>Return the hexadecimal string</returns>
        public static string Sha512(string data)
        {
            byte[] hash = null;
            using (var shaM = new SHA512Managed())
            {
                hash = shaM.ComputeHash(Encoding.UTF8.GetBytes(data));
            }
            var sBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sBuilder.Append(hash[i].ToString("x2"));
            }
            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
    }
}
