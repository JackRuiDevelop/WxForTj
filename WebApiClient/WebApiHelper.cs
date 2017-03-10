using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public class WebApiHelper
    {
       // private string _WebApiServiceUrl = ConfigurationManager.AppSettings["WebApiServiceUrl"];

        public T GetHttpRequest<T>(string controller, string action, Dictionary<string, string> paras)
        {
            string url = "http://127.0.0.1";
            url += string.Format("/{0}/{1}", controller, action);
            string strParas = "";
            foreach (var item in paras)
            {
                if (string.IsNullOrEmpty(strParas))
                {
                    strParas += string.Format("?{0}={1}", item.Key, item.Value);
                }
                else
                {
                    strParas += string.Format("&{0}={1}", item.Key, item.Value);
                }
            }
            url += strParas;
            string jsonResponse = getHttpWebResponse(url);

            return JsonHelper.JsonToObject<T>(jsonResponse);
        }

        public T PostHttpRequest<T, D>(string controller, string action, D parms)
        {
            string url = "http://127.0.0.1";
            url += string.Format("/{0}/{1}", controller, action);
            string jsonRequest = JsonHelper.ObjectToJson<D>(parms);
            string jsonResponse = postHttpWebResponse(url, jsonRequest);

            return JsonHelper.JsonToObject<T>(jsonResponse);
        }

        public string postHttpWebResponse(string url, string json)
        {
            string ret = string.Empty;
            try
            {
                ret = WebHelper.GetRequestData(url, "post", json, Encoding.UTF8, 20000, "application/json");
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ret;
        }

        public string getHttpWebResponse(string url)
        {
            string ret = string.Empty;
            ret = WebHelper.GetRequestData(url, "get", string.Empty, Encoding.UTF8, 20000, "application/json");

            return ret;
        }

    }
}
