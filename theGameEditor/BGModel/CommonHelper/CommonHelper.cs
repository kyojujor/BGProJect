using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGModel.CommonHelper
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class DescriptionAttribute : Attribute
    {
        public string Desc { get; }

        public DescriptionAttribute(string str)
        {
            Desc = str;
        }

    }

    public class Bg_CommonHelper
    {


        public static List<bg_ItemBaseModel> ItemQuery(string keyWord, DataEnity model)
        {
            if (model == null)
            {
                throw new Exception("ItemSearch error Null");
            }

            List<bg_ItemBaseModel> list = new List<bg_ItemBaseModel>();

            //Func<List< bg_ItemBaseModel >,List

            var itemUseList = model.ItemUseModel.Select(x => x as bg_ItemBaseModel).ToList();
            var weaponList = model.ItemWeapon.Select(x => x as bg_ItemBaseModel).ToList();
            var equipmentList = model.ItemEquipment.Select(x => x as bg_ItemBaseModel).ToList();
            var EnergyShieldList = model.ItemEnergyShield.Select(x => x as bg_ItemBaseModel).ToList();

            list.AddRange(SingleItemQuery(keyWord, itemUseList));
            list.AddRange(SingleItemQuery(keyWord, weaponList));
            list.AddRange(SingleItemQuery(keyWord, equipmentList));
            list.AddRange(SingleItemQuery(keyWord, EnergyShieldList));
            return list;
        }

        public static List<bg_ItemBaseModel> SingleItemQuery(string keyWord, List<bg_ItemBaseModel> InModel)
        {
            if (InModel == null || InModel.Count == 0 || string.IsNullOrWhiteSpace(keyWord))
            {
                return null;
            }

            return InModel.FindAll(x => x.ID.Contains(keyWord));
        }
    }

}
