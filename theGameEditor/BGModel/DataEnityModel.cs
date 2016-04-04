using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGModel
{
    public class DataEnity
    {
        public DataEnity()
        {
            ItemUseModel = new List<ItemUse>();
            ItemWeapon = new List<Weapon>();
            ItemEquipment = new List<Equipment>();
            ItemEnergyShield = new List<EnergyShield>();
        }

        //private List<ItemUse> _ItemUseModel;
        public List<ItemUse> ItemUseModel { get; set; }

        //private List<Weapon> _ItemWeapon;
        public List<Weapon> ItemWeapon { get; set; }

        public List<Equipment> ItemEquipment { get; set; }

        public List<EnergyShield> ItemEnergyShield { get; set; }

        public List<Rune> ItemRune { get; set; }

        public List<Material> ItemMaerial { get; set; }
    }
}
