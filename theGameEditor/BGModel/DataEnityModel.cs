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

        public List<ItemUse> ItemUseModel { get; set; }

        public List<Weapon> ItemWeapon { get; set; }

        public List<Equipment> ItemEquipment { get; set; }

        public List<EnergyShield> ItemEnergyShield { get; set; }
    }
}
