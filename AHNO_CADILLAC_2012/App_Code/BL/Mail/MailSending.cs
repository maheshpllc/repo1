using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Net.Mail;
using System.Web.Mail;

/// <summary>
/// Summary description for MailSending
/// </summary>
public class MailSending
{
	public MailSending()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static string SendMail(string mailTo, string mailCc, string mailBcc, string mailFrom, string mailSubj, string mailBody)
    {
        string msg = "";
        string[] To = mailTo.Split(',');
        string[] Cc = mailCc.Split(',');
        string[] Bcc = mailBcc.Split(',');
        int i=0;
        System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
        SmtpClient mailServer = new SmtpClient(ConfigurationManager.AppSettings["MailServer"].ToString());
        try
        {
            //if (To.Length >= 1 && mailTo != "")
            //{
            //    for (i = 0; i <= To.Length - 1; i++)
            //    {
            //        mail.To.Add(To[i].ToString());
            //    }
            //}

            //if (Cc.Length >= 1 && mailCc != "")
            //{
            //    for (i = 0; i <= Cc.Length - 1; i++)
            //    {
            //        mail.CC.Add(Cc[i].ToString());
            //    }
            //}

            //if (Bcc.Length >= 1 && mailBcc != "")
            //{
            //    for (i = 0; i <= Bcc.Length - 1; i++)
            //    {
            //        mail.Bcc.Add(Bcc[i].ToString());
            //    }
            //}

               mail.From = mailFrom;
               mail.To = mailTo;
               mail.Cc = mailCc;
               mail.Subject = mailSubj;
               mail.Body = mailBody;
               mail.BodyFormat = MailFormat.Html;
               mail.Priority = System.Web.Mail.MailPriority.High;

               try
               {
                      SmtpMail.SmtpServer = ConfigurationManager.AppSettings["MailServer"].ToString();
                      SmtpMail.Send(mail);
                      msg = "1";
               }
               catch (Exception ex)
               {
                      msg = "0";
               }
           
        }
        catch(Exception ex)
        {
            msg = ex.ToString();
            //msg = "Problem Occured While Sending Mail. Please Try Again";
        }
        return msg;

    }

}
