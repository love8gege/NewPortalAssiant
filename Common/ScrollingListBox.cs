using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace NewPortalAssiant.Common
{
    public class ScrollingListBox:ListBox
    {
        protected override void OnItemsChanged(System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)//此处需要判空
            {
                int newItemCount = e.NewItems.Count;

                if (newItemCount > 0)
                    this.ScrollIntoView(e.NewItems[newItemCount - 1]);

                base.OnItemsChanged(e);
            }
        }
       
    }
}
