using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using PCLCrypto;
using System.Text;

namespace eFastFood_PCL.Util
{
    public static class UIHelper
    {
        #region Hashing

        public static string GenerateSalt()
        {
            var buf = WinRTCrypto.CryptographicBuffer.GenerateRandom(16);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            var algorithm = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha1);
            byte[] inArray = algorithm.HashData(dst);
            return Convert.ToBase64String(inArray);
        }

        #endregion
    }
}
