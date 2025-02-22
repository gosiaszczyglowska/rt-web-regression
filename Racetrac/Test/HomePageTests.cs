using Microsoft.VisualBasic.FileIO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Net.WebRequestMethods;

namespace Racetrac.Test
{
    public class HomePageTests : TestBase
    {


        [TestCase("Facebook")]
        [TestCase("Instagram")]
        [TestCase("LinkedIn")]
        [TestCase("Twitter")]
        [TestCase("TikTok")]

        public void CheckLinksToSocialServices(string socialNetwork)
        {
            home.AcceptCookies();
            home.ClickSocialNetworkIcon(socialNetwork);

            bool issocialNetowrkUrlCorrect = home.IsSocialNetworkUrlCorrect(socialNetwork);

            Assert.IsTrue(issocialNetowrkUrlCorrect, $"Expected URL for {socialNetwork} is not correct");
        }
       

    }
}