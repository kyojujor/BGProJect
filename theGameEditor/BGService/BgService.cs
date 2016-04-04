using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositeControllerDemo;
using BGModel.CommonHelper;
using BGModel;
using System.Web;

namespace BGService
{
    public class BgService
    {
        /// <summary>
        /// 将model绑定给labelText
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
                    //backgroundWorkerFormMain.RunWorkerCompleted+=
                    ControllerList[i].Visible = true;
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
                    ControllerList[i].LabelText.Text = string.Empty;
                    ControllerList[i].textBoxContent.Text = string.Empty;
                    ControllerList[i].LabelRelate.Text = string.Empty;
                    ControllerList[i].Visible = false;
                }
            }

        }

        /// <summary>
        /// 根据
        /// </summary>
        public static List<bg_ItemBaseModel> ItemSearch(string keyWord, List<bg_ItemBaseModel> model, bool isQuery = false)
        {
            keyWord = keyWord.Trim();
            if (model==null)
            {
                throw new Exception("ItemSearch error Null");
            }

            List<bg_ItemBaseModel> list = new List<bg_ItemBaseModel>();
            list.AddRange(SingleItemSearch(keyWord, model, isQuery));
           
            return list;
        }

        public static List<bg_ItemBaseModel> SingleItemSearch(string keyWord, List<bg_ItemBaseModel> InModel,bool isQuery)
        {
            if (InModel==null || InModel.Count==0 || string.IsNullOrWhiteSpace(keyWord))
            {
                return null;
            }

            if (isQuery)
            {
                return InModel.FindAll(x => x.ID==(keyWord));
            }
            else
            {
                return InModel.FindAll(x => x.ID.Contains(keyWord) || x.Name.Contains(keyWord) || x.Desc.Contains(keyWord) || x.Description.Contains(keyWord));
            }
            }




        }

    public class SplitHelper
    {
        public static void SplitDropStr<T>(string input, ref List<T> ret) where T : new()
        {
            var res = new List<T>();
            if (!string.IsNullOrWhiteSpace(input))
            {
                var itemList = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                if (itemList != null && itemList.Count > 0)
                {
                    foreach (var item in itemList)
                    {
                        var model = new T();
                        var proplist = typeof(T).GetProperties().ToList();
                        var list = item.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                        if (proplist.Count < list.Count)
                            return;

                        for (var i = 1; i < list.Count+1; i++)
                        {
                            //if (proplist[i].Name.ToLower() == "name")
                            //{
                            //    proplist[i].SetValue(model,name);
                            //}
                            //else
                            {
                                if (proplist[i].PropertyType == typeof(string))
                                {
                                    proplist[i].SetValue(model, list[i-1]);
                                }
                                if (proplist[i].PropertyType == typeof(int))
                                {
                                    proplist[i].SetValue(model, Convert.ToInt32(list[i-1]));
                                }
                            }
                        }
                        res.Add(model);
                    }
                    ret = res;
                }
            }
        }
    }

}
