using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositeControllerDemo;
using BGModel.CommonHelper;

namespace BGService
{
    public class BgService
    {
        /// <summary>
        /// 将model的特性或者name绑定给labelText
        /// </summary>
        /// <param name="ControllerList"></param>
        /// <param name="itemModel"></param>
        public static void ItemBlindToLabelTextBox(List<LabelTextBox> ControllerList, object itemModel)
        {
            if (ControllerList == null || ControllerList.Count == 0 || itemModel == null)
            {
                throw new Exception("ItemBlindToLabelTextBox Error3");
            }

            var itemtype = itemModel.GetType();

            var PropList = itemtype.GetProperties().ToList();

            if (PropList == null || PropList.Count == 0)
            {
                throw new Exception("ItemBlindToLabelTextBox Error4");
            }
            if (ControllerList.Count < PropList.Count)
            {
                throw new Exception("ItemBlindToLabelTextBox 属性数量大于控件数量");
            }

            var Count = ControllerList.Count;

            for (var i = 0; i < Count; i++)
            {
                if (i < PropList.Count)//还未超出Model 的属性值个数
                {
                    var text = PropList[i].GetValue(itemModel, null);
                    if (text == null)
                    {
                        ControllerList[i].textBoxContent.Text = null;
                    }
                    else
                    {
                        ControllerList[i].textBoxContent.Text = PropList[i].GetValue(itemModel, null).ToString();
                    }

                    var attr = PropList[i].GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
                    if (attr == null || string.IsNullOrWhiteSpace(((DescriptionAttribute)attr).Desc))
                    {
                        ControllerList[i].LabelText.Text = PropList[i].Name;
                    }
                    else
                    {
                        ControllerList[i].LabelText.Text = ((DescriptionAttribute)attr).Desc;
                    }
                }
                else
                {
                    return;
                }
            }

        }
    }
}
