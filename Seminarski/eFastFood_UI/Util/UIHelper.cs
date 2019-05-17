using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace eFastFood_UI.Util
{
    public static class UIHelper
    {
        #region ResizeImage
        public static Image ResizeImage(Image imgToResize, Size size)
        {
            int sourceWidth = imgToResize.Width;
            int sourceHeight = imgToResize.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)size.Width / (float)sourceWidth);
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return (Image)b;
        }
        #endregion

        #region AddDefaultPicture
        public static byte[] AddDefaultPictureFull()
        {
            Image orgImg;

            MemoryStream ms = new MemoryStream();
            orgImg = Properties.Resources._default;
            orgImg.Save(ms, ImageFormat.Jpeg);

            return ms.ToArray();
        }

        public static byte[] AddDefaultPictureResized()
        {
            Image resizedImg;

            MemoryStream ms = new MemoryStream();
            resizedImg = ResizeImage(Properties.Resources._default, new Size(Global.ResizeWidth, Global.ResizeHeight));
            resizedImg.Save(ms, ImageFormat.Jpeg);

            return ms.ToArray();
        }

        #endregion

        #region PictureFromFile
        public static byte[] AddFromFileFull(string path)
        {
            Image orgImg = Image.FromFile(path);

            MemoryStream ms = new MemoryStream();
            orgImg.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static byte[] AddFromFileResized(string path)
        {
            Image image = Image.FromFile(path);

            Image resizedImg = ResizeImage(image, new Size(Global.ResizeWidth, Global.ResizeHeight));
            MemoryStream ms = new MemoryStream();
            resizedImg.Save(ms, ImageFormat.Jpeg);

            return ms.ToArray();
        }
        #endregion

        #region Hashing

        public static string GenerateSalt()
        {
            var buf = new byte[16];
            (new RNGCryptoServiceProvider()).GetBytes(buf);
            return Convert.ToBase64String(buf);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        #endregion
    }
}
