using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;


namespace WebApiClient
{
    public class WebClientHelper
    {
        public WebClientHelper(RequestContext context)
        {
            this.requestContext = context;
        }

        public WebClientHelper()
            : this(null)
        {
        }

        //浏览器列表
        private static string[] _browserlist = new string[] { "ie", "chrome", "mozilla", "netscape", "firefox", "opera", "konqueror" };
        //搜索引擎列表
        private static string[] _searchenginelist = new string[] { "baidu", "google", "360", "sogou", "bing", "msn", "sohu", "soso", "sina", "163", "yahoo", "jikeu" };

        private RequestContext requestContext = null;
        /// <summary>
        /// 用于MCV controller的上下文，异步情况下无法访问HttpContext.Current
        /// </summary>
        public RequestContext RequestContext
        {
            get
            {
                return requestContext;
            }
        }

        public HttpResponseBase ResponseBase
        {
            get
            {
                if (requestContext == null)
                    return null;
                else
                    return requestContext.HttpContext.Response;
            }
        }

        public NameValueCollection QueryString
        {
            get
            {
                if (requestContext != null)
                    return requestContext.HttpContext.Request.QueryString;
                return HttpContext.Current.Request.QueryString;
            }
        }

        public NameValueCollection Form
        {
            get
            {
                if (requestContext != null)
                    return requestContext.HttpContext.Request.Form;
                return HttpContext.Current.Request.Form;
            }
        }

        public RouteData RouteData
        {
            get
            {
                if (requestContext != null)
                    return requestContext.RouteData;
                return null;
            }
        }

        public NameValueCollection ServerVariables
        {
            get
            {
                if (requestContext != null)
                    return requestContext.HttpContext.Request.ServerVariables;
                return HttpContext.Current.Request.ServerVariables;
            }
        }

        #region Cookie
        public HttpCookieCollection Cookies
        {
            get
            {
                if (requestContext == null)
                    return HttpContext.Current.Request.Cookies;
                else
                    return requestContext.HttpContext.Request.Cookies;
            }
        }

        /// <summary>
        /// 删除指定名称的Cookie
        /// </summary>
        /// <param name="name">Cookie名称</param>
        public void DeleteCookie(string name)
        {
            HttpCookie cookie = new HttpCookie(name);
            cookie.Expires = DateTime.Now.AddYears(-1);
            AppendCookie(cookie);
        }

        /// <summary>
        /// 删除指定名称的Cookie
        /// </summary>
        /// <param name="name">Cookie名称</param>
        public void AppendCookie(HttpCookie cookie)
        {
            if (ResponseBase != null)
                ResponseBase.AppendCookie(cookie);
            else
                HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 获得指定名称的Cookie值
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <returns></returns>
        public string GetCookie(string name)
        {
            HttpCookie cookie = Cookies[name];
            if (cookie != null)
                return cookie.Value;

            return string.Empty;
        }

        /// <summary>
        /// 获得指定名称的Cookie中特定键的值
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string GetCookie(HttpRequestBase request, string name, string key)
        {
            HttpCookie cookie = request.Cookies[name];
            if (cookie != null && cookie.HasKeys)
            {
                string v = cookie[key];
                if (v != null)
                    return v;
            }

            return string.Empty;
        }

        /// <summary>
        /// 获得指定名称的Cookie中特定键的值
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string GetCookie(string name, string key)
        {
            HttpCookie cookie = Cookies[name];
            if (cookie != null && cookie.HasKeys)
            {
                string v = cookie[key];
                if (v != null)
                    return v;
            }
            return string.Empty;
        }

        /// <summary>
        /// 设置指定名称的Cookie的值
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="value">值</param>
        public void SetCookie(string name, string value)
        {
            HttpCookie cookie = Cookies[name];
            if (cookie != null)
                cookie.Value = value;
            else
                cookie = new HttpCookie(name, value);

            AppendCookie(cookie);
        }

        /// <summary>
        /// 设置指定名称的Cookie的值
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="value">值</param>
        /// <param name="expires">过期时间</param>
        public void SetCookie(string name, string value, double expires)
        {
            HttpCookie cookie = Cookies[name];
            if (cookie == null)
                cookie = new HttpCookie(name);

            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            AppendCookie(cookie);
        }

        /// <summary>
        /// 设置指定名称的Cookie特定键的值
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void SetCookie(string name, string key, string value)
        {
            HttpCookie cookie = Cookies[name];
            if (cookie == null)
                cookie = new HttpCookie(name);

            cookie[key] = value;
            AppendCookie(cookie);
        }

        /// <summary>
        /// 设置指定名称的Cookie特定键的值
        /// </summary>
        /// <param name="name">Cookie名称</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="expires">过期时间</param>
        public void SetCookie(string name, string key, string value, double expires)
        {
            HttpCookie cookie = Cookies[name];
            if (cookie == null)
                cookie = new HttpCookie(name);

            cookie[key] = value;
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            AppendCookie(cookie);
        }

        #endregion

        #region 客户端信息

        /// <summary>
        /// 是否是get请求
        /// </summary>
        /// <returns></returns>
        public bool IsGet()
        {
            if (requestContext != null)
                return requestContext.HttpContext.Request.HttpMethod == "GET";
            return HttpContext.Current.Request.HttpMethod == "GET";
        }

        /// <summary>
        /// 是否是post请求
        /// </summary>
        /// <returns></returns>
        public bool IsPost()
        {
            if (requestContext != null)
                return requestContext.HttpContext.Request.HttpMethod == "POST";
            return HttpContext.Current.Request.HttpMethod == "POST";
        }

        /// <summary>
        /// 是否是Ajax请求
        /// </summary>
        /// <returns></returns>
        public bool IsAjax()
        {
            if (requestContext != null)
                return requestContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return HttpContext.Current.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        public bool HasRequestKey(string key)
        {
            return QueryString[key] != null || Form[key] != null;
        }

        /// <summary>
        /// 获得查询字符串中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public string GetQueryString(string key, string defaultValue)
        {
            string value = QueryString[key];

            if (!string.IsNullOrWhiteSpace(value))
                return value;
            else
                return defaultValue;
        }

        /// <summary>
        /// 获得查询字符串中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string GetQueryString(string key)
        {
            return GetQueryString(key, "");
        }

        /// <summary>
        /// 获得查询字符串中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public int GetQueryInt(string key, int defaultValue)
        {
            return TypeHelper.StringToInt(QueryString[key], defaultValue);
        }

        /// <summary>
        /// 获得查询字符串中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public int GetQueryInt(string key)
        {
            return GetQueryInt(key, 0);
        }

        /// <summary>
        /// 获得表单中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public string GetFormString(string key, string defaultValue)
        {
            string value = Form[key];
            if (!string.IsNullOrWhiteSpace(value))
                return value;
            else
                return defaultValue;
        }

        /// <summary>
        /// 获得表单中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string GetFormString(string key)
        {
            return GetFormString(key, "");
        }

        /// <summary>
        /// 获得表单中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public int GetFormInt(string key, int defaultValue)
        {
            return TypeHelper.StringToInt(Form[key], defaultValue);
        }

        /// <summary>
        /// 获得表单中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public int GetFormInt(string key)
        {
            return GetFormInt(key, 0);
        }

        /// <summary>
        /// 获得请求中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public string GetRequestString(string key, string defaultValue)
        {
            if (Form[key] != null)
                return GetFormString(key, defaultValue);
            else
                return GetQueryString(key, defaultValue);
        }

        /// <summary>
        /// 获得路由中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public string GetRouteString(string key, string defaultValue)
        {
            object value = RouteData.Values[key];
            if (value != null)
                return value.ToString();
            else
                return defaultValue;
        }

        /// <summary>
        /// 获得路由中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string GetRouteString(string key)
        {
            return GetRouteString(key, "");
        }

        /// <summary>
        /// 获得路由中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public int GetRouteInt(string key, int defaultValue)
        {
            return TypeHelper.ObjectToInt(RouteData.Values[key], defaultValue);
        }

        /// <summary>
        /// 获得路由中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public int GetRouteInt(string key)
        {
            return GetRouteInt(key, 0);
        }

        /// <summary>
        /// 获得请求中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string GetRequestString(string key)
        {
            if (Form[key] != null)
                return GetFormString(key);
            else
                return GetQueryString(key);
        }

        /// <summary>
        /// 获得请求中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public int GetRequestInt(string key, int defaultValue)
        {
            if (Form[key] != null)
                return GetFormInt(key, defaultValue);
            else
                return GetQueryInt(key, defaultValue);
        }

        /// <summary>
        /// 获得请求中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public int GetRequestInt(string key)
        {
            if (Form[key] != null)
                return GetFormInt(key);
            else
                return GetQueryInt(key);
        }


        /// <summary>
        /// 获得上次请求的url
        /// </summary>
        /// <returns></returns>
        public string GetUrlReferrer()
        {
            Uri uri = null;
            if (requestContext != null)
                uri = requestContext.HttpContext.Request.UrlReferrer;
            else
                uri = HttpContext.Current.Request.UrlReferrer;
            if (uri == null)
                return string.Empty;

            return uri.ToString();
        }

        /// <summary>
        /// 获得请求的主机部分
        /// </summary>
        /// <returns></returns>
        public string GetHost()
        {
            if (requestContext != null)
                return requestContext.HttpContext.Request.Url.Host;
            return HttpContext.Current.Request.Url.Host;
        }

        /// <summary>
        /// 获得请求的url
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            if (requestContext != null)
                return requestContext.HttpContext.Request.Url.ToString();
            return HttpContext.Current.Request.Url.ToString();
        }

        /// <summary>
        /// 获得请求的原始url
        /// </summary>
        /// <returns></returns>
        public string GetRawUrl()
        {
            if (requestContext != null)
                return requestContext.HttpContext.Request.RawUrl;
            return HttpContext.Current.Request.RawUrl;
        }

        /// <summary>
        /// 获得请求的ip
        /// </summary>
        /// <returns></returns>
        public string GetIP()
        {
            string ip = string.Empty;
            if (ServerVariables["HTTP_VIA"] != null)
                ip = ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            else
                ip = ServerVariables["REMOTE_ADDR"].ToString();

            if (string.IsNullOrEmpty(ip) || !ValidateHelper.IsIP(ip))
                ip = "127.0.0.1";
            return ip;
        }

        /// <summary>
        /// 获得请求的浏览器类型
        /// </summary>
        /// <returns></returns>
        public string GetBrowserType()
        {
            string type = null;
            if (requestContext != null)
                type = requestContext.HttpContext.Request.Browser.Type;
            else
                type = HttpContext.Current.Request.Browser.Type;

            if (string.IsNullOrEmpty(type) || type == "unknown")
                return "未知";

            return type.ToLower();
        }

        /// <summary>
        /// 获得请求的浏览器名称
        /// </summary>
        /// <returns></returns>
        public string GetBrowserName()
        {
            string name = null;
            if (requestContext != null)
                name = requestContext.HttpContext.Request.Browser.Browser;
            else
                name = HttpContext.Current.Request.Browser.Browser;

            if (string.IsNullOrEmpty(name) || name == "unknown")
                return "未知";

            return name.ToLower();
        }

        /// <summary>
        /// 获得请求的浏览器类型
        /// </summary>
        /// <returns></returns>
        public string GetBrowserType(HttpRequest request)
        {
            string type = request == null ? string.Empty : request.Browser.Type;
            if (string.IsNullOrEmpty(type) || type == "unknown")
                return "未知";

            return type.ToLower();
        }

        /// <summary>
        /// 获得请求的浏览器名称
        /// </summary>
        /// <returns></returns>
        public string GetBrowserName(HttpRequest request)
        {
            string name = request == null ? string.Empty : request.Browser.Browser;
            if (string.IsNullOrEmpty(name) || name == "unknown")
                return "未知";

            return name.ToLower();
        }


        /// <summary>
        /// 获得请求的浏览器版本
        /// </summary>
        /// <returns></returns>
        public string GetBrowserVersion()
        {
            string version = null;

            if (requestContext != null)
                version = requestContext.HttpContext.Request.Browser.Version;
            else
                version = HttpContext.Current.Request.Browser.Version;

            if (string.IsNullOrEmpty(version) || version == "unknown")
                return "未知";

            return version;
        }

        /// <summary>
        /// 获得请求客户端的操作系统类型
        /// </summary>
        /// <returns></returns>
        public string GetOSType(string userAgent)
        {
            string type = null;
            if (userAgent.Contains("NT 6.1"))
                type = "Windows 7";
            else if (userAgent.Contains("NT 5.1"))
                type = "Windows XP";
            else if (userAgent.Contains("NT 6.2"))
                type = "Windows 8";
            else if (userAgent.Contains("android"))
                type = "Android";
            else if (userAgent.Contains("iphone"))
                type = "IPhone";
            else if (userAgent.Contains("Mac"))
                type = "Mac";
            else if (userAgent.Contains("NT 6.0"))
                type = "Windows Vista";
            else if (userAgent.Contains("NT 5.2"))
                type = "Windows 2003";
            else if (userAgent.Contains("NT 5.0"))
                type = "Windows 2000";
            else if (userAgent.Contains("98"))
                type = "Windows 98";
            else if (userAgent.Contains("95"))
                type = "Windows 95";
            else if (userAgent.Contains("Me"))
                type = "Windows Me";
            else if (userAgent.Contains("NT 4"))
                type = "Windows NT4";
            else if (userAgent.Contains("Unix"))
                type = "UNIX";
            else if (userAgent.Contains("Linux"))
                type = "Linux";
            else if (userAgent.Contains("SunOS"))
                type = "SunOS";
            else
                type = "未知";

            return type;
        }

        /// <summary>
        /// 获得请求客户端的操作系统类型
        /// </summary>
        /// <returns></returns>
        public string GetOSType()
        {
            string ret = null;

            if (requestContext != null)
                ret = requestContext.HttpContext.Request.UserAgent;
            else
                ret = HttpContext.Current.Request.UserAgent;

            if (string.IsNullOrEmpty(ret) || ret == "unknown")
                return "未知";

            return GetOSType(ret);
        }

        /// <summary>
        /// 获得请求客户端的操作系统名称
        /// </summary>
        /// <returns></returns>
        public string GetOSName()
        {
            string ret = null;

            if (requestContext != null)
                ret = requestContext.HttpContext.Request.Browser.Platform;
            else
                ret = HttpContext.Current.Request.Browser.Platform;

            if (string.IsNullOrEmpty(ret) || ret == "unknown")
                return "未知";

            return ret;
        }

        /// <summary>
        /// 判断是否是浏览器请求
        /// </summary>
        /// <returns></returns>
        public bool IsBrowser()
        {
            string name = GetBrowserName();
            foreach (string item in _browserlist)
            {
                if (name.Contains(item))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 是否是移动设备请求
        /// </summary>
        /// <returns></returns>
        public bool IsMobile()
        {
            if (requestContext != null)
            {
                if (requestContext.HttpContext.Request.Browser.IsMobileDevice)
                    return true;

                bool isTablet = false;
                if (bool.TryParse(requestContext.HttpContext.Request.Browser["IsTablet"], out isTablet) && isTablet)
                    return true;
            }
            else
            {
                if (HttpContext.Current.Request.Browser.IsMobileDevice)
                    return true;

                bool isTablet = false;
                if (bool.TryParse(HttpContext.Current.Request.Browser["IsTablet"], out isTablet) && isTablet)
                    return true;
            }


            return false;
        }

        /// <summary>
        /// 判断是否是搜索引擎爬虫请求
        /// </summary>
        /// <returns></returns>
        public bool IsCrawler()
        {
            bool result = false;
            if (requestContext != null)
                result = requestContext.HttpContext.Request.Browser.Crawler;
            else
                result = HttpContext.Current.Request.Browser.Crawler;
            if (!result)
            {
                string referrer = GetUrlReferrer();
                if (referrer.Length > 0)
                {
                    foreach (string item in _searchenginelist)
                    {
                        if (referrer.Contains(item))
                            return true;
                    }
                }
            }
            return result;
        }

        #endregion
    }
}
