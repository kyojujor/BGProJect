using BGModel.CommonHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BGModel
{
    public class EnergyShield:bg_ItemBaseModel
    {
        [Description("ID")]
        public override string ID { get; set; }
        [Description("名称ID")]
        public override string Name { get; set; }

        [Description("名字关联说明")]
        public override string Desc { get; set; }
        [Description("描述关联说明")]
        public override string Description { get; set; }
    }
}
