using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebApiClient;

namespace WebApiClient
{
    public partial class Utils
    {
        private static object _locker = new object();//锁对象

        #region  加密/解密

        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="encryptStr">加密字符串</param>
        public static string AESEncrypt(string encryptStr)
        {
            return SecureHelper.AESEncrypt(encryptStr, "ytsoft");
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="decryptStr">解密字符串</param>
        public static string AESDecrypt(string decryptStr)
        {
            return SecureHelper.AESDecrypt(decryptStr, "ytsoft");
        }

        #endregion

        #region Cookie

        #region UserId
        /// <summary>
        /// 获得用户UserId
        /// </summary>
        /// <returns></returns>
        public static string GetUserIdCookie(WebClientHelper helper)
        {
            return GetBMACookie(helper, "UserId");
        }

        /// <summary>
        /// 设置用户UserId
        /// </summary>
        public static void SetUserIdCookie(WebClientHelper helper, string UserId)
        {
            SetBMACookie(helper, "UserId", UserId);
        }
        #endregion

        #region DDUserId
        /// <summary>
        /// 获得用户DDUserId
        /// </summary>
        /// <returns></returns>
        public static string GetDDUserIdCookie(WebClientHelper helper)
        {
            return GetBMACookie(helper, "DDUserId");
        }

        /// <summary>
        /// 设置用户DDUserId
        /// </summary>
        public static void SetDDUserIdCookie(WebClientHelper helper, string DDUserId)
        {
            SetBMACookie(helper, "DDUserId", DDUserId);
        }
        #endregion

        #region PassWord
        /// <summary>
        /// 解密cookie密码
        /// </summary>
        /// <param name="cookiePassword">cookie密码</param>
        /// <returns></returns>
        public static string DecryptCookiePassword(string cookiePassword)
        {
            return AESDecrypt(cookiePassword).Trim();
        }

        /// <summary>
        /// 设置cookie密码
        /// </summary>
        public static void SetCookiePassword(WebClientHelper helper, string PassWord)
        {
            SetBMACookie(helper, "PassWord", WebHelper.UrlEncode(AESEncrypt(PassWord)));
        }
        /// <summary>
        /// 获得cookie密码
        /// </summary>
        /// <returns></returns>
        public static string GetCookiePassword(WebClientHelper helper)
        {
            return WebHelper.UrlDecode(GetBMACookie(helper, "PassWord"));
        }
        #endregion

        #region UserName
        /// <summary>
        /// 获得用户UserName
        /// </summary>
        /// <returns></returns>
        public static string GetUserNameCookie(WebClientHelper helper)
        {
            return GetBMACookie(helper, "UserName");
        }

        /// <summary>
        /// 设置用户UserName值
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="guid"></param>
        public static void setUserNameCookie(WebClientHelper helper, string UserName)
        {
            SetBMACookie(helper, "UserName", UserName);
        }
        #endregion

        #region UserJob
        /// <summary>
        /// 获得用户UserJob
        /// </summary>
        /// <returns></returns>
        public static string GetUserJobCookie(WebClientHelper helper)
        {
            return GetBMACookie(helper, "UserJob");
        }

        /// <summary>
        /// 设置用户UserJob值
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="guid"></param>
        public static void setUserJobCookie(WebClientHelper helper, string UserJob)
        {
            SetBMACookie(helper, "UserJob", UserJob);
        }
        #endregion

        #region DDJob
        /// <summary>
        /// 设置DDJob
        /// </summary>
        public static void SetDDJobCookie(WebClientHelper helper, string DDJob)
        {
            SetBMACookie(helper, "DDJob", DDJob);
        }

        /// <summary>
        /// 获得DDJob
        /// </summary>
        /// <returns></returns>
        public static string GetDDJobCookie(WebClientHelper helper)
        {
            return GetBMACookie(helper, "DDJob");
        }
        #endregion

        #region UserDept
        /// <summary>
        /// 获得用户UserDept
        /// </summary>
        /// <returns></returns>
        public static string GetUserDeptCookie(WebClientHelper helper)
        {
            return GetBMACookie(helper, "UserDept");
        }

        /// <summary>
        /// 设置用户UserDept值
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="guid"></param>
        public static void setUserDeptCookie(WebClientHelper helper, string UserDept)
        {
            SetBMACookie(helper, "UserDept", UserDept);
        }
        #endregion

        #region DDdept
        /// <summary>
        /// 设置DDdept
        /// </summary>
        public static void SetDDdeptCookie(WebClientHelper helper, string DDdept)
        {
            SetBMACookie(helper, "DDdept", DDdept);
        }

        /// <summary>
        /// 获得DDdept
        /// </summary>
        /// <returns></returns>
        public static string GetDDdeptCookie(WebClientHelper helper)
        {
            return GetBMACookie(helper, "DDdept");
        }
        #endregion

        #region Mobile
        /// <summary>
        /// 设置用户Mobile
        /// </summary>
        public static void SetMobileCookie(WebClientHelper helper, string Mobile)
        {
            SetBMACookie(helper, "Mobile", Mobile);
        }
        /// <summary>
        /// 获得用户Mobile
        /// </summary>
        /// <returns></returns>
        public static string GetMobileCookie(WebClientHelper helper)
        {
            return GetBMACookie(helper, "Mobile");
        }
        #endregion

        #region Frim
        /// <summary>
        /// 设置Frim
        /// </summary>
        public static void SetFrimCookie(WebClientHelper helper, string Frim)
        {
            SetBMACookie(helper, "Frim", Frim);
        }

        /// <summary>
        /// 获得Frim
        /// </summary>
        /// <returns></returns>
        public static string GetFrimCookie(WebClientHelper helper)
        {
            return GetBMACookie(helper, "Frim");
        }
        #endregion

        #region DDFrim
        /// <summary>
        /// 设置DDFrim
        /// </summary>
        public static void SetDDFrimCookie(WebClientHelper helper, string DDFrim)
        {
            SetBMACookie(helper, "DDFrim", DDFrim);
        }

        /// <summary>
        /// 获得DDFrim
        /// </summary>
        /// <returns></returns>
        public static string GetDDFrimCookie(WebClientHelper helper)
        {
            return GetBMACookie(helper, "DDFrim");
        }
        #endregion

        #region OpenId
        /// <summary>
        /// 获得用户OpenId
        /// </summary>
        /// <returns></returns>
        public static string GetOpenIdCookie(WebClientHelper helper)
        {
            return GetBMACookie(helper, "OpenId");
        }

        /// <summary>
        /// 设置用户OpenId值
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="guid"></param>
        public static void setOpenIdCookie(WebClientHelper helper, string OpenId)
        {
            SetBMACookie(helper, "OpenId", OpenId);
        }
        #endregion

        #region Token
        /// <summary>
        /// 设置用户Token
        /// </summary>
        public static void SetTokenCookie(WebClientHelper helper, string Token)
        {
            SetBMACookie(helper, "Token", Token);
        }
        /// <summary>
        /// 获得用户Token
        /// </summary>
        /// <returns></returns>
        public static string GetTokenCookie(WebClientHelper helper)
        {
            return GetBMACookie(helper, "Token");
        }
        #endregion

        #region AgentId
        /// <summary>
        /// 设置AgentId
        /// </summary>
        public static void SetAgentIdCookie(WebClientHelper helper, string AgentId)
        {
            SetBMACookie(helper, "AgentId", AgentId);
        }

        /// <summary>
        /// 获得AgentId
        /// </summary>
        /// <returns></returns>
        public static string GetAgentIdCookie(WebClientHelper helper)
        {
            return GetBMACookie(helper, "AgentId");
        }
        #endregion

        #region AccessToken
        /// <summary>
        /// 设置AccessToken
        /// </summary>
        public static void SetAccessTokenCookie(WebClientHelper helper, string AccessToken)
        {
            SetBMACookie(helper, "AccessToken", AccessToken);
        }

        /// <summary>
        /// 获得AccessToken
        /// </summary>
        /// <returns></returns>
        public static string GetAccessTokenCookie(WebClientHelper helper)
        {
            return GetBMACookie(helper, "AccessToken");
        }
        #endregion

        #region SsoToken
        /// <summary>
        /// 获得用户SsoToken
        /// </summary>
        /// <returns></returns>
        public static string GetSsoTokenCookie(WebClientHelper helper)
        {
            return GetBMACookie(helper, "SsoToken");
        }

        /// <summary>
        /// 设置用户SsoToken值
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="guid"></param>
        public static void setSsoTokenCookie(WebClientHelper helper, string SsoToken)
        {
            SetBMACookie(helper, "SsoToken", SsoToken);
        }
        #endregion

        #region UnionId
        /// <summary>
        /// 设置用户UnionId
        /// </summary>
        public static void SetUnionIdCookie(WebClientHelper helper, string UnionId)
        {
            SetBMACookie(helper, "UnionId", UnionId);
        }
        /// <summary>
        /// 获得用户UnionId
        /// </summary>
        /// <returns></returns>
        public static string GetUnionIdCookie(WebClientHelper helper)
        {
            return GetBMACookie(helper, "UnionId");
        }
        #endregion

        /// <summary>
        /// 设置用户
        /// </summary>
        /// <param name="uid">用户id</param>
        /// <param name="password">密码</param>
        /// <param name="expires">过期时间</param>
        //public static void SetUserCookie(WebClientHelper helper, UserInfo info, int expires)
        //{
        //    HttpCookie cookie = helper.Cookies["yt"];
        //    if (cookie == null)
        //        cookie = new HttpCookie("yt");

        //    cookie.Values["UserId"] = info.UserId;
        //    cookie.Values["DDUserId"] = info.DDUserId;
        //    cookie.Values["PassWord"] = WebHelper.UrlEncode(AESEncrypt(info.PassWord));
        //    cookie.Values["UserName"] = info.UserName;
        //    cookie.Values["UserJob"] = info.UserJob;
        //    cookie.Values["DDJob"] = info.DDJob;
        //    cookie.Values["UserDept"] = info.UserDept;
        //    cookie.Values["DDdept"] = info.DDdept;
        //    cookie.Values["Mobile"] = info.Mobile;
        //    cookie.Values["Frim"] = info.Frim;
        //    cookie.Values["DDFrim"] = info.DDFrim;
        //    cookie.Values["OpenId"] = info.OpenId;
        //    cookie.Values["Token"] = info.Token;
        //    cookie.Values["AgentId"] = info.AgentId;
        //    cookie.Values["AccessToken"] = info.AccessToken;
        //    cookie.Values["SsoToken"] = info.SsoToken;
        //    cookie.Values["UnionId"] = info.UnionId;

        //    if (expires > 0)
        //    {
        //        cookie.Values["expires"] = expires.ToString();
        //        cookie.Expires = DateTime.Now.AddDays(expires);
        //    }
        //    //string cookieDomain = MallConfig.CookieDomain;
        //    //if (cookieDomain.Length != 0)
        //    //    cookie.Domain = cookieDomain;

        //    helper.AppendCookie(cookie);
        //}

        public static void RemoveUserCookie(WebClientHelper helper)
        {
            HttpCookie cookie = helper.Cookies["yt"];
            if (cookie == null)
                cookie = new HttpCookie("yt");
            cookie.Expires = DateTime.Now.AddYears(-1);
            //string cookieDomain = MallConfig.CookieDomain;
            //if (cookieDomain.Length != 0)
            //    cookie.Domain = cookieDomain;

            helper.AppendCookie(cookie);
        }

        /// <summary>
        /// 获得cookie
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetBMACookie(WebClientHelper helper, string key)
        {
            return helper.GetCookie("yt", key);
        }

        /// <summary>
        /// 设置cookie
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public static void SetBMACookie(WebClientHelper helper, string key, string value)
        {
            HttpCookie cookie = helper.Cookies["yt"];
            if (cookie == null)
                cookie = new HttpCookie("yt");

            cookie[key] = value;

            int expires = TypeHelper.StringToInt(cookie.Values["expires"]);
            if (expires > 0)
                cookie.Expires = DateTime.Now.AddDays(expires);

            //string cookieDomain = MallConfig.CookieDomain;
            //if (cookieDomain.Length != 0)
            //    cookie.Domain = cookieDomain;

            helper.AppendCookie(cookie);
        }

        /// <summary>
        /// 获得访问referer
        /// </summary>
        public static string GetRefererCookie(WebClientHelper helper)
        {
            string referer = WebHelper.UrlDecode(helper.GetCookie("referer"));
            if (referer.Length == 0)
                referer = "/";
            return referer;
        }

        /// <summary>
        /// 设置访问referer
        /// </summary>
        public static void SetRefererCookie(WebClientHelper helper, string url)
        {
            helper.SetCookie("referer", WebHelper.UrlEncode(url));
        }

        /// <summary>
        /// 获得系统后台访问referer
        /// </summary>
        //public static string GetMallAdminRefererCookie(WebClientHelper helper)
        //{
        //    return GetAdminRefererCookie(helper, "/malladmin/home/mallruninfo");
        //}

        ///// <summary>
        ///// 获得店铺后台访问referer
        ///// </summary>
        //public static string GetStoreAdminRefererCookie(WebClientHelper helper)
        //{
        //    return GetAdminRefererCookie(helper, "/storeadmin/home/storeruninfo");
        //}

        /// <summary>
        /// 获得后台访问referer
        /// </summary>
        public static string GetAdminRefererCookie(WebClientHelper helper, string defaultUrl)
        {
            string adminReferer = WebHelper.UrlDecode(helper.GetCookie("adminreferer"));
            if (adminReferer.Length == 0)
                adminReferer = defaultUrl;
            return adminReferer;
        }

        /// <summary>
        /// 设置后台访问referer
        /// </summary>
        public static void SetAdminRefererCookie(WebClientHelper helper, string url)
        {
            helper.SetCookie("adminreferer", WebHelper.UrlEncode(url));
        }

        #endregion
    }
}
