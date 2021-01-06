using NewPortalAssiant.Net;
using NewPortalAssiant.PortalData;
using NewPortalAssiant.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
    /// ChangeAddressView.xaml 的交互逻辑
    /// </summary>
    public partial class ChangeAddressView : Window
    {
        public ChangeAddressViewModel changeAddressViewModel = new ChangeAddressViewModel();

        public ChangeAddressView()
        {
            InitializeComponent();
            this.DataContext = changeAddressViewModel;
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

        private void ComboBox_BoxesList_KeyUp(object sender, KeyEventArgs e)
        {
            var inText = ComboBox_BoxesList.Text.Trim();


            changeAddressViewModel.ChooseBoxesDatas.Clear();
            foreach (var item in changeAddressViewModel.BoxesDatas)
            {
                if (item.BOX_NAME.Contains(inText.ToUpper()))
                {
                  changeAddressViewModel.ChooseBoxesDatas.Add(item);
                }

            }

            ComboBox_BoxesList.ItemsSource = null;
            ComboBox_BoxesList.ItemsSource = changeAddressViewModel.ChooseBoxesDatas;
            ComboBox_BoxesList.DisplayMemberPath = "BOX_NAME";
            ComboBox_BoxesList.IsDropDownOpen = true;
        }

        private void Button_ChangeAddress_Click(object sender, RoutedEventArgs e)
        {
            var selectedBox = (QueryComAreaBoxResultData.DataItem)ComboBox_BoxesList.SelectedItem;

            if (selectedBox == null) { return; }

            Task.Run(new Action(() =>
            {                

                var segm_id = changeAddressViewModel.SelectedAddressData.SEGM_ID;
                var segm_eqp_id = changeAddressViewModel.SelectedAddressData.SEGM_EQP_ID;
                var box_id = selectedBox.ID;
                var box_name = selectedBox.BOX_NAME;
                //POST http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr HTTP/1.1
                //Host: 10.40.95.32:8012
                //Connection: keep - alive
                //Content - Length: 461
                //Accept: application / json, text / javascript, */*; q=0.01
                //X-Requested-With: XMLHttpRequest
                //User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.67 Safari/537.36 Edg/87.0.664.47
                //Content-Type: application/x-www-form-urlencoded; charset=UTF-8
                //Origin: http://10.40.95.32:8012
                //Referer: http://10.40.95.32:8012/im-res-product-pub/intelligent.html?ot=rt&qi=9267&roi=&spi=&st=card&wd=%u91D1%u79CB%u60C5%u7F18-GF0033
                //Accept-Encoding: gzip, deflate
                //Accept-Language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
                //Cookie: SESSION=75942a5d-b13b-4ada-985d-a7d04b25e457; 9009-remember-A_RME_EQP_EQP_NAME=%5B%22%E9%87%91%E7%A7%8B%E6%83%85%E7%BC%98-GF0015-POS001-1%3A8%22%5D; 11114-remember-A_RME_EQP_EQP_NAME=%5B%22%E6%96%B0%E6%B5%B7%E9%87%91%E7%A7%8B%E6%83%85%E7%BC%98%E5%B0%8F%E5%8C%BA-GJ0001-POS002-1%3A8%22%5D; 9285-remember-A_SPC_REGION_REGION_NAME=%5B%22%E9%87%91%E7%A7%8B%E6%83%85%E7%BC%98%22%5D; frame_language=zh_CN

                //_callFunParams=%5B%22com.ztesoft.gis.module.boxManage.service.ComDpAddrSegmService%22%2C%22changeCoverBox%22%2C%7B%22segm_id%22%3A%22
                //000102140100000067230794
                //%22%2C%22segm_eqp_id%22%3A%22
                //000102170100000032771960
                //%22%2C%22boxId%22%3A%22
                //000107043500000007031758
                //%22%2C%22resTypeId%22%3A704%2C%22boxName%22%3A%22
                //%E9%87%91%E7%A7%8B%E6%83%85%E7%BC%98-GF0034
                //%22%2C%22addr_segm_type%22%3A180010%7D%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1606460827944

                var sourceBoxName = changeAddressViewModel.SelectedAddressData.STAND_NAME;

                var referer = "http://10.40.95.32:8012/im-res-product-pub/intelligent.html?ot=rt&qi=9267&roi=&spi=&st=card&wd=" + System.Web.HttpUtility.UrlEncode(sourceBoxName, Encoding.UTF8);
                var postData = "_callFunParams=%5B%22com.ztesoft.gis.module.boxManage.service.ComDpAddrSegmService%22%2C%22changeCoverBox%22%2C%7B%22segm_id%22%3A%22";
                postData += segm_id;
                postData += "%22%2C%22segm_eqp_id%22%3A%22";
                postData += segm_eqp_id;
                postData += "%22%2C%22boxId%22%3A%22";
                postData += box_id;
                postData += "%22%2C%22resTypeId%22%3A704%2C%22boxName%22%3A%22";
                postData += System.Web.HttpUtility.UrlEncode(box_name, Encoding.UTF8);
                postData += "%22%2C%22addr_segm_type%22%3A180010%7D%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1606460827944";

                var returnPage = RequestMothed.PostCallServerFunctionMethod(changeAddressViewModel.CallServerFunctionUri, changeAddressViewModel.Host, changeAddressViewModel.Origin, referer, changeAddressViewModel.Origin, postData);

                WriteOperateInfo("地址变更：", changeAddressViewModel.SourceAddress + " 源箱体：" + changeAddressViewModel.SourceBoxName + " 目标箱体：" + selectedBox.BOX_NAME);

                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    this.Close();
                }));

            }));
        }


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
