using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiClient
{
    public class JsonHelper
    {
        public static T JsonToObject<T>(string json)
        {
            object ret = null;
            try
            {
                ret = JsonConvert.DeserializeObject(json, typeof(T));
            }
            catch (Exception e)
            {
                ret = null;
                Console.Write(e);
            }

            if (ret != null)
                return (T)ret;
            return default(T);
        }

        public static string ObjectToJson<T>(T t)
        {
            string json = "";
            try
            {
                json = JsonConvert.SerializeObject(t);
            }
            catch (Exception e)
            {
                Console.Write(e);
            }

            return json;
        }
    }
}
