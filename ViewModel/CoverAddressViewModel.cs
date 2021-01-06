using NewPortalAssiant.Common;
using NewPortalAssiant.PortalData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NewPortalAssiant.ViewModel
{
    public class CoverAddressViewModel:NotifyBase
    {

        public string Cookies { get; set; }

        public string Host = "10.40.95.32:8012";
        public string Origin = "http://10.40.95.32:8012";

        public string CallServerFunctionUri = "http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr";

        /// <summary>
        /// 定义光交分光器端口信息列表
        /// </summary>
        private ObservableCollection<BoxAddressData.DataListItem> _boxAddressItems = new ObservableCollection<BoxAddressData.DataListItem>();

        public ObservableCollection<BoxAddressData.DataListItem> BoxAddressItems
        {
            get { return _boxAddressItems; }
            set
            {
                _boxAddressItems = value;
                this.DoNotify();
            }
        }

        private string _titleInfo;

        public string TitleInfo
        {
            get { return _titleInfo; }
            set { _titleInfo = value;this.DoNotify(); }
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

        private string _comAreaName;

        public string ComAreaName
        {
            get { return _comAreaName; }
            set { _comAreaName = value; }
        }

        private string _fenxianBoxName;

        public string FenxianBoxName
        {
            get { return _fenxianBoxName; }
            set { _fenxianBoxName = value; }
        }

        private ComAreaData.RowsItem _selectedComArea;

        public ComAreaData.RowsItem SelectedComArea
        {
            get { return _selectedComArea; }
            set { _selectedComArea = value; }
        }


    }
}
