using NexusCore.Infrasructure.Adapter.Messager;

namespace NexusCore.Common.Adapter.Messager
{
    public class SmsSender : ISmsSender
    {
        public void SendSms(string from, string to, string message)
        {
            // TODO wait for service provider
            //var serviceUrl = ConfigurationManager.AppSettings["SmsServiceUrl"];
            //var username = ConfigurationManager.AppSettings["SMSUser"];
            //var password = ConfigurationManager.AppSettings["SMSPass"];

            //client.GetSingle<string>(
            //    serviceUrl,
            //    new { user = username, password = password, smsto = to, smsfrom = from, smsmsg = message });
        }
    }
}
