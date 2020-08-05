using Pharmacy.Core.Entities.Base.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Pharmacy.Core.Helpers
{
    public class SMSHelper
    {
        public static bool SendMessage(SMSServiceDTO model, bool test = false) {
            var queryParameters =
               "?handle=" + model.Handle + "&" +
               "username=" + model.Username + "&" +
               "userid=" + model.UserId + "&" +
               "msg=" + model.Message + "&" +
               "from=" + model.From + "&" +
               "to=" + model.To;

            WebAPIHelper SMSService = new WebAPIHelper(Urls.SMSBaseUrl + (test ? "testsms" : "sendsms"), queryParameters);
            HttpResponseMessage response = SMSService.GetResponse();
            var result = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode && !result.Contains("ERR"))
                return true;
            else
                return false;
        }

        public static string CheckCredit(SMSServiceDTO model)
        {
            var queryParameters =
               "?handle=" + model.Handle + "&" +
               "username=" + model.Username + "&" +
               "userid=" + model.UserId;

            WebAPIHelper SMSService = new WebAPIHelper(Urls.SMSBaseUrl + "checkcredit", queryParameters);
            HttpResponseMessage response = SMSService.GetResponse();
            return response.Content.ReadAsStringAsync().Result.Replace("OK ", String.Empty); // we got Ok status code with value from api;
        }
    }
}
