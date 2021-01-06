using NewPortalAssiant.Common;
using NewPortalAssiant.PortalData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NewPortalAssiant.ViewModel
{
    public class ChangeAddressViewModel:NotifyBase
    {

        public string Cookies { get; set; }

        public string Host = "10.40.95.32:8012";
        public string Origin = "http://10.40.95.32:8012";

        public string CallServerFunctionUri = "http://10.40.95.32:8012/im-res-product-pub/common/service/callServerFunction.spr";

        /// <summary>
        /// 选取的地址
        /// </summary>
        private BoxAddressData.DataListItem _selectedAddressData = new BoxAddressData.DataListItem();

        public BoxAddressData.DataListItem SelectedAddressData
        {
            get { return _selectedAddressData; }
            set { _selectedAddressData = value; this.DoNotify(); }
        }

        /// <summary>
        /// 原地址
        /// </summary>
        private string _sourceAddress;

        public string SourceAddress
        {
            get { return _sourceAddress; }
            set { _sourceAddress = value; this.DoNotify(); }
        }

        /// <summary>
        /// 原箱体
        /// </summary>
        private string _sourceBoxName;

        public string SourceBoxName
        {
            get { return _sourceBoxName; }
            set { _sourceBoxName = value; this.DoNotify(); }
        }

        private ObservableCollection<QueryComAreaBoxResultData.DataItem> _boxesDatas = new ObservableCollection<QueryComAreaBoxResultData.DataItem>();

        public ObservableCollection<QueryComAreaBoxResultData.DataItem> BoxesDatas
        {
            get { return _boxesDatas; }
            set { _boxesDatas = value;this.DoNotify(); }
        }

        private ObservableCollection<QueryComAreaBoxResultData.DataItem> _chooseboxesDatas = new ObservableCollection<QueryComAreaBoxResultData.DataItem>();

        public ObservableCollection<QueryComAreaBoxResultData.DataItem> ChooseBoxesDatas
        {
            get { return _chooseboxesDatas; }
            set { _chooseboxesDatas = value; this.DoNotify(); }
        }
    }
}
