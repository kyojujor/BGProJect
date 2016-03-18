using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGModel
{
    /// <summary>
    /// 一切物品model的基类
    /// 第一批只包含装备 材料 武器 能量盾
    /// </summary>
    public interface Bg_ItemBaseModel
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
