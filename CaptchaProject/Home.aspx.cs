using System;
using System.Drawing;
using System.Web.UI;

namespace CaptchaProject
{
    /// <summary>
    /// Home controller
    /// </summary>
    public partial class Home : Page
    {
        /// <summary>
        /// When Home page load
        /// </summary>
        /// <param name="sender">Web page</param>
        /// <param name="e">Event arguments</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            confirm.Click += new EventHandler(OnConfirmClick);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void OnConfirmClick(object sender, EventArgs e)
        {
            if (userInput.Text.Equals(Session["captchaCode"]))
            {
                Response.Redirect("User.aspx");
            } 
            else
            {
                error.Text = "Captcha invalide";
                error.ForeColor = Color.Red;
                error.Font.Size = 22;
            }
        }
    }
}