using NewPortalAssiant.Common;
using NewPortalAssiant.Net;
using NewPortalAssiant.PortalData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NewPortalAssiant.ViewModel
{
    public class WorkViewModel:NotifyBase
    {
        

        public string Cookies { get; set; }

        public string Host = "10.40.95.32:8012";
        public string Origin = "http://10.40.95.32:8012";
        public string CallServerFunctionUri = "http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr";

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

        private bool _isEnabledView;

        public bool IsEnabledView
        {
            get { return _isEnabledView; }
            set { _isEnabledView = value; this.DoNotify(); }
        }


        /// <summary>
        /// 定义搜索框信息
        /// </summary>
        private string _searchOltInfo;
        public string SearchOltInfo
        {
            get { return _searchOltInfo; }
            set { _searchOltInfo = value;this.DoNotify(); }
        }
        /// <summary>
        /// 定义OLT名称
        /// </summary>
        private string _oltName;

        public string OltName
        {
            get { return _oltName; }
            set { _oltName = value;this.DoNotify(); }
        }

        /// <summary>
        /// 定义OLT信息列表
        /// </summary>
        private ObservableCollection<PonData.RowsItem> _ocRowsItem=new ObservableCollection<PonData.RowsItem>();

        public ObservableCollection<PonData.RowsItem> OcRowsItem
        {
            get { return _ocRowsItem; }
            set 
            {
                _ocRowsItem = value;   
                this.DoNotify(); }
        }
        /// <summary>
        /// 定义显示操作信息列表
        /// </summary>
        private ObservableCollection<string> _operateInfo = new ObservableCollection<string>();

        public ObservableCollection<string> OperateInfo
        {
            get { return _operateInfo; }
            set { _operateInfo = value;this.DoNotify(); }
        }

        // <summary>
        /// 定义光分纤箱分光器文本信息
        /// </summary>
        private string _guangjiaoPosName;

        public string GuangjiaoPosName
        {
            get { return _guangjiaoPosName; }
            set { _guangjiaoPosName = value;this.DoNotify(); }
        }

        /// <summary>
        /// 定义光交分光器端口信息列表
        /// </summary>
        private ObservableCollection<PosPortData.RowsItem> _guangjiaoPosPortRowsItems = new ObservableCollection<PosPortData.RowsItem>();

        public ObservableCollection<PosPortData.RowsItem> GuangjiaoPosPortRowsItems
        {
            get { return _guangjiaoPosPortRowsItems; }
            set
            {
                _guangjiaoPosPortRowsItems = value;
                this.DoNotify();
            }
        }

        // <summary>
        /// 定义分纤箱分光器文本信息
        /// </summary>
        private string _fenxianPosName;

        public string FenxianPosName
        {
            get { return _fenxianPosName; }
            set { _fenxianPosName = value; this.DoNotify(); }
        }

        private string _fenxianPosID;

        public string FenxianPosID
        {
            get { return _fenxianPosID; }
            set { _fenxianPosID = value; this.DoNotify(); }
        }


        /// <summary>
        /// 定义选择分纤分光器端口信息备用
        /// </summary>
        private PosPortData.RowsItem _selectedPosPortData = new PosPortData.RowsItem();

        public PosPortData.RowsItem SelectedPosPortData
        {
            get { return _selectedPosPortData; }
            set
            {
                _selectedPosPortData = value;
                this.DoNotify();
            }
        }


        /// <summary>
        /// 定义光交分光器端口信息列表
        /// </summary>
        private ObservableCollection<PosPortData.RowsItem> _fenxianPosPortRowsItems = new ObservableCollection<PosPortData.RowsItem>();

        public ObservableCollection<PosPortData.RowsItem> FenxianPosPortRowsItems
        {
            get { return _fenxianPosPortRowsItems; }
            set
            {
                _fenxianPosPortRowsItems = value;
                this.DoNotify();
            }
        }

        // <summary>
        /// 定义分纤箱归属小区文本信息
        /// </summary>
        private string _comAreaName;

        public string ComAreaName
        {
            get { return _comAreaName; }
            set { _comAreaName = value; this.DoNotify(); }
        }

        // <summary>
        /// 定义分光器归属分纤箱文本信息
        /// </summary>
        private string _fenxianBoxName;

        public string FenxianBoxName
        {
            get { return _fenxianBoxName; }
            set { _fenxianBoxName = value; this.DoNotify(); }
        }

        
        /// <summary>
        /// 定义选择分纤箱信息备用
        /// </summary>
        private FenxianBoxData.ResultsItem _fenxianBoxDataRowsItem = new FenxianBoxData.ResultsItem();

        public FenxianBoxData.ResultsItem FenxianBoxDataRowsItem
        {
            get { return _fenxianBoxDataRowsItem; }
            set
            {
                _fenxianBoxDataRowsItem = value;
                this.DoNotify();
            }
        }

        /// <summary>
        /// 定义箱体内分光器列表
        /// </summary>
        private ObservableCollection<BoxPosesData.BuizListItem> _boxPosesDataBuizListItems = new ObservableCollection<BoxPosesData.BuizListItem>();

        public ObservableCollection<BoxPosesData.BuizListItem> BoxPosesDataBuizListItems
        {
            get { return _boxPosesDataBuizListItems; }
            set
            {
                _boxPosesDataBuizListItems = value;
                this.DoNotify();
            }
        }

        private string _jkAccount;

        public string JkAccount
        {
            get { return _jkAccount; }
            set { _jkAccount = value; this.DoNotify(); }
        }

        private string _ywtAccount;

        public string YwtAccount
        {
            get { return _ywtAccount; }
            set { _ywtAccount = value; this.DoNotify(); }
        }



    }
}
