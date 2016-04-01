using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BGService;
using BGModel;
using System.Threading;
using CompositeControllerDemo;

namespace theGameEditor
{
    public partial class FormMain : Form
    {
        static readonly string pathDrop = @"F:\study\GitHub\BG_ini\ini\Drop\";
        static readonly string pathDropWorld = pathDrop+ @"World_Drop_Complex.xml";
        static readonly string pathDropTeam = pathDrop + @"Drop_Team.xml";
        static readonly string pathDropItem = pathDrop + @"Drop_Item.xml";

        public List<World_Drop_Complex> WorldDrop { get; set; }

        public List<Drop_Team> TeamDrop { get; set; }

        public List<Drop_Item> ItemDrop { get; set; }

        public List<FstTeamItem> world_TeamRelaList { get; set; }

        /// <summary>
        /// 双击事件
        /// 世界掉落
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DGVDrop_World_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = (DataGridView)sender;
            var a =  dgv.CurrentRow.Cells;
            var index = e.RowIndex;
            var item = WorldDrop[index];

            world_TeamRelaList = item.FstTeamItemList;
            this.DGVDrop_Team.GirdViewBlindData(world_TeamRelaList);
        }

        private void DGVDrop_Team_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var index = e.RowIndex;
        }
    }
}
