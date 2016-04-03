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

        private List<ItemUse> _ItemUseModel;
        public List<ItemUse> ItemUseModel { get { return _ItemUseModel; } set { _ItemUseModel = value; } }

        private List<Weapon> _ItemWeapon;
        public List<Weapon> ItemWeapon { get { return _ItemWeapon; } set { _ItemWeapon = value; } }
          
        public List<Equipment> ItemEquipment { get; set; }

        public List<EnergyShield> ItemEnergyShield { get; set; }
    }
}
