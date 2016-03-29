using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BGModel.CommonHelper;

namespace BGModel
{
    public class ItemUse 
    {
        [Description("ID")]
        public string ID { get; set; }
        [Description("名称ID")]
        public string Name { get; set; }
        [Description("")]
        public string TextureType { get; set; }
        [Description("名字关联说明")]
        public string Desc { get; set; }
        [Description("描述关联说明")]
        public string Description { get; set; }
        [Description("图片路径")]
        public string Photo { get; set; }
        [Description("")]
        public string BindStatus { get; set; }
        [Description("")]
        public string AddRePoint { get; set; }
        [Description("")]
        public string script { get; set; }
        [Description("")]
        public string ItemType { get; set; }
        [Description("颜色等级")]
        public string ColorLevel { get; set; }
        [Description("等级")]
        public string Level { get; set; }
        [Description("不能被删除")]
        public string CantDelete { get; set; }
        [Description("")]
        public string CantDepot { get; set; }
        [Description("不能被出售")]
        public string CantSell { get; set; }
        [Description("")]
        public string Task { get; set; }
        [Description("")]
        public string Amount { get; set; }
        [Description("最大叠加数量")]
        public int MaxAmount { get; set; }
        [Description("")]
        public string UseNumber { get; set; }
        [Description("")]
        public string Disappear { get; set; }
        [Description("卖出价格")]
        public string SellPrice1 { get; set; }
        [Description("买入价格")]
        public string BuyPrice1 { get; set; }
        [Description("")]
        public string LogicPack { get; set; }
        [Description("技能限制id")]
        public string SkillPack { get; set; }
        [Description("")]
        public string CanAskToBuy { get; set; }

        [Description("静态财富ID")]
        public string WealthPack { get; set; }
    }
}
