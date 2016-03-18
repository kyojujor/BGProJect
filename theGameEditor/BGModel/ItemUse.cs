using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGModel
{
    public class ItemUse : Bg_ItemBaseModel
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string TextureType { get; set; }

        public string Desc { get; set; }

        public string Description { get; set; }

        public string Photo { get; set; }

        public string BindStatus { get; set; }

        public string AddRidePoint { get; set; }

        public string script { get; set; }

        public string ItemType { get; set; }

        public string ColorLevel { get; set; }

        public string Level { get; set; }

        public string CantDelete { get; set; }

        public string CantDepot { get; set; }

        public string CantSell { get; set; }

        public string Task { get; set; }

        public string Amount { get; set; }

        public int MaxAmount { get; set; }

        public string UseNumber { get; set; }

        public string Disappear { get; set; }

        public string SellPrice1 { get; set; }

        public string BuyPrice1 { get; set; }

        public string LogicPack { get; set; }

        public string CanAskToBuy { get; set; }


    }
}
