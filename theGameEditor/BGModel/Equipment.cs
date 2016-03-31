using BGModel.CommonHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGModel
{
    public class Equipment : bg_ItemBaseModel
    {
        [Description("ID")]
        public override string ID { get; set; }
        [Description("名称ID")]
        public override string Name { get; set; }

        [Description("名字关联说明")]
        public override string Desc { get; set; }
        [Description("描述关联说明")]
        public override string Description { get; set; }

        public string Only { get;set;}

        public string LimitedPack { get;set;}
        public string script { get;set;}
        public string ItemType { get;set;}
        public string ArtPack { get;set;}

        public string EquipType { get;set;}
        public string HaloLevel { get;set;}
        public string ColorLevel { get;set;}
        public string Level { get;set;}
        public string Hardiness{get;set;}

        public string MaxHardiness{get;set;}

        public string BindType{get;set;}

        public string HoldType{get;set;}

        public string CantDelete{get;set;}

        public string CantDepot{get;set;}

        public string LogicPack{get;set;}

        public string CantSell{get;set;}

        public string Task{get;set;}

        public string CommonPack{get;set;}
        public string PropPack { get; set; }

        public string SellPrice1{get;set;}

        public string BuyPrice1{get;set;}

        public string BuyPrice2{get;set;}

        public string BuyPrice3{get;set;}

        public string BuyPrice4{get;set;}

        public string TextureType{get;set;}

        public string EquipSet { get;set;}

        public string EquipSetSkillPack { get; set; }
        public string EquipWeaponPack{get;set;}
        public string ResolvePack{get;set;}
        public string CanAskToBuy{get;set;}

        public string OverLayPack { get; set; }
        public string TColorLevel{get;set;}
    }
}
