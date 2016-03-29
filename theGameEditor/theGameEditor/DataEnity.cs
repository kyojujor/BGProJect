using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BGModel;

namespace theGameEditor
{
    public  class DataEnity
    {
        public DataEnity()
        {
            ItemUseModel = new List<ItemUse>();
            ItemWeapon = new List<Weapon>();
        }
        
        public List<ItemUse> ItemUseModel { get; set; }

        public List<Weapon> ItemWeapon { get; set; }
    }
}
