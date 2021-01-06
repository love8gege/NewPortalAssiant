using NewPortalAssiant.Common;
using NewPortalAssiant.Net;
using NewPortalAssiant.PortalData;
using NewPortalAssiant.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// FreeAccountBindView.xaml 的交互逻辑
    /// </summary>
    public partial class FreeAccountBindView : Window
    {
        public FreeAccountBindViewModel freeAccountBindViewModel = new FreeAccountBindViewModel();

        //定义BUSINESS_ID
        public string BUSINESS_ID = "";

        public FreeAccountBindView()
        {
            InitializeComponent();
            freeAccountBindViewModel.ShowProgress = Visibility.Collapsed;
            freeAccountBindViewModel.ShowStackPanel = Visibility.Collapsed;
            freeAccountBindViewModel.GridIsEnabled = true;
            this.DataContext = freeAccountBindViewModel;
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

        private void ButtonQueryFreeAccount_Click(object sender, RoutedEventArgs e)
        {



            if (string.IsNullOrEmpty(freeAccountBindViewModel.Account)) { return; }

            Task.Run(new Action(() =>
            {

                Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                freeAccountBindViewModel.GridIsEnabled = false;
                freeAccountBindViewModel.ShowProgress = Visibility.Visible;
            }));
                WriteOperateInfo("查询待绑定帐号", freeAccountBindViewModel.Account);

                //POST http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr HTTP/1.1
                //Host: 10.40.95.32:8012
                //User - Agent: Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 82.0) Gecko / 20100101 Firefox / 82.0
                //Accept: application / json, text / javascript, */*; q=0.01
                //Accept-Language: zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2
                //Accept-Encoding: gzip, deflate
                //Content-Type: application/x-www-form-urlencoded; charset=UTF-8
                //X-Requested-With: XMLHttpRequest
                //Content-Length: 550
                //Origin: http://10.40.95.32:8012
                //Connection: keep-alive
                //Referer: http://10.40.95.32:8012/im-res-product-pub/intelligent.html?ot=rt&qi=18444&roi=&spi=312&st=card&wd=13815662015
                //Cookie: SESSION=453dd4f5-5a49-4afa-9d30-25be0164e628; frame_language=zh_CN; BIGipServerNEWGX_ziyuanpeizhi_8013=1646839306.19743.0000

                //_callFunParams=%5B%22com.ztesoft.res.frame.component.intelligent.inf.IntelligentSearchServiceInf%22%2C%22dynamticSearchQuery%22%2C%7B%22queryId%22%3A18444%2C%22keyWord%22%3A%22
                //13815662015
                //%22%2C%22condition%22%3A%5B%7B%22fieldName%22%3A%22resource_attribute%22%2C%22fieldValue%22%3A%221485682%2C1485685%2C1485685%2C1485684%22%7D%5D%2C%22start%22%3A0%2C%22pageSize%22%3A16%2C%22roleId%22%3A270%2C%22sort%22%3A%5B%5D%2C%22resRoleId%22%3A%22%22%2C%22specialityId%22%3A%22312%22%7D%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1603434792138
                var postData = "_callFunParams=%5B%22com.ztesoft.res.frame.component.intelligent.inf.IntelligentSearchServiceInf%22%2C%22dynamticSearchQuery%22%2C%7B%22queryId%22%3A18444%2C%22keyWord%22%3A%22";
                postData += freeAccountBindViewModel.Account;
                postData += "%22%2C%22condition%22%3A%5B%7B%22fieldName%22%3A%22resource_attribute%22%2C%22fieldValue%22%3A%221485682%2C1485685%2C1485685%2C1485684%22%7D%5D%2C%22start%22%3A0%2C%22pageSize%22%3A16%2C%22roleId%22%3A270%2C%22sort%22%3A%5B%5D%2C%22resRoleId%22%3A%22%22%2C%22specialityId%22%3A%22312%22%7D%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1603434792138";
                var referer = "http://10.40.95.32:8012/im-res-product-pub/intelligent.html?ot=rt&qi=18444&roi=&spi=312&st=card&wd=" + freeAccountBindViewModel.Account;

                var returnPage = RequestMothed.PostCallServerFunctionMethod(GlobalValues.CallServerFunctionUri, GlobalValues.Host, GlobalValues.Origin, referer, GlobalValues.Cookies, postData);
                QueryAccountResultData queryAccountResultData = new QueryAccountResultData();
                queryAccountResultData = JsonConvert.DeserializeObject<QueryAccountResultData>(returnPage);
                AccountData accountData = new AccountData();
                accountData = JsonConvert.DeserializeObject<AccountData>(queryAccountResultData.data.result);

                if (accountData.total == "0") //未查到帐号 是不是输入错误？
                {
                    WriteOperateInfo("查询绑定帐号", "查询出错！未发现：" + freeAccountBindViewModel.Account);
                }
                else if (accountData.total != "1")
                {
                    WriteOperateInfo("查询绑定帐号", "查询出错！" + freeAccountBindViewModel.Account + "请核实是否输入有误！");
                }
                else 
                { 
                    

                    //子产品管理
                    //POST http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr HTTP/1.1
                    //Host: 10.40.95.32:8012
                    //User - Agent: Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 82.0) Gecko / 20100101 Firefox / 82.0
                    //Accept: application / json, text / javascript, */*; q=0.01
                    //Accept-Language: zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2
                    //Accept-Encoding: gzip, deflate
                    //Content-Type: application/x-www-form-urlencoded; charset=UTF-8
                    //X-Requested-With: XMLHttpRequest
                    //Content-Length: 234
                    //Origin: http://10.40.95.32:8012
                    //Connection: keep-alive
                    //Referer: http://10.40.95.32:8012/im-res-product-pub/intelligent.html?_rd=1566719392&ot=rt&qi=18444&roi=&spi=312&wd=13815662015&st=card
                    //Cookie: SESSION=7d9a05a2-6667-4f2c-9107-e5600437f9fa; frame_language=zh_CN; BIGipServerNEWGX_ziyuanpeizhi_8013=1646839306.19743.0000

                    //_dyn_datasource_key=res&_callFunParams=%5B%22com.ztesoft.gis.module.mixBusiness.service.MixBusinessManageService%22%2C%22getMixChild%22%2C%22
                    //1527200003852025
                    //%22%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1603437408662
                    referer = "http://10.40.95.32:8012/im-res-product-pub/intelligent.html?_rd=1566719392&ot=rt&qi=18444&roi=&spi=312&wd=" + freeAccountBindViewModel.Account + "&st=card";
                    postData = "_dyn_datasource_key=res&_callFunParams=%5B%22com.ztesoft.gis.module.mixBusiness.service.MixBusinessManageService%22%2C%22getMixChild%22%2C%22";
                    postData += accountData.results[0].id;
                    postData += "%22%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1603437408662";
                    returnPage = RequestMothed.PostCallServerFunctionMethod(GlobalValues.CallServerFunctionUri, GlobalValues.Host, GlobalValues.Origin, referer, GlobalValues.Cookies, postData);
                    QueryChildProductResultData queryChildProductResultData = new QueryChildProductResultData();
                    queryChildProductResultData = JsonConvert.DeserializeObject<QueryChildProductResultData>(returnPage);
                    //获取其中的个人宽带信息 BUSINESS_ID=100045794411 以备以下查询；

                    
                    foreach (var item in queryChildProductResultData.data)
                    {
                        if (item.PRODUCT_TYPE == "个人宽带") //PRODUCT_ID=990018  PRODUCT_TYPE=个人宽带 
                        {
                            BUSINESS_ID = item.BUSINESS_ID.ToString();
                            break;
                        }
                    }
                    if (string.IsNullOrEmpty(BUSINESS_ID))
                    {
                        //无宽带产品返回
                        //Canvas_Waiting.Dispatcher.Invoke(new Action(() =>
                        //{
                        //    Canvas_Waiting.Visibility = Visibility.Collapsed;
                        //}));
                        //MessageBox.Show(freeAccountBindViewModel.Account + "无个人宽带业务！", "信息：", MessageBoxButton.OK, MessageBoxImage.Information);
                        WriteOperateInfo("游离绑定：", freeAccountBindViewModel.Account + "无个人宽带业务！");
                    }
                    else
                    {

                        if (!accountData.results[0].OPR_STATE_ID.Equals("完成"))
                        {
                            WriteOperateInfo("查询绑定帐号", freeAccountBindViewModel.Account + "业务进行中，请自行查询是否绑定成功！");

                        }

                        //地址游离
                        //POST http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr HTTP/1.1
                        //Host: 10.40.95.32:8012
                        //User - Agent: Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 82.0) Gecko / 20100101 Firefox / 82.0
                        //Accept: application / json, text / javascript, */*; q=0.01
                        //Accept-Language: zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2
                        //Accept-Encoding: gzip, deflate
                        //Content-Type: application/x-www-form-urlencoded; charset=UTF-8
                        //X-Requested-With: XMLHttpRequest
                        //Content-Length: 230
                        //Origin: http://10.40.95.32:8012
                        //Connection: keep-alive
                        //Referer: http://10.40.95.32:8012/im-res-product-pub/intelligent.html?ot=rt&qi=18444&roi=&spi=312&st=card&wd=13775404319
                        //Cookie: SESSION=5f75ddb9-39ac-41ed-8b2f-028039355ad9; 9285-remember-A_SPC_REGION_REGION_NAME=%5B%22%E9%87%91%E7%A7%8B%E6%83%85%E7%BC%98%22%2C%22%E4%B8%AD%E5%A4%AE%E5%8D%8E%E5%BA%9C%22%5D; frame_language=zh_CN

                        //_dyn_datasource_key=res&_callFunParams=%5B%22com.ztesoft.gis.module.mixBusiness.service.MixBusinessManageService%22%2C%22mixFreeAddr%22%2C%22
                        //100123386705
                        //%22%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1604629584759
                        referer = "http://10.40.95.32:8012/im-res-product-pub/intelligent.html?ot=rt&qi=18444&roi=&spi=312&st=card&wd=" + freeAccountBindViewModel.Account;
                        postData = "_dyn_datasource_key=res&_callFunParams=%5B%22com.ztesoft.gis.module.mixBusiness.service.MixBusinessManageService%22%2C%22mixFreeAddr%22%2C%22";
                        postData += BUSINESS_ID;
                        postData += "%22%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1604629584759";
                        returnPage = RequestMothed.PostCallServerFunctionMethod(GlobalValues.CallServerFunctionUri, GlobalValues.Host, GlobalValues.Origin, referer, GlobalValues.Cookies, postData);
                        //端口游离
                        //POST http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr HTTP/1.1
                        //Host: 10.40.95.32:8012
                        //User - Agent: Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 82.0) Gecko / 20100101 Firefox / 82.0
                        //Accept: application / json, text / javascript, */*; q=0.01
                        //Accept-Language: zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2
                        //Accept-Encoding: gzip, deflate
                        //Content-Type: application/x-www-form-urlencoded; charset=UTF-8
                        //X-Requested-With: XMLHttpRequest
                        //Content-Length: 230
                        //Origin: http://10.40.95.32:8012
                        //Connection: keep-alive
                        //Referer: http://10.40.95.32:8012/im-res-product-pub/intelligent.html?ot=rt&qi=18444&roi=&spi=312&st=card&wd=13775404319
                        //Cookie: SESSION=5f75ddb9-39ac-41ed-8b2f-028039355ad9; 9285-remember-A_SPC_REGION_REGION_NAME=%5B%22%E9%87%91%E7%A7%8B%E6%83%85%E7%BC%98%22%2C%22%E4%B8%AD%E5%A4%AE%E5%8D%8E%E5%BA%9C%22%5D; frame_language=zh_CN

                        //_dyn_datasource_key=res&_callFunParams=%5B%22com.ztesoft.gis.module.mixBusiness.service.MixBusinessManageService%22%2C%22mixFreePort%22%2C%22
                        //100123386710
                        //%22%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1604629607837
                        referer = "http://10.40.95.32:8012/im-res-product-pub/intelligent.html?ot=rt&qi=18444&roi=&spi=312&st=card&wd=" + freeAccountBindViewModel.Account;
                        postData = "_dyn_datasource_key=res&_callFunParams=%5B%22com.ztesoft.gis.module.mixBusiness.service.MixBusinessManageService%22%2C%22mixFreePort%22%2C%22";
                        postData += BUSINESS_ID;
                        postData += "%22%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1604629607837";
                        returnPage = RequestMothed.PostCallServerFunctionMethod(GlobalValues.CallServerFunctionUri, GlobalValues.Host, GlobalValues.Origin, referer, GlobalValues.Cookies, postData);

                        //MessageBox.Show(freeAccountBindViewModel.Account + "游离成功！\n请绑定地址和端口！", "信息：", MessageBoxButton.OK, MessageBoxImage.Information);

                        //显示处理部分界面

                        freeAccountBindViewModel.BindingAddress = freeAccountBindViewModel.SelectedAddressData.STAND_NAME;


                        freeAccountBindViewModel.BindingBoxName = freeAccountBindViewModel.SelectedAddressData.EQP_NAME;




                        //显示箱体内设备
                        //查询箱体内设备
                        //POST http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr HTTP/1.1
                        //Host: 10.40.95.32:8012
                        //Connection: keep - alive
                        //Content - Length: 301
                        //Accept: application / json, text / javascript, */*; q=0.01
                        //X-Requested-With: XMLHttpRequest
                        //User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.75 Safari/537.36 Edg/86.0.622.38
                        //Content-Type: application/x-www-form-urlencoded; charset=UTF-8
                        //Origin: http://10.40.95.32:8012
                        //Referer: http://10.40.95.32:8012/im-res-product-pub/deviceManage.html?ei=000107043500000005076006&rti=704&qi=9267&width=1200
                        //Accept-Encoding: gzip, deflate
                        //Accept-Language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
                        //Cookie: SESSION=6e368fce-a421-4a71-88eb-cd71d1d8ffba; frame_language=zh_CN

                        //_callFunParams=%5B%22com.zres.product.resmaster.device.common.intf.IDeviceConfigService%22%2C%22queryDevRelationResList%22%2C%22
                        //000107043500000005076006
                        //%22%2C%222530%22%2C%222%22%2C%22%E5%88%86%E5%85%89%E5%99%A8%22%2C704%2Ctrue%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1602747484357
                        referer = "http://10.40.95.32:8012/im-res-product-pub/deviceManage.html?ei=" + freeAccountBindViewModel.SelectedAddressData.EQP_ID + "&rti=704&qi=9267&width=1200";
                        postData = "";
                        postData += "_callFunParams=%5B%22com.zres.product.resmaster.device.common.intf.IDeviceConfigService%22%2C%22queryDevRelationResList%22%2C%22";
                        postData += freeAccountBindViewModel.SelectedAddressData.EQP_ID;
                        postData += "%22%2C%222530%22%2C%222%22%2C%22%E5%88%86%E5%85%89%E5%99%A8%22%2C704%2Ctrue%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1602747484357";

                        returnPage = RequestMothed.PostCallServerFunctionMethod(GlobalValues.CallServerFunctionUri, GlobalValues.Host, GlobalValues.Origin, referer, GlobalValues.Cookies, postData);
                        BoxPosesData boxPosesData = new BoxPosesData();
                        boxPosesData = JsonConvert.DeserializeObject<BoxPosesData>(returnPage);

                        foreach (var item in boxPosesData.data)
                        {
                            if (item.buizDesc == "分光器")
                            {
                                freeAccountBindViewModel.BoxPoses = item.buizList;
                                break;
                            }
                        }

                        WriteOperateInfo("游离绑定", freeAccountBindViewModel.Account + "游离完成,请选择绑定分光器及端口！");

                    }

                }
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    freeAccountBindViewModel.ShowStackPanel = Visibility.Visible;
                    freeAccountBindViewModel.GridIsEnabled = true;
                    freeAccountBindViewModel.ShowProgress = Visibility.Collapsed;
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

        /// <summary>
        /// 选择分光器查询空闲端口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_DestPos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            
            //收集 目标资源信息
            if (ComboBox_DestPos.SelectedItem == null) return;
 
            

            freeAccountBindViewModel.SelectPosData = (BoxPosesData.BuizListItem)ComboBox_DestPos.SelectedItem;

            WriteOperateInfo("游离绑定","选择设备"+ freeAccountBindViewModel.SelectPosData.RES_NAME);

            //查询选定分光器的端口信息并加入列表
            //POST http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr HTTP/1.1
            //Host: 10.40.95.32:8012
            //Connection: keep - alive
            //Content - Length: 213
            //Accept: application / json, text / javascript, */*; q=0.01
            //X-Requested-With: XMLHttpRequest
            //User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/86.0.4240.75 Safari/537.36 Edg/86.0.622.38
            //Content-Type: application/x-www-form-urlencoded; charset=UTF-8
            //Origin: http://10.40.95.32:8012
            //Referer: http://10.40.95.32:8012/im-res-product-pub/deviceManage.html?ei=000125303100000003307317&rti=2530&qi=11114&width=1200
            //Accept-Encoding: gzip, deflate
            //Accept-Language: zh-CN,zh;q=0.9,en;q=0.8,en-GB;q=0.7,en-US;q=0.6
            //Cookie: SESSION=7473815f-071d-4b96-9a22-bf0997e48879; frame_language=zh_CN

            //_callFunParams=%5B%22com.ztesoft.gis.module.boxManage.service.ComDpAddrSegmService%22%2C%22queryDevPort%22%2C%22
            //000125303100000003307317
            //%22%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1602724138906


            var referer = "http://10.40.95.32:8012/im-res-product-pub/deviceManage.html?ei=" + freeAccountBindViewModel.SelectPosData.RES_ID + "&qi=11114&width=1200";
            var postData = "";
            postData += "_callFunParams=%5B%22com.ztesoft.gis.module.boxManage.service.ComDpAddrSegmService%22%2C%22queryDevPort%22%2C%22";
            postData += freeAccountBindViewModel.SelectPosData.RES_ID;
            postData += "%22%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1602724138906";
            
            var returnPage = RequestMothed.PostCallServerFunctionMethod(GlobalValues.CallServerFunctionUri, GlobalValues.Host, GlobalValues.Origin, referer, GlobalValues.Cookies, postData);
            var posPortData = new PosPortData();
            posPortData = JsonConvert.DeserializeObject<PosPortData>(returnPage);
            //加入空闲PON到列表
            freeAccountBindViewModel.BindingPosPorts.Clear();
            foreach (var item in posPortData.data.rows)
            {
                if (item.OPR_STATE == "空闲")
                {
                    freeAccountBindViewModel.BindingPosPorts.Add(item);
                }
            }
           
            if (freeAccountBindViewModel.BindingPosPorts.Count==0)
            {
                //MessageBox.Show(buizListItem.RES_NAME + "无空闲端口！", "提示：", MessageBoxButton.OK, MessageBoxImage.Information);
                WriteOperateInfo("游离绑定，端口查询", freeAccountBindViewModel.SelectPosData.RES_NAME + "无空闲端口！");
            }
        }

        /// <summary>
        /// 选择的目标端口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox_DestPort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //收集 目标资源信息
            if (ComboBox_DestPort.SelectedItem == null) return;
            freeAccountBindViewModel.SelectPosPortData = (PosPortData.RowsItem)ComboBox_DestPort.SelectedItem;
            WriteOperateInfo("游离绑定", "选择目标端口" + freeAccountBindViewModel.SelectPosPortData.NO);
        }

        /// <summary>
        /// 绑定业务帐号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Bind_Click(object sender, RoutedEventArgs e)
        {
            if (freeAccountBindViewModel.SelectPosData == null || freeAccountBindViewModel.SelectPosPortData == null)
            {
                WriteOperateInfo("游离绑定", "请选择目标分光器和目标端口！");
            }


            Task.Run(new Action(() =>
            {

                Application.Current.Dispatcher.Invoke(new Action(() =>
            {

                freeAccountBindViewModel.GridIsEnabled = false;
                freeAccountBindViewModel.ShowProgress = Visibility.Visible;
            }));


                //根据小区名查询ID备用
                //POST http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr HTTP/1.1
                //Host: 10.40.95.32:8012
                //User - Agent: Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 82.0) Gecko / 20100101 Firefox / 82.0
                //Accept: application / json, text / javascript, */*; q=0.01
                //Accept-Language: zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2
                //Accept-Encoding: gzip, deflate
                //Content-Type: application/x-www-form-urlencoded; charset=UTF-8
                //X-Requested-With: XMLHttpRequest
                //Content-Length: 925
                //Origin: http://10.40.95.32:8012
                //Connection: keep-alive
                //Referer: http://10.40.95.32:8012/im-res-product-pub/intelligent.html?_rd=1509578319&ot=rt&qi=18444&roi=&spi=312&wd=
                //13775404319
                //&st=ssoS-324835-429uxGgvkuWV-sRes
                //Cookie: SESSION=7a75283d-5da9-4afe-ac3a-20a81ccb9dd4; 9285-remember-A_SPC_REGION_REGION_NAME=%5B%22%E9%87%91%E7%A7%8B%E6%83%85%E7%BC%98%22%2C%22%E4%B8%AD%E5%A4%AE%E5%8D%8E%E5%BA%9C%22%5D; frame_language=zh_CN

                //_callFunParams=%5B%22com.ztesoft.res.frame.component.query.inf.DynamicQueryServiceInf%22%2C%22queryDynamicData%22%2C%7B%22queryId%22%3A9285%2C%22envDomainId%22%3A%22%22%2C%22roleId%22%3A%22270%22%2C%22page%22%3A1%2C%22rowNum%22%3A%2220%22%2C%22isDistinct%22%3A0%2C%22queryData%22%3A%5B%7B%22field%22%3A%22A.REGION_NAME%22%2C%22condition%22%3A%22like%22%2C%22value%22%3A%22
                //%E9%87%91%E7%A7%8B%E6%83%85%E7%BC%98
                //%22%2C%22lowerupper%22%3Afalse%2C%22inputType%22%3A%22input_text%22%2C%22propertyType%22%3A%221%22%2C%22propertyId%22%3A136720%2C%22fieldName%22%3A%22REGION_NAME%22%2C%22filterId%22%3A90931325%2C%22queryPropDesc%22%3A%22%E5%B0%8F%E5%8C%BA%E5%90%8D%E7%A7%B0%22%2C%22serialNo%22%3A%22%22%2C%22resTypeIdPrt%22%3A%22%22%2C%22propSpecId%22%3A%22%22%2C%22queryPropertyId%22%3A6087353%7D%5D%2C%22asteriskMarkRules%22%3A%7B%7D%2C%22totalFlag%22%3A0%7D%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1604647176690
                var referer = "http://10.40.95.32:8012/im-res-product-pub/intelligent.html?_rd=1509578319&ot=rt&qi=18444&roi=&spi=312&wd=" + freeAccountBindViewModel.Account + "&st=ssoS-324835-429uxGgvkuWV-sRes";
                var postData = "_callFunParams=%5B%22com.ztesoft.res.frame.component.query.inf.DynamicQueryServiceInf%22%2C%22queryDynamicData%22%2C%7B%22queryId%22%3A9285%2C%22envDomainId%22%3A%22%22%2C%22roleId%22%3A%22270%22%2C%22page%22%3A1%2C%22rowNum%22%3A%2220%22%2C%22isDistinct%22%3A0%2C%22queryData%22%3A%5B%7B%22field%22%3A%22A.REGION_NAME%22%2C%22condition%22%3A%22like%22%2C%22value%22%3A%22";
                postData += System.Web.HttpUtility.UrlEncode(freeAccountBindViewModel.BindingComArea, Encoding.UTF8);
                postData += "%22%2C%22lowerupper%22%3Afalse%2C%22inputType%22%3A%22input_text%22%2C%22propertyType%22%3A%221%22%2C%22propertyId%22%3A136720%2C%22fieldName%22%3A%22REGION_NAME%22%2C%22filterId%22%3A90931325%2C%22queryPropDesc%22%3A%22%E5%B0%8F%E5%8C%BA%E5%90%8D%E7%A7%B0%22%2C%22serialNo%22%3A%22%22%2C%22resTypeIdPrt%22%3A%22%22%2C%22propSpecId%22%3A%22%22%2C%22queryPropertyId%22%3A6087353%7D%5D%2C%22asteriskMarkRules%22%3A%7B%7D%2C%22totalFlag%22%3A0%7D%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1604647176690";


                var returnPage = RequestMothed.PostCallServerFunctionMethod(GlobalValues.CallServerFunctionUri, GlobalValues.Host, GlobalValues.Origin, referer, GlobalValues.Cookies, postData);
                QueryComAreaResultData queryComAreaResultData = new QueryComAreaResultData();
                queryComAreaResultData = JsonConvert.DeserializeObject<QueryComAreaResultData>(returnPage);

                QueryComAreaResultData.RowsItem selectComAreaData = new QueryComAreaResultData.RowsItem();

                foreach (var com in queryComAreaResultData.data.rows)
                {
                    if (com.ALIAS1.Equals(freeAccountBindViewModel.BindingComArea))
                    {
                        selectComAreaData = com;
                        break;
                    }
                }
                if (selectComAreaData == null)
                {
                    //MessageBox.Show("小区名称错误！", "错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    WriteOperateInfo("游离绑定：", "小区名称错误！");

                }
                else
                {
                    //变更小区
                    //POST http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr HTTP/1.1
                    //Host: 10.40.95.32:8012
                    //User - Agent: Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 82.0) Gecko / 20100101 Firefox / 82.0
                    //Accept: application / json, text / javascript, */*; q=0.01
                    //Accept-Language: zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2
                    //Accept-Encoding: gzip, deflate
                    //Content-Type: application/x-www-form-urlencoded; charset=UTF-8
                    //X-Requested-With: XMLHttpRequest
                    //Content-Length: 277
                    //Origin: http://10.40.95.32:8012
                    //Connection: keep-alive
                    //Referer: http://10.40.95.32:8012/im-res-product-pub/intelligent.html?_rd=1509578319&ot=rt&qi=18444&roi=&spi=312&wd=13775404319&st=ssoS-324835-429uxGgvkuWV-sRes
                    //Cookie: SESSION=7a75283d-5da9-4afe-ac3a-20a81ccb9dd4; 9285-remember-A_SPC_REGION_REGION_NAME=%5B%22%E9%87%91%E7%A7%8B%E6%83%85%E7%BC%98%22%2C%22%E4%B8%AD%E5%A4%AE%E5%8D%8E%E5%BA%9C%22%5D; frame_language=zh_CN

                    //_dyn_datasource_key=res&_callFunParams=%5B%22com.ztesoft.gis.module.freeAccount.service.AccountManageService%22%2C%22changeCom%22%2C%22
                    //100123386710
                    //%22%2C%22
                    //000102090100000000042775
                    //%22%2C%22
                    //13775404319
                    //%22%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1604647179007

                    referer = "http://10.40.95.32:8012/im-res-product-pub/intelligent.html?_rd=1509578319&ot=rt&qi=18444&roi=&spi=312&wd=" + freeAccountBindViewModel.Account + "&st=ssoS-324835-429uxGgvkuWV-sRes";
                    postData = "_dyn_datasource_key=res&_callFunParams=%5B%22com.ztesoft.gis.module.freeAccount.service.AccountManageService%22%2C%22changeCom%22%2C%22";
                    postData += BUSINESS_ID;
                    postData += "%22%2C%22";
                    postData += selectComAreaData.ALIAS0;
                    postData += "%22%2C%22";
                    postData += freeAccountBindViewModel.Account;
                    postData += "%22%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1604647179007";
                    returnPage = RequestMothed.PostCallServerFunctionMethod(GlobalValues.CallServerFunctionUri, GlobalValues.Host, GlobalValues.Origin, referer, GlobalValues.Cookies, postData);

                    //绑定地址
                    //POST http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr HTTP/1.1
                    //Host: 10.40.95.32:8012
                    //User - Agent: Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 82.0) Gecko / 20100101 Firefox / 82.0
                    //Accept: application / json, text / javascript, */*; q=0.01
                    //Accept-Language: zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2
                    //Accept-Encoding: gzip, deflate
                    //Content-Type: application/x-www-form-urlencoded; charset=UTF-8
                    //X-Requested-With: XMLHttpRequest
                    //Content-Length: 464
                    //Origin: http://10.40.95.32:8012
                    //Connection: keep-alive
                    //Referer: http://10.40.95.32:8012/im-res-product-pub/intelligent.html?_rd=1509578319&ot=rt&qi=18444&roi=&spi=312&wd=13775404319&st=ssoS-324835-429uxGgvkuWV-sRes
                    //Cookie: SESSION=d9e79088-cc1a-411e-8425-70e75ae20d0a; 9285-remember-A_SPC_REGION_REGION_NAME=%5B%22%E9%87%91%E7%A7%8B%E6%83%85%E7%BC%98%22%2C%22%E4%B8%AD%E5%A4%AE%E5%8D%8E%E5%BA%9C%22%5D; frame_language=zh_CN

                    //_dyn_datasource_key=res&_callFunParams=%5B%22com.ztesoft.gis.module.mixBusiness.service.MixBusinessManageService%22%2C%22addrChane%22%2C%22
                    //100123386710
                    //%22%2C%22
                    //%E8%BF%9E%E4%BA%91%E6%B8%AF%E5%9C%B0%E5%8C%BA%E6%96%B0%E6%B5%B7%E6%96%B0%E6%B5%A6%E5%8C%BA%E5%BB%BA%E8%AE%BE%E4%B8%9C%E8%B7%AF%E9%87%91%E7%A7%8B%E6%83%85%E7%BC%987%E6%A0%8B1%E5%8D%95%E5%85%83102
                    //%22%2C%22
                    //000102140100000067229456
                    //%22%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1604651945049

                    referer = "http://10.40.95.32:8012/im-res-product-pub/intelligent.html?_rd=1509578319&ot=rt&qi=18444&roi=&spi=312&wd=" + freeAccountBindViewModel.Account + "&st=ssoS-324835-429uxGgvkuWV-sRes";

                    postData = "_dyn_datasource_key=res&_callFunParams=%5B%22com.ztesoft.gis.module.mixBusiness.service.MixBusinessManageService%22%2C%22addrChane%22%2C%22";
                    postData += freeAccountBindViewModel.Account;
                    postData += "%22%2C%22";
                    postData += System.Web.HttpUtility.UrlEncode(freeAccountBindViewModel.SelectedAddressData.STAND_NAME, Encoding.UTF8);
                    postData += "%22%2C%22";
                    postData += freeAccountBindViewModel.SelectedAddressData.SEGM_ID;
                    postData += "%22%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1604651945049";
                    returnPage = RequestMothed.PostCallServerFunctionMethod(GlobalValues.CallServerFunctionUri, GlobalValues.Host, GlobalValues.Origin, referer, GlobalValues.Cookies, postData);


                    //绑定端口
                    //POST http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr HTTP/1.1
                    //Host: 10.40.95.32:8012
                    //User - Agent: Mozilla / 5.0(Windows NT 10.0; Win64; x64; rv: 82.0) Gecko / 20100101 Firefox / 82.0
                    //Accept: application / json, text / javascript, */*; q=0.01
                    //Accept-Language: zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2
                    //Accept-Encoding: gzip, deflate
                    //Content-Type: application/x-www-form-urlencoded; charset=UTF-8
                    //X-Requested-With: XMLHttpRequest
                    //Content-Length: 269
                    //Origin: http://10.40.95.32:8012
                    //Connection: keep-alive
                    //Referer: http://10.40.95.32:8012/im-res-product-pub/intelligent.html?_rd=1586621549&ot=rt&qi=18444&roi=&spi=312&wd=13775404319&&st=ssoS-326688-pgXCS2h9lOCM-sRes
                    //Cookie: SESSION=d9e79088-cc1a-411e-8425-70e75ae20d0a; 9285-remember-A_SPC_REGION_REGION_NAME=%5B%22%E9%87%91%E7%A7%8B%E6%83%85%E7%BC%98%22%2C%22%E4%B8%AD%E5%A4%AE%E5%8D%8E%E5%BA%9C%22%5D; frame_language=zh_CN

                    //_dyn_datasource_key=res&_callFunParams=%5B%22com.ztesoft.gis.module.mixBusiness.service.MixBusinessManageService%22%2C%22linkPort%22%2C%22
                    //100123386710
                    //%22%2C%22
                    //000103100100000111889845
                    //%22%2C%22%22%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1604652925860
                    referer = "http://10.40.95.32:8012/im-res-product-pub/intelligent.html?_rd=1509578319&ot=rt&qi=18444&roi=&spi=312&wd=" + freeAccountBindViewModel.Account + "&st=ssoS-324835-429uxGgvkuWV-sRes";
                    postData = "_dyn_datasource_key=res&_callFunParams=%5B%22com.ztesoft.gis.module.mixBusiness.service.MixBusinessManageService%22%2C%22linkPort%22%2C%22";
                    postData += BUSINESS_ID;
                    postData += "%22%2C%22";
                    postData += freeAccountBindViewModel.SelectPosPortData.ID;
                    postData += "%22%2C%22%22%5D&_callServerIsencrypt=off&ajaxSource=_res_ajax&_timeStamp=1604652925860";
                    returnPage = RequestMothed.PostCallServerFunctionMethod(GlobalValues.CallServerFunctionUri, GlobalValues.Host, GlobalValues.Origin, referer, GlobalValues.Cookies, postData);
                    //MessageBox.Show(freeAccountBindViewModel.Account + "绑定完毕！", "信息", MessageBoxButton.OK, MessageBoxImage.Information);

                    WriteOperateInfo("游离绑定", freeAccountBindViewModel.Account + "绑定完毕！");
                    

                }

                Application.Current.Dispatcher.Invoke(new Action(() =>
                {

                    freeAccountBindViewModel.GridIsEnabled = true;
                    freeAccountBindViewModel.ShowProgress = Visibility.Collapsed;
                    this.Close();
                }));

            }));


        }

        
    }
}
