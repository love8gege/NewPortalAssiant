using NewPortalAssiant.Common;
using NewPortalAssiant.DataAccess;
using NewPortalAssiant.Model;
using Newtonsoft.Json;
using SimpleAES;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace NewPortalAssiant.ViewModel
{
    public class LoginViewModel:NotifyBase
    {
        public LoginModel loginModel { get; set; }

        public CommandBase CloseWindowCommand { get; set; }

        public CommandBase LoginCommand { get; set; }

        private string _errorMessage;



        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                this.DoNotify();
            }
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

        public LoginViewModel()
        {
            this.loginModel = new LoginModel();

            this.loginModel.UserName = AppConfig.GetSettingString("userName");
            this.loginModel.Password = AppConfig.GetSettingString("password"); ;

            this.ShowProgress = Visibility.Collapsed;

            this.CloseWindowCommand = new CommandBase();
            this.CloseWindowCommand.DoExecute = new Action<object>((o) =>
            {
                (o as Window).Close();
            });
            this.CloseWindowCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });

            this.LoginCommand = new CommandBase();
            this.LoginCommand.DoExecute = new Action<object>(DoLogin);
            this.LoginCommand.DoCanExecute = new Func<object, bool>((o) => { return true; });
        }

        private void DoLogin(object obj)
        {
            //throw new NotImplementedException();

            this.ShowProgress = Visibility.Visible;
            this.ErrorMessage = "";

            

            if (string.IsNullOrEmpty(loginModel.UserName))
            {
                this.ErrorMessage = "请输入用户名！";
                this.ShowProgress = Visibility.Collapsed;
                return;
            }

            if (string.IsNullOrEmpty(loginModel.Password))
            {
                this.ErrorMessage = "请输入密码！";
                this.ShowProgress = Visibility.Collapsed;
                return;
            }


            Task.Run(new Action(() =>
            {
                try
                {
                    var user = LocalDataAccess.GetInstance().CheckUserInfo(loginModel.UserName, loginModel.Password);
                    if (user == null)
                    {
                        throw new Exception("登录失败！用户名或密码错！");
                    }

                    //这里判断认证信息

                    string password = "ae125efkk4454eeff444ferfknyjetix";
                    
                    string myStr = user.UserCert;
                    string str2 = AES256.Decrypt(myStr, password);

                    AuthenticationData authenticationData = new AuthenticationData();
                    authenticationData = JsonConvert.DeserializeObject<AuthenticationData>(str2);

                    var LensiceTime = Convert.ToDateTime(authenticationData.LimitDate);
                    var _currentTime = DateTime.Now;
                    if (DateTime.Compare(LensiceTime, _currentTime) < 0)
                    {
                        user = null;
                        throw new Exception("登录失败！程序授权已过期！");
                    }



                    GlobalValues.UserInfo = user;
                    Thread.Sleep(1000);
                    //跳转主窗体
                    this.ErrorMessage = "登陆成功！";
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        (obj as Window).DialogResult = true;
                    }));
                }
                catch (Exception ex)
                {
                    this.ErrorMessage = ex.Message;

                }
                finally
                {
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        this.ShowProgress = Visibility.Collapsed;
                    }));
                }
            }));
        }
    }
}
