using NewPortalAssiant.Net;
using NewPortalAssiant.PortalData;
using NewPortalAssiant.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NewPortalAssiant.View
{
    /// <summary>
    /// CoverAddressView.xaml 的交互逻辑
    /// </summary>
    public partial class CoverAddressView : Window
    {
        public CoverAddressViewModel coverAddressViewModel = new CoverAddressViewModel();
        public CoverAddressView()
        {
            InitializeComponent();
            this.DataContext = coverAddressViewModel;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

      
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.MouseRightButtonDown += (s, a) =>
            {
                a.Handled = true;
                (sender as DataGrid).SelectedIndex = (s as DataGridRow).GetIndex();
                (s as DataGridRow).Focus();

            };
        }

        private void DataGridBoxCoverAdd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            if ((sender as DataGrid).SelectedItem == null) { return; }
            coverAddressViewModel.SelectedAddressData = (BoxAddressData.DataListItem)(sender as DataGrid).SelectedItem;

            WriteOperateInfo("选择地址：", coverAddressViewModel.SelectedAddressData.STAND_NAME);


            try
            {
                //Clipboard.SetText(b.name.ToString());
                Clipboard.SetDataObject(coverAddressViewModel.SelectedAddressData.STAND_NAME.ToString());
            }
            catch { }
        }

        #region 地址变更
        private void ChangeAddress_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (coverAddressViewModel.SelectedAddressData == null) { return; }
            
            if (coverAddressViewModel.SelectedAddressData.isHaveBusiness.Equals("是"))
            {
                //MessageBox.Show("地址已占用！\n请选择空闲地址绑定！", "提示信息：", MessageBoxButton.OK, MessageBoxImage.Error);
                WriteOperateInfo("变更地址出错：", coverAddressViewModel.SelectedAddressData.STAND_NAME + "已占用,无法变更！");
                return;
            }


           
            //POST http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr HTTP/1.1
            //Host: 10.40.95.32:8012
            //Connection: keep - alive
            //Content - Length: 454
            //Accept: application / json, text / javascript, */*; q=0.01
            //X-Requested-With: XMLHttpRequest
            //User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36 Edg/87.0.664.57
            //Content-Type: application/x-www-form-urlencoded; charset=UTF-8
            //Origin: http://10.40.95.32:8012
            //Referer: http://10.40.95.32:8012/im-res-product-pub/intelligent.html?ot=rt&qi=9285&roi=&spi=20&st=card
            //Accept-Encoding: gzip, deflate
            //Accept-Language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
            //Cookie: SESSION=69c36783-1ee9-4e85-a5fc-f286aa0de18e; frame_language=zh_CN

            //_callFunParams=%5B%22com.ztesoft.res.frame.component.intelligent.inf.IntelligentSearchServiceInf%22%2C%22dynamticSearchQueryGuide%22%2C%7B%22keyWord%22%3A%22
            //%E9%9D%92%E5%B2%9B%E8%8A%B1
            //%22%2C%22queryId%22%3A%229285%22%2C%22roleId%22%3A270%2C%22condition%22%3A%5B%7B%22fieldName%22%3A%22resource_attribute%22%2C%22fieldValue%22%3A%221485682%2C1485685%2C1485685%2C1485684%22%7D%5D%7D%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1607563783226
            var referer = "http://10.40.95.32:8012/im-res-product-pub/intelligent.html?ot=rt&qi=9285&roi=&spi=20&st=card";
            var postData = "_callFunParams=%5B%22com.ztesoft.res.frame.component.intelligent.inf.IntelligentSearchServiceInf%22%2C%22dynamticSearchQueryGuide%22%2C%7B%22keyWord%22%3A%22";
            postData += System.Web.HttpUtility.UrlEncode(coverAddressViewModel.ComAreaName, Encoding.UTF8);
            postData += "%22%2C%22queryId%22%3A%229285%22%2C%22roleId%22%3A270%2C%22condition%22%3A%5B%7B%22fieldName%22%3A%22resource_attribute%22%2C%22fieldValue%22%3A%221485682%2C1485685%2C1485685%2C1485684%22%7D%5D%7D%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1607563783226";
            
            var returnPage = RequestMothed.PostCallServerFunctionMethod(coverAddressViewModel.CallServerFunctionUri, coverAddressViewModel.Host, coverAddressViewModel.Origin, referer, coverAddressViewModel.Cookies, postData);
            QueryComAreaIDResultData queryComAreaIDResultData = new QueryComAreaIDResultData();
            queryComAreaIDResultData = JsonConvert.DeserializeObject<QueryComAreaIDResultData>(returnPage);

            var comAreaDataResult = queryComAreaIDResultData.data.result;
            ComAreaData comAreaData = new ComAreaData();
            comAreaData = JsonConvert.DeserializeObject<ComAreaData>(comAreaDataResult);

            coverAddressViewModel.SelectedComArea = null;
            foreach (var com in comAreaData.rows)
            {
                if (com.name.Equals(coverAddressViewModel.ComAreaName))
                {
                    coverAddressViewModel.SelectedComArea = com;
                    break;
                }
            }
            if (coverAddressViewModel.SelectedComArea == null)
            {
                //MessageBox.Show("小区名称错误！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                WriteOperateInfo("变更地址出错：", "小区名称错误！");
                return;
            }

            //根据小区ID查询所有箱体，并取出所有的二级分纤箱分光器
            //POST http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr HTTP/1.1
            //Host: 10.40.95.32:8012
            //Connection: keep - alive
            //Content - Length: 232
            //Accept: application / json, text / javascript, */*; q=0.01
            //X-Requested-With: XMLHttpRequest
            //User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36 Edg/87.0.664.57
            //Content-Type: application/x-www-form-urlencoded; charset=UTF-8
            //Origin: http://10.40.95.32:8012
            //Referer: http://10.40.95.32:8012/im-res-product-pub/intelligent.html?ot=rt&qi=9285&roi=&spi=20&st=card&wd=%u9752%u5C9B%u82B1%u56ED%u5C0F%u533A
            //Accept-Encoding: gzip, deflate
            //Accept-Language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
            //Cookie: SESSION=69c36783-1ee9-4e85-a5fc-f286aa0de18e; frame_language=zh_CN

            //_callFunParams=%5B%22com.ztesoft.gis.module.boxManage.service.BoxManageService%22%2C%22queryComBoxList%22%2C%7B%22comId%22%3A%22
            //000102090100000000045646
            //%22%7D%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1607565044848
            referer = "http://10.40.95.32:8012/im-res-product-pub/intelligent.html?ot=rt&qi=9285&roi=&spi=20&st=card&wd=" + System.Web.HttpUtility.UrlEncode(coverAddressViewModel.ComAreaName, Encoding.UTF8);
            postData = "_callFunParams=%5B%22com.ztesoft.gis.module.boxManage.service.BoxManageService%22%2C%22queryComBoxList%22%2C%7B%22comId%22%3A%22";
            postData += coverAddressViewModel.SelectedComArea.id;
            postData += "%22%7D%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1607565044848";
            returnPage = RequestMothed.PostCallServerFunctionMethod(coverAddressViewModel.CallServerFunctionUri, coverAddressViewModel.Host, coverAddressViewModel.Origin, referer, coverAddressViewModel.Cookies, postData);
            QueryComAreaBoxResultData queryComAreaBoxResultData = new QueryComAreaBoxResultData();
            queryComAreaBoxResultData = JsonConvert.DeserializeObject<QueryComAreaBoxResultData>(returnPage);

            ObservableCollection<QueryComAreaBoxResultData.DataItem> boxesDatas = new ObservableCollection<QueryComAreaBoxResultData.DataItem>();
            foreach (var box in queryComAreaBoxResultData.data)
            {
                if (box.BOX_TYPE == "光分纤箱")
                {
                    boxesDatas.Add(box);
                }
            }

            ChangeAddressView changeAddressView = new ChangeAddressView();
            changeAddressView.changeAddressViewModel.Cookies = coverAddressViewModel.Cookies;
            changeAddressView.changeAddressViewModel.SelectedAddressData = coverAddressViewModel.SelectedAddressData;
            changeAddressView.changeAddressViewModel.SourceBoxName = coverAddressViewModel.FenxianBoxName;
            changeAddressView.changeAddressViewModel.SourceAddress = coverAddressViewModel.SelectedAddressData.STAND_NAME;
            changeAddressView.changeAddressViewModel.BoxesDatas = boxesDatas;
            //changeAddressWindow.ComboBox_BoxesList.ItemsSource = boxesData;
            //changeAddressWindow.ComboBox_BoxesList.DisplayMemberPath = "BOX_NAME";//BOX_NAME=青岛花园-GF0005

            changeAddressView.Owner = Window.GetWindow(this);
            changeAddressView.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            changeAddressView.Show();


        }
        #endregion 地址变更


        #region 游离帐号绑定
        private void FreeAccountBind_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            FreeAccountBindView freeAccountBindView = new FreeAccountBindView();
            freeAccountBindView.freeAccountBindViewModel.SelectedAddressData = coverAddressViewModel.SelectedAddressData;
            freeAccountBindView.freeAccountBindViewModel.BindingComArea = coverAddressViewModel.ComAreaName;
            freeAccountBindView.Owner = Window.GetWindow(this);
            freeAccountBindView.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            freeAccountBindView.Show();
        }
        #endregion 游离帐号绑定

        /// <summary>
        /// 写入操作信息
        /// </summary>
        /// <param name="operate"></param>
        /// <param name="operateData"></param>
        private void WriteOperateInfo(string operate, string operateData)
        {
            var opreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string operateInfo = opreateDate + " " + operate + ":" + operateData;
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                WorkPageView.workViewModel.OperateInfo.Add(operateInfo);
            }));
        }
    }
}
