using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

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
    }
}
