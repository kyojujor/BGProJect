using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region 所关联的一些文件
/*
F:\study\GitHub\BG_ini\ini\Item\ItemUse.xml
F:\study\GitHub\BG_ini\ini\Item\Equipment.xml
F:\study\GitHub\BG_ini\ini\Item\Weapon.xml
F:\study\GitHub\BG_ini\ini\Item\EnergyShield.xml
F:\study\GitHub\BG_ini\ini\Item\Material.xml
ini\Item\ItemPetUse.xml
*/
#endregion

namespace BGModel
{
    /// <summary>
    /// 一切物品model的基类
    /// 第一批只包含装备 材料 武器 能量盾 宝箱 宠物
    /// </summary>
    public interface Ibg_ItemBaseModel
    {
         string ID { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
         string Desc { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
         string Name { get; set; }

        string Description { get; set; }

    }

    //public interface 
}
