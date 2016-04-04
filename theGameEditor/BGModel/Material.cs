using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BGModel.CommonHelper;

namespace BGModel
{
    public class Material :bg_ItemBaseModel
    {
        [Description("ID")]
        public override string ID { get; set; }
        [Description("名称ID")]
        public override string Name { get; set; }
        [Description("名字关联说明")]
        public override string Desc { get; set; }
        [Description("描述关联说明")]
        public override string Description { get; set; }
        public string TextureType{get;set;}
        public string Photo{get;set;}
        public string Only{get;set;}
        public string script{get;set;}
        public string ColorLevel{get;set;}
        public string BindStatus{get;set;}
        public string CantDelete{get;set;}
        public string CantDepot{get;set;}
        public string CantSell{get;set;}
        public string Task{get;set;}
        public string ValidTime{get;set;}
        public string Amount{get;set;}
        public string MaxAmount{get;set;}
        public string SellPrice1{get;set;}
        public string BuyPrice1{get;set;}
        public string LogicPack{get;set;}
        public string CanAskToBuy{get;set;}
        //public string TextureType;
    }
}
