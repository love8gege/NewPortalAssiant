using NewPortalAssiant.Common;
using NewPortalAssiant.Model;
using NewPortalAssiant.Net;
using NewPortalAssiant.PortalData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace NewPortalAssiant.ViewModel
{
    public class MainViewModel:NotifyBase
    {
        public PortalLoginModel portalLoginModel { get; set; }

        public UserModel userInfo { get; set; }

        public PortalLoginInfo portalLoginInfo { get; set; }

        public CommandBase PortalLoginCommand { get; set; }

        


        public static string host = "10.40.95.32.14:8001";
        public static string origin = "http://10.40.95.32:8001";

        public static string hostwork = "10.40.95.32:8012";
        public static string originwork = "http://10.40.95.32:8012";

        public static LoginResult loginResult;


        private string _cookies;
        public string Cookies
        {
            get { return _cookies; }
            set { _cookies = value; }
        }

        private static string _workCookies;

        public static string WorkCookies
        {
            get { return _workCookies; }
            set { _workCookies = value; }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }


        private string _portalUserName;

        public string PortalUserName
        {
            get { return _portalUserName; }
            set { _portalUserName = value;this.DoNotify(); }
        }

        private Visibility _showMenu;
        public Visibility ShowMenu
        {
            get { return _showMenu; }
            set
            {
                _showMenu = value;
                this.DoNotify();
            }
        }

        private bool _isEnable;

        public bool IsEnable
        {
            get { return _isEnable; }
            set { _isEnable = value;this.DoNotify(); }
        }


        private Visibility _showProgress;
        public Visibility ShowProgress
        {
            get { return _showProgress; }
            set
            {
                _showProgress = value;
                this.DoNotify();
            }
        }

        private FrameworkElement _mainContent;

        public FrameworkElement MainContent
        {
            get { return _mainContent; }
            set { _mainContent = value; this.DoNotify(); }
        }

        public CommandBase NaveChangedCommand { get; set; }

        public MainViewModel()
        {

            portalLoginModel = new PortalLoginModel();
            portalLoginInfo = new PortalLoginInfo();

            Title = "综合资源管理平台-新管线辅助程序-版本号：";
            Title+= Application.ResourceAssembly.GetName().Version.ToString();

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            Title += " 更新日期：" + version;

            userInfo = new UserModel();

            ShowMenu = Visibility.Collapsed;
            ShowProgress = Visibility.Collapsed;
            IsEnable = true;

            this.NaveChangedCommand = new CommandBase();
            this.NaveChangedCommand.DoExecute = new Action<object>(DoNavChanged);
            this.NaveChangedCommand.DoCanExecute = new Func<object, bool>((o) => true);

            this.PortalLoginCommand = new CommandBase();
            this.PortalLoginCommand.DoExecute = new Action<object>(DoPortalLogin);
            this.PortalLoginCommand.DoCanExecute = new Func<object, bool>((o) => true);


            

            DoNavChanged("FirstPageView");
        }

        private void DoNavChanged(object obj)
        {
            //throw new NotImplementedException();
            Type type = Type.GetType("NewPortalAssiant.View." + obj.ToString());
            ConstructorInfo cti = type.GetConstructor(System.Type.EmptyTypes);
            this.MainContent = (FrameworkElement)cti.Invoke(null);
        }

        private void DoPortalLogin(object obj)
        {

            Task.Run(new Action(() =>
            {

                ShowProgress = Visibility.Visible;

                //throw new NotImplementedException();
                //Thread.Sleep(2000);
                //打开登陆页面，以获取cookies
                //GET http://10.40.95.32:8001/im-portal-product/login.jhtml HTTP/1.1
                //Host: 10.40.95.32:8001
                //Connection: keep - alive
                //Cache - Control: max - age = 0
                //Upgrade - Insecure - Requests: 1
                //User - Agent: Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 85.0.4183.121 Safari / 537.36 Edg / 85.0.564.68
                //Accept: text / html,application / xhtml + xml,application / xml; q = 0.9,image / webp,image / apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9
                //Accept-Encoding: gzip, deflate
                //Accept-Language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
                string login_jthml = "http://10.40.95.32:8001/im-portal-product/login.jhtml";
                //string host = "10.40.95.32:8001";


                var returnPage = RequestMothed.GetLoginMethod(login_jthml, host);
                Cookies = RequestMothed.Current_Cookie;


                //准备登陆
                //POST http://10.40.95.32:8001/im-portal-product/doLogin.jhtml?method=login HTTP/1.1
                //Host: 10.40.95.32:8001
                //Connection: keep - alive
                //Content - Length: 84
                //Accept: application / json, text / javascript, */*; q=0.01
                //X-Requested-With: XMLHttpRequest
                //User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36 Edg/85.0.564.68
                //Content-Type: application/x-www-form-urlencoded; charset=UTF-8
                //Origin: http://10.40.95.32:8001
                //Referer: http://10.40.95.32:8001/im-portal-product/login.jhtml
                //Accept-Encoding: gzip, deflate
                //Accept-Language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
                //Cookie: JSESSIONID=FBADFF51240388AC13DE604D94FE7555; frame_language=zh_CN; cookie_username=cookie_ADMIN1602037393214

                //loginName=6J5biGFdHFY%3D&encrypt=K5Zf8EGSSb8NcfONbFgzaCLmyol8ze0W&psw=2PncgBCFwyw%3D


                //为空判断 返回

                string key = "1876ebf1c532b75e1c16a6f2";//30633c0a" ; 这种加密用的只是前24位 ，非32位
                string iv = "83654623";
                string encryptUserName = Encrypt.Encrypt3DES(portalLoginModel.UserName, key, iv);
                string encryptPassword = Encrypt.Encrypt3DES(portalLoginModel.Password, key, iv);

                //此处需要一下UUID
                string uuid = System.Guid.NewGuid().ToString("N");

                var doLogin_jthml = "http://10.40.95.32:8001/im-portal-product/doLogin.jhtml?method=login";
                var referer = "http://10.40.95.32:8001/im-portal-product/login.jhtml";

                //构选发送数据
                //loginName=6J5biGFdHFY%3D&encrypt=uinmoV4CO7uDjHYhen0jZCL11iEAfXjt&psw=2PncgBCFwyw%3D

                //获取时间戳
                DateTime startTime = TimeZoneInfo.ConvertTime(new System.DateTime(1970, 1, 1), TimeZoneInfo.Utc, TimeZoneInfo.Local);  // 当地时区
                long timeStamp = (long)(DateTime.Now - startTime).TotalMilliseconds; // 相差毫秒数

                var currentCookies = Cookies + "; frame_language=zh_CN; cookie_username=cookie_" + portalLoginModel.UserName + timeStamp.ToString();

                string postData = "loginName=" + System.Web.HttpUtility.UrlEncode(encryptUserName, System.Text.Encoding.UTF8);
                postData = postData + "&encrypt=" + uuid;
                postData = postData + "&psw=" + System.Web.HttpUtility.UrlEncode(encryptPassword, System.Text.Encoding.UTF8);

                returnPage = RequestMothed.PostLoginMethod(doLogin_jthml, host, origin, referer, currentCookies, postData);

               
                
                loginResult = new LoginResult();

                



                if (returnPage.Contains("ERROR"))
                {
                    LoginResultError loginResultError = new LoginResultError();
                    loginResultError = JsonConvert.DeserializeObject<LoginResultError>(returnPage);
                    MessageBox.Show("登陆失败！\n " + loginResultError.mess, "失败信息", MessageBoxButton.OK, MessageBoxImage.Error);
                    

                }
                else
                {

                    loginResult = JsonConvert.DeserializeObject<LoginResult>(returnPage);

                    portalLoginInfo.UserNmae = loginResult.data.userName;
                    portalLoginInfo.UserId = loginResult.data.userId;
                    //Login_Button.IsEnabled = false;
                    //UserAccount_TextBox.IsEnabled = false;
                    //Password_PasswordBox.IsEnabled = false;
                    //StackPanelNavi.Visibility = Visibility.Visible;

                    //更新已登陆的帐户和密码
                    AppConfig.UpdateSettingString("portalUserName", portalLoginModel.UserName);
                    AppConfig.UpdateSettingString("portalPassword", portalLoginModel.Password);

                    Cookies = Cookies + ";" + RequestMothed.Current_Cookie + ";frame_language=zh_CN";




                    ////POST http://10.40.95.32:8012/im-res-product-pub/res/login.spr?method=getLanguage HTTP/1.1
                    ////Host: 10.40.95.32:8012
                    ////Connection: keep - alive
                    ////Content - Length: 0
                    ////Accept: application / json, text / javascript, */*; q=0.01
                    ////User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.75 Safari/537.36 Edg/86.0.622.38
                    ////X-Requested-With: XMLHttpRequest
                    ////Origin: http://10.40.95.32:8012
                    ////Referer: http://10.40.95.32:8012/im-res-product-pub/homePageIndex.html
                    ////Accept-Encoding: gzip, deflate
                    ////Accept-Language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
                    //var getLanguage = "http://10.40.95.32:8012/im-res-product-pub/res/login.spr?method=getLanguage";
                    //referer = "http://10.40.95.32:8012/im-res-product-pub/homePageIndex.html";
                    //returnPage = requestMethod.PostGetLanguageMethod(getLanguage, hostwork, originwork, referer, "", "");
                    //GetLanguageResult getLanguageResult = new GetLanguageResult();
                    //getLanguageResult = JsonConvert.DeserializeObject<GetLanguageResult>(returnPage);
                    //if (getLanguageResult.resultStat == "SUCCESS")
                    //{
                    //    workCookies = requestMethod.Current_Cookie;
                    //}
                    //else
                    //{
                    //    MessageBox.Show("初始化管理平台页面出错！\n请稍后重试！", "出错啦 !", MessageBoxButton.OK, MessageBoxImage.Error);
                    //    this.Close();
                    //    return;
                    //}



                    //打开 http://10.40.95.32:8012/im-res-product-pub/homePageIndex.html 页    //注意 端口由 8001 变更为 8012
                    //GET http://10.40.95.32:8012/im-res-product-pub/homePageIndex.html HTTP/1.1
                    //Host: 10.40.95.32:8012
                    //Connection: keep - alive
                    //Upgrade - Insecure - Requests: 1
                    //User - Agent: Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 85.0.4183.121 Safari / 537.36 Edg / 85.0.564.68
                    //Accept: text / html,application / xhtml + xml,application / xml; q = 0.9,image / webp,image / apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9
                    //Referer: http://10.40.95.32:8001/im-portal-product/login.jhtml
                    //Accept-Encoding: gzip, deflate
                    //Accept-Language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
                    //Cookie: frame_language=zh_CN; JSESSIONID=5F44CDABD1F3781930DD15DB2144F12C

                    var homePageIndex = "http://10.40.95.32:8012/im-res-product-pub/homePageIndex.html";
                    referer = "http://10.40.95.32:8001/";
                    uuid = System.Guid.NewGuid().ToString("N").ToUpper();
                    //currentCookies = "frame_language=zh_CN;" + cookies;

                    var redirectUri = RequestMothed.GetHomePageIndexMethod(homePageIndex, hostwork, referer, "");  //取回跳转的网址 加上cookies重新访问
                    WorkCookies = RequestMothed.Current_Cookie;

                    GlobalValues.Cookies= RequestMothed.Current_Cookie;


                    ////GET http://10.40.95.32:8001/im-portal-product/login.jhtml?service=http%3A%2F%2F10.40.95.32%3A8012%2Fim-res-product%2FhomePageIndex.html%3F_rd%3D1414152105 HTTP/1.1
                    ////Host: 10.40.95.32:8001
                    ////Connection: keep - alive
                    ////Upgrade - Insecure - Requests: 1
                    ////User - Agent: Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 86.0.4240.75 Safari / 537.36 Edg / 86.0.622.38
                    ////Accept: text / html,application / xhtml + xml,application / xml; q = 0.9,image / webp,image / apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9
                    ////Referer: http://10.40.95.32:8001/
                    ////Accept-Encoding: gzip, deflate
                    ////Accept-Language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
                    ////Cookie: _sscv_=ssoT-1579-3mpXb4dXq6LiWBJ-tRes; JSESSIONID=B84FBE8571DA91B81C49F2B589709A3C; frame_language=zh_CN
                    //referer = "http://10.40.95.32:8001/";
                    //returnPage = RequestMothed.GetLoginMethod(redirectUri, host, referer, Cookies);

                    ////此处要获取 8012的 cookies 及跳转8001的网址 ，以获取 8012的跳转地址

                    ////var pattern = @"((https|http|ftp|rtsp|mms)?:\/\/)[^\s]+";
                    //var pattern = @"((http)?:\/\/)[^\u0022]*";
                    //string startUrl = "";
                    //Match match = Regex.Match(returnPage, pattern);
                    //if (match.Success)
                    //{
                    //    startUrl = match.Value;

                    //}
                    //else
                    //{
                    //    MessageBox.Show("初始化出错！", "出错啦 ！", MessageBoxButton.OK, MessageBoxImage.Error);

                    //    (obj as Window).Close();
                    //    ///这里如何关闭窗体？？？
                    //}


                    ////POST http://10.40.95.32:8012/im-res-product-pub/homePageIndex.html?_rd=1414152105&st=ssoS-2327-5zp5fQBxeTBL-sRes HTTP/1.1
                    ////Host: 10.40.95.32:8012
                    ////Connection: keep - alive
                    ////Content - Length: 0
                    ////Cache - Control: max - age = 0
                    ////Upgrade - Insecure - Requests: 1
                    ////Origin: http://10.40.95.32:8001
                    ////            Content - Type: application / x - www - form - urlencoded
                    ////User - Agent: Mozilla / 5.0(Windows NT 10.0; Win64; x64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 86.0.4240.75 Safari / 537.36 Edg / 86.0.622.38
                    ////Accept: text / html,application / xhtml + xml,application / xml; q = 0.9,image / webp,image / apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9
                    ////Referer: http://10.40.95.32:8001/
                    ////Accept-Encoding: gzip, deflate
                    ////Accept-Language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
                    ////Cookie: JSESSIONID=A9C986787A055602A2F473E6BA770C0C
                    //referer = "http://10.40.95.32:8001/";
                    //returnPage = RequestMothed.PostHomePageIndexMethod(startUrl, host, referer, WorkCookies);

                   
                    IsEnable = false;
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        DoNavChanged("WorkPageView");
                    }));

                }

                ShowMenu = Visibility.Visible;
                ShowProgress = Visibility.Collapsed;
                
            }));
        }
 
    }
}
