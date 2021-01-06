using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace NewPortalAssiant.Net
{
    public class RequestMothed
    {
        public static string pageSource = string.Empty;

        public static string Current_Cookie;

        public static string cuteCookies;

        public static string GetLoginMethod(string uri, string host)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
            request.ServicePoint.Expect100Continue = false;//加快载入速度
            request.ServicePoint.UseNagleAlgorithm = false;//禁止Nagle算法加快载入速度
            request.AllowWriteStreamBuffering = false;//禁止缓冲加快载入速度
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");//定义gzip压缩页面支持
            request.ContentType = "application/x-www-form-urlencoded";//定义文档类型及编码
            request.AllowAutoRedirect = true;//禁止自动跳转
            //设置User-Agent，伪装成Google Chrome浏览器
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            request.Timeout = 5000;//定义请求超时时间为5秒
            request.KeepAlive = true;//启用长连接
            request.Method = "GET";//定义请求方式为GET   
            request.Host = host;
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");

            //if (strCookie != null)
            //{
            //    //request.Headers.Add("Cookie", strCookie);
            //    CookieContainer cookieContainer = StringToCookieContainer(uri, strCookie);
            //    request.CookieContainer = cookieContainer;
            //}

            request.ServicePoint.ConnectionLimit = int.MaxValue;//定义最大连接数

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();    //获取请求响应


            if (response.GetResponseHeader("Set-Cookie") != "")
            {
                var strCookie = response.GetResponseHeader("Set-Cookie");
                string[] tempString = strCookie.Split(new char[] { ';' });
                Current_Cookie = tempString[0];
            }

            Stream stream = response.GetResponseStream();//原始
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            pageSource = reader.ReadToEnd();

            request.Abort();

            return pageSource;
        }

        public static string GetLoginMethod(string uri, string host, string referer, string strCookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
            request.ServicePoint.Expect100Continue = false;//加快载入速度
            request.ServicePoint.UseNagleAlgorithm = false;//禁止Nagle算法加快载入速度
            request.AllowWriteStreamBuffering = false;//禁止缓冲加快载入速度
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");//定义gzip压缩页面支持
            request.ContentType = "application/x-www-form-urlencoded";//定义文档类型及编码
            request.AllowAutoRedirect = true;//禁止自动跳转
            //设置User-Agent，伪装成Google Chrome浏览器
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            request.Timeout = 5000;//定义请求超时时间为5秒
            request.KeepAlive = true;//启用长连接
            request.Method = "GET";//定义请求方式为GET   
            request.Host = host;
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");

            if (strCookie != null)
            {
                //request.Headers.Add("Cookie", strCookie);
                CookieContainer cookieContainer = StringToCookieContainer(uri, strCookie);
                request.CookieContainer = cookieContainer;
            }

            request.ServicePoint.ConnectionLimit = int.MaxValue;//定义最大连接数

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();    //获取请求响应


            //if (response.GetResponseHeader("Set-Cookie") != "")
            //{
            //    var strCookie = response.GetResponseHeader("Set-Cookie");
            //    string[] tempString = strCookie.Split(new char[] { ';' });
            //    Current_Cookie = tempString[0];
            //}



            Stream stream = response.GetResponseStream();//原始
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            pageSource = reader.ReadToEnd();




            request.Abort();

            return pageSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static  string PostLoginMethod(string uri, string host, string origin, string referer, string strCookie, string postData)
        {

            var data = System.Text.Encoding.Default.GetBytes(postData);


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
            request.ServicePoint.Expect100Continue = false;//加快载入速度
            request.ServicePoint.UseNagleAlgorithm = false;//禁止Nagle算法加快载入速度
            request.AllowWriteStreamBuffering = true;//禁止缓冲加快载入速度
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");//定义gzip压缩页面支持
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";//定义文档类型及编码
            request.ContentLength = data.Length;
            request.Referer = referer;
            request.Host = host;
            request.Headers.Add("Origin", origin);
            request.AllowAutoRedirect = false;//允许自动跳转
            //设置User-Agent，伪装成Google Chrome浏览器
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            request.Timeout = 5000;//定义请求超时时间为5秒
            request.KeepAlive = true;//启用长连接
            request.Method = "POST";//定义请求方式为POST 

            CookieContainer cookieContainer = StringToCookieContainer(uri, strCookie);

            request.CookieContainer = cookieContainer;


            // Send the data.
            Stream newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            var pageSource = "";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.GetResponseHeader("Set-Cookie") != "")
                {
                    strCookie = response.GetResponseHeader("Set-Cookie");
                    string[] tempString = strCookie.Split(new char[] { ';' });
                    Current_Cookie = tempString[0];
                }

                Stream stream = response.GetResponseStream();//原始
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                pageSource = reader.ReadToEnd();
                reader.Close();
                return pageSource;

            }
            catch
            {
                return pageSource;
            }
        }

        /// <summary>
        /// homePageIndex
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        public static string GetHomePageIndexMethod(string uri, string host, string referer, string strCookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
            request.ServicePoint.Expect100Continue = false;//加快载入速度
            request.ServicePoint.UseNagleAlgorithm = false;//禁止Nagle算法加快载入速度
            request.AllowWriteStreamBuffering = false;//禁止缓冲加快载入速度
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");//定义gzip压缩页面支持
            //request.ContentType = "application/x-www-form-urlencoded";//定义文档类型及编码
            request.AllowAutoRedirect = false;//禁止自动跳转
            //设置User-Agent，伪装成Google Chrome浏览器
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            request.Timeout = 5000;//定义请求超时时间为5秒
            request.KeepAlive = true;//启用长连接
            request.Method = "GET";//定义请求方式为GET   
            request.Host = host;
            request.Referer = referer;
            request.Headers.Add("Upgrade-Insecure-Requests", "1");


            //request.Credentials = CredentialCache.DefaultCredentials;

            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");

            if (strCookie != null)
            {
                //request.Headers.Add("Cookie", strCookie);
                CookieContainer cookieContainer = StringToCookieContainer(uri, strCookie);
                request.CookieContainer = cookieContainer;
            }

            request.ServicePoint.ConnectionLimit = int.MaxValue;//定义最大连接数

            HttpWebResponse response = null;

            try
            {
                response = (HttpWebResponse)request.GetResponse();    //获取请求响应
                //if (response.GetResponseHeader("Set-Cookie") != "")
                //{
                //    strCookie = response.GetResponseHeader("Set-Cookie");
                //    string[] tempString = strCookie.Split(new char[] { ';' });
                //    Current_Cookie = tempString[0];
                //}



                Stream stream = response.GetResponseStream();//原始
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                pageSource = reader.ReadToEnd();
                pageSource = response.ResponseUri.ToString();

            }
            catch (WebException e)
            {
                strCookie = e.Response.Headers["Set-Cookie"].Replace(",", "%2c");
                string[] tempString = strCookie.Split(new char[] { ';' });
                Current_Cookie = tempString[0];
                //MessageBox.Show(cookies);
                pageSource = (e.Response.Headers["Location"]);




            }


            request.Abort();

            return pageSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string PostGetLanguageMethod(string uri, string host, string origin, string referer, string strCookie, string postData)
        {

            var data = System.Text.Encoding.Default.GetBytes(postData);


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.ServicePoint.Expect100Continue = false;//加快载入速度
            request.ServicePoint.UseNagleAlgorithm = false;//禁止Nagle算法加快载入速度
            request.AllowWriteStreamBuffering = true;//禁止缓冲加快载入速度
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");//定义gzip压缩页面支持
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";//定义文档类型及编码
            request.ContentLength = data.Length;
            request.Referer = referer;
            request.Host = host;
            request.Headers.Add("Origin", origin);
            request.AllowAutoRedirect = false;//允许自动跳转
            //设置User-Agent，伪装成Google Chrome浏览器
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            request.Timeout = 5000;//定义请求超时时间为5秒
            request.KeepAlive = true;//启用长连接
            request.Method = "POST";//定义请求方式为POST 
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            CookieContainer cookieContainer = StringToCookieContainer(uri, strCookie);
            request.CookieContainer = cookieContainer;


            // Send the data.
            Stream newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();



            var pageSource = "";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.GetResponseHeader("Set-Cookie") != "")
                {
                    strCookie = response.GetResponseHeader("Set-Cookie");
                    string[] tempString = strCookie.Split(new char[] { ';' });
                    Current_Cookie = tempString[0];
                }

                Stream stream = response.GetResponseStream();//原始
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                pageSource = reader.ReadToEnd();
                reader.Close();
                return pageSource;
            }
            catch
            {
                return pageSource;
            }
        }



        /// <summary>
        /// homePageIndex
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        public static  string PostHomePageIndexMethod(string uri, string host, string referer, string strCookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
            request.ServicePoint.Expect100Continue = false;//加快载入速度
            request.ServicePoint.UseNagleAlgorithm = false;//禁止Nagle算法加快载入速度
            request.AllowWriteStreamBuffering = false;//禁止缓冲加快载入速度
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");//定义gzip压缩页面支持
            request.ContentType = "application/x-www-form-urlencoded";//定义文档类型及编码
            request.AllowAutoRedirect = true;//禁止自动跳转
            //设置User-Agent，伪装成Google Chrome浏览器
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            request.Timeout = 5000;//定义请求超时时间为5秒
            request.KeepAlive = true;//启用长连接
            request.Method = "GET";//定义请求方式为GET   
            request.Host = host;
            request.Referer = referer;

            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");

            if (strCookie != null)
            {
                //request.Headers.Add("Cookie", strCookie);
                CookieContainer cookieContainer = StringToCookieContainer(uri, strCookie);
                request.CookieContainer = cookieContainer;
            }

            request.ServicePoint.ConnectionLimit = int.MaxValue;//定义最大连接数

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();    //获取请求响应


            //if (response.GetResponseHeader("Set-Cookie") != "")
            //{
            //    strCookie = response.GetResponseHeader("Set-Cookie");
            //    string[] tempString = strCookie.Split(new char[] { ';' });
            //    Current_Cookie = tempString[0];
            //}



            Stream stream = response.GetResponseStream();//原始
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            pageSource = reader.ReadToEnd();




            request.Abort();

            return pageSource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static  string PostCallServerFunctionMethod(string uri, string host, string origin, string referer, string strCookie, string postData)
        {

            var data = System.Text.Encoding.Default.GetBytes(postData);


            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.ServicePoint.Expect100Continue = false;//加快载入速度
            request.ServicePoint.UseNagleAlgorithm = false;//禁止Nagle算法加快载入速度
            request.AllowWriteStreamBuffering = true;//禁止缓冲加快载入速度
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");//定义gzip压缩页面支持
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");
            request.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";//定义文档类型及编码
            request.ContentLength = data.Length;
            request.Referer = referer;
            request.Host = host;
            request.Headers.Add("Origin", origin);
            request.AllowAutoRedirect = false;//允许自动跳转
            //设置User-Agent，伪装成Google Chrome浏览器
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            request.Timeout = 20000;//定义请求超时时间为5秒
            request.KeepAlive = true;//启用长连接
            request.Method = "POST";//定义请求方式为POST 
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            CookieContainer cookieContainer = StringToCookieContainer(uri, strCookie);
            request.CookieContainer = cookieContainer;


            // Send the data.
            Stream newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();



            var pageSource = "";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.GetResponseHeader("Set-Cookie") != "")
                {
                    strCookie = response.GetResponseHeader("Set-Cookie");
                    string[] tempString = strCookie.Split(new char[] { ';' });
                    Current_Cookie = tempString[0];
                }

                Stream stream = response.GetResponseStream();//原始
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                pageSource = reader.ReadToEnd();
                reader.Close();
                return pageSource;
            }
            catch
            {
                return pageSource;
            }
        }



        public static CookieContainer StringToCookieContainer(string url, string cookie)
        {

            string[] arrCookie = cookie.Split(';');

            CookieContainer cookie_container = new CookieContainer();    //加载Cookie
            foreach (string sCookie in arrCookie)
            {
                if (sCookie.IndexOf("expires") > 0)
                    continue;
                cookie_container.SetCookies(new Uri(url), sCookie);
            }
            return cookie_container;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="host"></param>
        /// <param name="referer"></param>
        /// <param name="strCookie"></param>
        /// <returns></returns>
        public static string GetCuteLoginMethod(string uri, string host, string referer)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
            request.ServicePoint.Expect100Continue = false;//加快载入速度
            request.ServicePoint.UseNagleAlgorithm = false;//禁止Nagle算法加快载入速度
            request.AllowWriteStreamBuffering = false;//禁止缓冲加快载入速度
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");//定义gzip压缩页面支持
            request.ContentType = "application/x-www-form-urlencoded";//定义文档类型及编码
            request.AllowAutoRedirect = false;//禁止自动跳转
            //设置User-Agent，伪装成Google Chrome浏览器
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            request.Timeout = 5000;//定义请求超时时间为5秒
            request.KeepAlive = true;//启用长连接
            request.Method = "GET";//定义请求方式为GET   
            request.Host = host;
            request.Referer = referer;
            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");


            request.ServicePoint.ConnectionLimit = int.MaxValue;//定义最大连接数



            HttpWebResponse response = null;

            //var strCookie = "";
            try
            {
                response = (HttpWebResponse)request.GetResponse();    //获取请求响应
                //if (response.GetResponseHeader("Set-Cookie") != "")
                //{
                //    strCookie = response.GetResponseHeader("Set-Cookie");
                //    string[] tempString = strCookie.Split(new char[] { ';' });
                //    Current_Cookie = tempString[0];
                //}



                Stream stream = response.GetResponseStream();//原始
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                pageSource = reader.ReadToEnd();
                pageSource = response.ResponseUri.ToString();

            }
            catch (WebException e)
            {
                cuteCookies = e.Response.Headers["Set-Cookie"].Replace(",", "%2c");

                pageSource = (e.Response.Headers["Location"]);

            }

            request.Abort();

            return pageSource;
        }

        /// <summary>
        /// homePageIndex
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="host"></param>
        /// <returns></returns>
        public static string PostCuteLoginMethod(string uri, string host, string origin, string referer, string strCookie)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(new Uri(uri));
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3";
            request.ServicePoint.Expect100Continue = false;//加快载入速度
            request.ServicePoint.UseNagleAlgorithm = false;//禁止Nagle算法加快载入速度
            request.AllowWriteStreamBuffering = false;//禁止缓冲加快载入速度
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");//定义gzip压缩页面支持
            request.ContentType = "application/x-www-form-urlencoded";//定义文档类型及编码
            request.AllowAutoRedirect = true;//禁止自动跳转
            //设置User-Agent，伪装成Google Chrome浏览器
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/50.0.2661.102 Safari/537.36";
            request.Timeout = 5000;//定义请求超时时间为5秒
            request.KeepAlive = true;//启用长连接
            request.Method = "GET";//定义请求方式为GET   
            request.Host = host;
            request.Referer = referer;
            request.Headers.Add("Origin", origin);

            request.Headers.Add(HttpRequestHeader.AcceptLanguage, "zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6");

            if (strCookie != null)
            {
                //request.Headers.Add("Cookie", strCookie);
                CookieContainer cookieContainer = StringToCookieContainer(uri, strCookie);
                request.CookieContainer = cookieContainer;
            }

            request.ServicePoint.ConnectionLimit = int.MaxValue;//定义最大连接数

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();    //获取请求响应


            //if (response.GetResponseHeader("Set-Cookie") != "")
            //{
            //    strCookie = response.GetResponseHeader("Set-Cookie");
            //    string[] tempString = strCookie.Split(new char[] { ';' });
            //    Current_Cookie = tempString[0];
            //}



            Stream stream = response.GetResponseStream();//原始
            StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            pageSource = reader.ReadToEnd();

            request.Abort();

            return pageSource;
        }

    }
}
