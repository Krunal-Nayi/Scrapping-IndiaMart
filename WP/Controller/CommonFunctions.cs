using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WP
{
    public class CommonFunctions
    {
        #region General Methods
        //public HtmlAgilityPack.HtmlDocument getHTMLDocument(String fsURLAddress)
        //{
        //    if (string.IsNullOrEmpty(fsURLAddress))
        //        return null;

        //    System.Threading.Thread.Sleep(180000); //300Sec

        //    try
        //    {
        //        if (!fsURLAddress.Contains("http"))
        //            fsURLAddress = "https:" + fsURLAddress;

        //        txtURL.Text = fsURLAddress;
        //        return new HtmlWeb().Load(fsURLAddress);
        //    }
        //    catch (Exception ex)
        //    {
        //        createLogFile(ex.Message, fsURLAddress);

        //        if (ex.Message.ToLower().Contains("Unable to connect".ToLower()) || ex.Message.ToLower().Contains("has timed out".ToLower()))
        //            System.Threading.Thread.Sleep(180000);

        //        return null;
        //    }
        //}

        public HtmlAgilityPack.HtmlDocument getHTMLDocument(String fsURLAddress)
        {
            if (string.IsNullOrEmpty(fsURLAddress))
                return null;

            try
            {
                if (!fsURLAddress.Contains("http"))
                    fsURLAddress = "https:" + fsURLAddress;

                WebClient loWebClient = new WebClient();
                WebProxy loWebProxy = new WebProxy("108.59.14.200", 13202); //Proxy Adress
                loWebProxy.Credentials = new NetworkCredential("rampatel20177@gmail.com", "123456"); //Credentials
                loWebClient.Proxy = loWebProxy;
                string lsHTMLPageString = loWebClient.DownloadString(fsURLAddress);

                HtmlAgilityPack.HtmlDocument loHtmlDocument = new HtmlAgilityPack.HtmlDocument();
                loHtmlDocument.LoadHtml(lsHTMLPageString);

                return loHtmlDocument;
            }
            catch (Exception ex)
            {
                createLogFile(ex.Message, fsURLAddress);

                //if (ex.Message.ToLower().Contains("Unable to connect".ToLower()) || ex.Message.ToLower().Contains("has timed out".ToLower()))
                //    System.Threading.Thread.Sleep(180000);

                return null;
            }
        }

        public void createLogFile(String fsLogMessage, String fsCurrentURL)
        {
            using (StreamWriter loStreamWriter = File.AppendText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/ErrorLogs.txt"))
            {
                loStreamWriter.Write("\r\nError Log Entry : ");
                loStreamWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                loStreamWriter.WriteLine("Error URL :!! {0} !!", fsCurrentURL);
                loStreamWriter.WriteLine("Log Message :{0}", fsLogMessage);
                loStreamWriter.WriteLine("//*--------------------------------------------------------------------------*//");
            }
        }

        public string getProperString(String fsOriginalString, String fsFirstReplaceString, String fsSecondReplaceString)
        {
            //loInnerTRNodeList.Where(x => x.Contains("Nature of Business".ToLower())).FirstOrDefault()
            TextInfo loTextInfo = new CultureInfo("en-US", false).TextInfo;

            if (!string.IsNullOrEmpty(fsOriginalString))
            {
                fsOriginalString = loTextInfo.ToTitleCase((fsOriginalString));

                if (!string.IsNullOrEmpty(fsFirstReplaceString))
                    fsOriginalString = loTextInfo.ToTitleCase((fsOriginalString).Replace(fsFirstReplaceString.ToLower(), string.Empty));

                if (!string.IsNullOrEmpty(fsSecondReplaceString))
                    fsOriginalString = fsOriginalString.Replace(fsSecondReplaceString.ToLower(), string.Empty);
            }
            return fsOriginalString;
        }
        #endregion
    }
}
