using NewPortalAssiant.Common;
using NewPortalAssiant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NewPortalAssiant.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            MainViewModel model = new MainViewModel();
            this.DataContext = model;

            model.userInfo.UserName = GlobalValues.UserInfo.UserName;

            model.portalLoginModel.UserName = AppConfig.GetSettingString("portalUserName"); 
            model.portalLoginModel.Password = AppConfig.GetSettingString("portalPassword");

            this.MaxHeight = SystemParameters.PrimaryScreenHeight;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMax_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {

            //base.OnClosing(e);
            if (MessageBox.Show("确定是否关闭管线辅助程序？", "提示", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                //this.Close();  //重写父类的onClosing事件，通过this.closing关闭报错,
                base.OnClosing(e);//解决这个问题就是用base.Onclosing(e)代替 this.close()   用基类base关键词引用来关闭窗口,问题解决。
            }
            else
            {
                e.Cancel = true;

            }

        }

       
    }
}
