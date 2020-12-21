using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI;

namespace CaptchaProject
{
    /// <summary>
    /// Call bitmap on user page
    /// </summary>
    public partial class CallSecondCaptcha : Page
    {
        /// <summary>
        /// On page load
        /// </summary>
        /// <param name="sender">Page</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Captcha captcha = new Captcha(1);
            Bitmap captchaImg = captcha.GetCaptcha();
            captchaImg.Save(Response.OutputStream, ImageFormat.Png);
        }
    }
}