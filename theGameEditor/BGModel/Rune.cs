using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BGModel.CommonHelper;

namespace BGModel
{
    public  class Rune :bg_ItemBaseModel
    {
        [Description("ID")]
        public override string ID { get; set; }
        [Description("名称ID")]
        public override string Name { get; set; }

        [Description("名字关联说明")]
        public override string Desc { get; set; }
        [Description("描述关联说明")]
        public override string Description { get; set; }

        public string CantCompound{get;set;}
        public string Only{get;set;}
        public string Photo{get;set;}
        public string script{get;set;}
        public string ItemType{get;set;}
        public string ColorLevel{get;set;}
        public string Level{get;set;}
        public string BindStatus{get;set;}
        public string CantDelete{get;set;}
        public string CantDepot{get;set;}
        public string CantSell{get;set;}
        public string Task{get;set;}
        public string JewelLevel{get;set;}
        public string ValidTime{get;set;}
        public string MaxAmount{get;set;}
        public string RandSerial{get;set;}
        public string SellPrice0{get;set;}
        public string SellPrice1{get;set;}
        public string TextureType{get;set;}
        public string LogicPack{get;set;}
        public string CanAskToBuy{get;set;}

    }
}
