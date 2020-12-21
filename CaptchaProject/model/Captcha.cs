using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;

namespace CaptchaProject
{
    /// <summary>
    /// Create a captcha
    /// </summary>
    public class Captcha
    {
        #region Fields & Properties

        /// <summary>
        /// Captcha image
        /// </summary>
        private Bitmap captcha;

        /// <summary>
        /// Captcha code
        /// </summary>
        private string captchaCode;

        /// <summary>
        /// To draw on captcha
        /// </summary>
        private Graphics objGraphics;

        /// <summary>
        /// Number of circles in letters
        /// </summary>
        private const int CirclesNumber = 200;

        /// <summary>
        /// Captcha code length
        /// </summary>
        private const int CaptchaCodeLength = 6;

        /// <summary>
        /// Captcha width
        /// </summary>
        private const int CaptchaWidth = CaptchaCodeLength * 42;

        /// <summary>
        /// Captcha height
        /// </summary>
        private const int CaptchaHeight = 80;

        /// <summary>
        /// Captcha code max font size
        /// </summary>
        private const int MaxFontSize = 40;

        /// <summary>
        /// Captcha code min font size
        /// </summary>
        private const int MinFontSize = 10;

        /// <summary>
        /// Available letters in captcha code
        /// </summary>
        private const string Characters = "2346789ABCDEFGHJKLMNPRTUVWXYZ";

        /// <summary>
        /// Spacing between letters
        /// </summary>
        private const int Spacing = 20;

        #endregion Fields & Properties

        #region Constructeur

        /// <summary>
        /// Create captcha
        /// </summary>
        /// <param name="mode">0 or 1, differens designs of captcha</param>
        public Captcha(int mode = 0)
        {
            this.CreateCaptcha();
            if (mode == 1)
            {
                this.DrawCaptchaCode();
            } 
            else
            {
                this.DrawCaptchaCodeEllipse();
            }
        }

        #endregion

        #region Privates methods

        /// <summary>
        /// Build captcha
        /// </summary>
        private void CreateCaptcha()
        {
            try
            {
                this.captcha = new Bitmap(CaptchaWidth, CaptchaHeight);
                this.objGraphics = Graphics.FromImage(this.captcha);
                this.objGraphics.Clear(Color.White);
                this.GenerateCaptchaCode();
                this.DrawBackground();
            }
            catch (Exception ex)
            {
                throw new Exception("Error during captcha generation.", ex);
            }
        }

        /// <summary>
        /// Génère le code captcha
        /// </summary>
        private void GenerateCaptchaCode()
        {
            Random rand = new Random();
            StringBuilder sb = new StringBuilder();
            int maxRand = Characters.Length - 1;
            int index;

            for (int i = 0; i < CaptchaCodeLength; i++)
            {
                index = rand.Next(maxRand);
                sb.Append(Characters[index]);
            }

            this.captchaCode = sb.ToString();
        }

        /// <summary>
        /// Write captcha code
        /// </summary>
        private void DrawCaptchaCode()
        {
            Random rand = new Random();
            string[] fonts =
            {
                "Andy",
                "Agency FB",
                "Andalus",
                "Aparajita",
                "Century Gothic",
                "Segoe UI Black",
                "Showcard Gothic"
            };
            FontStyle[] fontStyles =
            {
                FontStyle.Italic,
                FontStyle.Bold,
                FontStyle.Regular,
                FontStyle.Strikeout
            };

            float rotate = 30.0F;
            int x = 5, y = CaptchaHeight / 5;

            for (int i = 0; i < CaptchaCodeLength; i++)
            {
                Font font = new Font(fonts[rand.Next(0, fonts.Length - 1)],
                    rand.Next(MinFontSize, MaxFontSize),
                    fontStyles[rand.Next(0, fontStyles.Length - 1)]);
                SolidBrush brush = new SolidBrush(Color.FromArgb(rand.Next(60, 160),
                    rand.Next(60, 160),
                    rand.Next(60, 160)));

                x += Spacing + (Spacing / 2);

                this.objGraphics.RotateTransform(rotate);
                this.objGraphics.DrawString(captchaCode[i].ToString(), font, brush, x, y);
                this.objGraphics.RotateTransform(-rotate);
                rotate *= -0.5F;
            }
        }

        /// <summary>
        /// Write captcha code with circles
        /// </summary>
        private void DrawCaptchaCodeEllipse()
        {
            Font font = new Font("Agency FB", MaxFontSize, FontStyle.Italic);
            GraphicsPath path = new GraphicsPath();
            StringFormat stringFormat = new StringFormat();
            Random rand = new Random();
            int x, y, maxY, shiftPx, radius;

            for (int i = 0; i < CaptchaCodeLength; i++)
            {
                shiftPx = MaxFontSize / 8;
                x = (i * MaxFontSize) + (rand.Next(-shiftPx, shiftPx) * 2);
                maxY = CaptchaHeight - MaxFontSize;
                y = rand.Next(0, maxY);

                path.AddString(captchaCode[i].ToString(),
                        font.FontFamily,
                        (int)font.Style,
                        font.Size,
                        new Point(x, y),
                        stringFormat);
            }

            Region clipRegion = new Region(path);

            objGraphics.Clip = clipRegion;

            // fill letters
            for (int i = 1; i < CirclesNumber; i++)
            {
                radius = 20;
                x = rand.Next(0, CaptchaWidth);
                y = rand.Next(0, CaptchaHeight);
                Brush brush = new SolidBrush(Color.FromArgb(166, 166, 166));

                this.objGraphics.FillEllipse(brush, x, y, 2 * radius, 2 * radius);
            }

            this.objGraphics.ResetClip();
        }

        /// <summary>
        /// Draw captcha background
        /// </summary>
        private void DrawBackground()
        {
            Pen pen = new Pen(Color.Aqua, 2);
            Random rand = new Random();

            for (int xPix = 0; xPix < this.captcha.Width; xPix += 5)
            {
                for (int yPix = 0; yPix < this.captcha.Height; yPix += 5)
                {
                    this.objGraphics.DrawEllipse(pen, xPix, yPix, 2, 2);
                    pen.Color = Color.FromArgb(79, 194, 214);
                }
            }
        }

        #endregion Privates methods

        #region Publics methods

        /// <summary>
        /// Return captcha image
        /// </summary>
        /// <returns>Captcha image</returns>
        public Bitmap getCaptcha()
        {
            return this.captcha;
        }

        /// <summary>
        /// Return captcha code
        /// </summary>
        /// <returns>Captcha code</returns>
        public string getCaptchaCode()
        {
            return this.captchaCode;
        }
        #endregion Publics methods
    }
}