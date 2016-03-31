﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompositeControllerDemo;
using BGModel.CommonHelper;
using BGModel;

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
        public static List<bg_ItemBaseModel> ItemSearch(string keyWord, DataEnity model)
        {
            if (model==null)
            {
                throw new Exception("ItemSearch error Null");
            }

            List<bg_ItemBaseModel> list = new List<bg_ItemBaseModel>();

            //Func<List< bg_ItemBaseModel >,List

            var itemUseList = model.ItemUseModel.Select(x => x as bg_ItemBaseModel).ToList();
            var weaponList = model.ItemWeapon.Select(x => x as bg_ItemBaseModel).ToList();
            var equipmentList = model.ItemEquipment.Select(x => x as bg_ItemBaseModel).ToList();
            var EnergyShieldList = model.ItemEnergyShield.Select(x => x as bg_ItemBaseModel).ToList();

            list.AddRange(SingleItemSearch(keyWord, itemUseList));
            list.AddRange(SingleItemSearch(keyWord, weaponList));
            list.AddRange(SingleItemSearch(keyWord, equipmentList));
            list.AddRange(SingleItemSearch(keyWord, EnergyShieldList));
            return list;

        }

        public static List<bg_ItemBaseModel> SingleItemSearch(string keyWord, List<bg_ItemBaseModel> InModel)
        {
            if (InModel==null || InModel.Count==0 || string.IsNullOrWhiteSpace(keyWord))
            {
                return null;
            }

            return InModel.FindAll(x => x.ID.Contains(keyWord) || x.Name.Contains(keyWord) || x.Desc.Contains(keyWord) || x.Description.Contains(keyWord));
        }
    }
}
