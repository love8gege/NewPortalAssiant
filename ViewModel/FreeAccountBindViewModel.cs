using NewPortalAssiant.Common;
using NewPortalAssiant.PortalData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace NewPortalAssiant.ViewModel
{
    public class FreeAccountBindViewModel:NotifyBase
    {
        
        
        /// <summary>
        /// 绑定帐号
        /// </summary>
        private string _account;

        public string Account
        {
            get { return _account; }
            set { _account = value; this.DoNotify(); }
        }

        /// <summary>
        /// 绑定的地址
        /// </summary>
        private string _bindingAddress;

        public string BindingAddress
        {
            get { return _bindingAddress; }
            set { _bindingAddress = value; this.DoNotify(); }
        }

        /// <summary>
        /// 绑定目标小区
        /// </summary>
        private string _bindingComArea;

        public string BindingComArea
        {
            get { return  _bindingComArea; }
            set {  _bindingComArea = value; this.DoNotify(); }
        }

        /// <summary>
        /// 绑定目标箱体分光器列表
        /// </summary>
        private string _bindingBoxName;

        public string BindingBoxName
        {
            get { return _bindingBoxName; }
            set { _bindingBoxName = value; this.DoNotify(); }
        }

        /// <summary>
        /// 绑定目标分光器端口列表
        /// </summary>
        private ObservableCollection<PosPortData.RowsItem> _bindingPosPorts=new ObservableCollection<PosPortData.RowsItem>();

        public ObservableCollection<PosPortData.RowsItem> BindingPosPorts
        {
            get { return _bindingPosPorts; }
            set { _bindingPosPorts = value; this.DoNotify(); }
        }


        /// <summary>
        /// 选取的地址
        /// </summary>
        private BoxAddressData.DataListItem _selectedAddressData = new BoxAddressData.DataListItem();

        public BoxAddressData.DataListItem SelectedAddressData
        {
            get { return _selectedAddressData; }
            set { _selectedAddressData = value; this.DoNotify(); }
        }

        private ObservableCollection<BoxPosesData.BuizListItem> _boxPoses=new ObservableCollection<BoxPosesData.BuizListItem>();

        public ObservableCollection<BoxPosesData.BuizListItem> BoxPoses
        {
            get { return _boxPoses; }
            set { _boxPoses = value; this.DoNotify(); }
        }

        private bool _gridIsEnabled;

        public bool GridIsEnabled
        {
            get { return _gridIsEnabled; }
            set { _gridIsEnabled = value; }
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

        private Visibility _showStackPanel;
        public Visibility ShowStackPanel
        {
            get { return _showStackPanel; }
            set
            {
                _showStackPanel = value;
                this.DoNotify();
            }
        }

        /// <summary>
        /// 选择分光器
        /// </summary>
        private BoxPosesData.BuizListItem _selectPosData;

        public BoxPosesData.BuizListItem SelectPosData
        {
            get { return _selectPosData; }
            set { _selectPosData = value;this.DoNotify(); }
        }

        /// <summary>
        /// 选择分光器
        /// </summary>
        private PosPortData.RowsItem _selectPosPortData;

        public PosPortData.RowsItem SelectPosPortData
        {
            get { return _selectPosPortData; }
            set { _selectPosPortData = value; this.DoNotify(); }
        }

    }
}
