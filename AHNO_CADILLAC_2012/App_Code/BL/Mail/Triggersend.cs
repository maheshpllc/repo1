using com.exacttarget.s4.webservice;
using Microsoft.Web.Services3.Design;

/// <summary>
/// Summary description for Trigger send
/// </summary>
public class Triggersend
{
    public static string strResult = "";

    public Triggersend()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static string CustomerCodeTriggeredEmail(string strFrom, string strFromName, string strTo, string strToName, string strKeyid,
                                                    string strCouponCode, string str7DigitNumber, string strTestDrive, string strSalesPerson)
    {
        PartnerAPIWse apiCall = new PartnerAPIWse();
        //UsernameTokenProvider utp = new UsernameTokenProvider("ahnoapi", "Ahno@2010");
          UsernameTokenProvider utp = new UsernameTokenProvider("gmhioapi", "Gmholein@2011");

        apiCall.SetClientCredential(utp.GetToken());
        Policy policy = new Policy(new UsernameOverTransportAssertion());
        apiCall.SetPolicy(policy);

        apiCall.EnableDecompression = true;

        TriggeredSendDefinition tsd = new TriggeredSendDefinition();

        tsd.CustomerKey = "Cadillac_Registration_2012"; // For gm Login
        /*External Key - defined in the ExactTarget Application*/
        TriggeredSend ts = new TriggeredSend();
        ts.TriggeredSendDefinition = tsd;
        ts.Subscribers = new Subscriber[1];
        ts.Subscribers[0] = new Subscriber();
        ts.Subscribers[0].EmailAddress = strTo;
        ts.Subscribers[0].SubscriberKey = strTo;

        ts.Subscribers[0].Owner = new Owner();
        ts.Subscribers[0].Owner.FromAddress = strFrom;
        ts.Subscribers[0].Owner.FromName = strFromName;

        ts.Subscribers[0].Attributes = new com.exacttarget.s4.webservice.Attribute[7];

        ts.Subscribers[0].Attributes[0] = new com.exacttarget.s4.webservice.Attribute();
        ts.Subscribers[0].Attributes[0].Name = "Dealer Name";
        ts.Subscribers[0].Attributes[0].Value = strFromName;

        ts.Subscribers[0].Attributes[1] = new com.exacttarget.s4.webservice.Attribute();
        ts.Subscribers[0].Attributes[1].Name = "Keyid";
        ts.Subscribers[0].Attributes[1].Value = strKeyid;

        ts.Subscribers[0].Attributes[2] = new com.exacttarget.s4.webservice.Attribute();
        ts.Subscribers[0].Attributes[2].Name = "BG Couponcode";
        ts.Subscribers[0].Attributes[2].Value = strCouponCode;

        ts.Subscribers[0].Attributes[3] = new com.exacttarget.s4.webservice.Attribute();
        ts.Subscribers[0].Attributes[3].Name = "BG PIN";
        ts.Subscribers[0].Attributes[3].Value = str7DigitNumber;

        ts.Subscribers[0].Attributes[4] = new com.exacttarget.s4.webservice.Attribute();
        ts.Subscribers[0].Attributes[4].Name = "CHEVY_FULLNAME";
        ts.Subscribers[0].Attributes[4].Value = strToName;

        ts.Subscribers[0].Attributes[5] = new com.exacttarget.s4.webservice.Attribute();
        ts.Subscribers[0].Attributes[5].Name = "BG Brand Model";
        ts.Subscribers[0].Attributes[5].Value = strTestDrive;

        ts.Subscribers[0].Attributes[6] = new com.exacttarget.s4.webservice.Attribute();
        ts.Subscribers[0].Attributes[6].Name = "Salesperson Name";
        ts.Subscribers[0].Attributes[6].Value = strSalesPerson;

        string status = null;
        string requestID = null;
        CreateResult[] results = apiCall.Create(
            new CreateOptions(),
            new APIObject[] { ts },
            out requestID,
            out status
        );

        // Response.Write("<br>results[0].StatusCode: " + results[0].StatusCode + "\n");
        // Response.Write("<br>results[0].StatusMessage: " + results[0].StatusMessage + "\n");
        strResult = results[0].StatusCode;
        return strResult;
    }
}