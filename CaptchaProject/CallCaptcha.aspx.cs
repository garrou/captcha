using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web.UI;

namespace CaptchaProject
{
    /// <summary>
    /// Call captcha on web page 
    /// </summary>
    public partial class CallCaptcha : Page
    {
        /// <summary>
        /// Initialize captcha
        /// </summary>
        /// <param name="sender">Who throw event</param>
        /// <param name="e">Event args</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            Captcha captcha = new Captcha();
            Bitmap captchaImg = captcha.getCaptcha();
            this.Session["captchaCode"] = captcha.getCaptchaCode();
            captchaImg.Save(Response.OutputStream, ImageFormat.Png);
        }
    }
}