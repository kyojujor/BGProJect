using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        private BackgroundWorker backgroundWorkerFormMain;
        //static readonly string pathTest =@"C:\game\blackGold\resServer\ini\Item\ItemUse.xml";
        //F:\study\GitHub\BG_ini\ini\Item\Equipment.xml
        static readonly string path = @"F:\study\GitHub\BG_ini\ini\Item\";
        //static readonly string pathDrop = @"F:\study\GitHub\BG_ini\ini\Drop\";
        static readonly string pathTest1 = path +@"ItemUse.xml";
        static readonly string pathTest2 = path + @"Weapon.xml";
        static readonly string pathTest3 = path + @"Equipment.xml";
        static readonly string pathTest4 = path + @"EnergyShield.xml";
        public DataEnity DataEnity { get; set; }

        public List<LabelTextBox> ItemFormLabelList { get; set; }

        public FormMain()
        {
            InitializeComponent();
            #region 初始化控件集合
            ItemFormLabelList = new List<LabelTextBox>();

            FindAllLabelAndTextBox(this.tabCommonItem);

            #endregion

            #region 
            #endregion  

            DataEnity = new DataEnity();
            #region test 动态组件
            //todo 动态组件测试
            //var dytext = new TextBox();
            //dytext.Location = new System.Drawing.Point(244, 141);
            //dytext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            //dytext.Name = "textBox1";
            //dytext.Size = new System.Drawing.Size(125, 23);
            //dytext.TabIndex = 1;
            //dytext.Text = "2323";
            //tabCommonItem.Controls.Add(dytext);

            //this.labelTextBox1.LabelText.Text = "客户端名字关联";
            //this.labelTextBox1.LabelRelate.Text = "客户端名字关联";
            //this.labelTextBox1.LabelText.Click += TestSelfConClick;
            #endregion



            DataEnity.ItemUseModel = XmlHelper.GetModelObjectListByPath<ItemUse>(pathTest1);
            DataEnity.ItemWeapon = XmlHelper.GetModelObjectListByPath<Weapon>(pathTest2);
            DataEnity.ItemEquipment = XmlHelper.GetModelObjectListByPath<Equipment>(pathTest3);
            DataEnity.ItemEnergyShield = XmlHelper.GetModelObjectListByPath<EnergyShield>(pathTest4);

            //Task.Run<>()
            WorldDrop = XmlHelper.GetModelObjectListByPath<World_Drop_Complex>(pathDropWorld);
            TeamDrop = XmlHelper.GetModelObjectListByPath<Drop_Team>(pathDropTeam);
            ItemDrop = XmlHelper.GetModelObjectListByPath<Drop_Item>(pathDropItem);

            #region 掉落相关
            this.DGVDrop_World.DataSource = new BindingList<World_Drop_Complex>(WorldDrop);
            //this.DGVDrop_World.Columns[0].Name = "姓名";

            //this.DGVDrop_World.disp
            #endregion


            //ItemListBox.DataSource = DataEnity.ItemUseModel;
            //ItemListBox.DisplayMember = "Desc";
            ItemListBox.ListBoxBlindData(DataEnity.ItemWeapon, "Desc", ItemFormLabelList);

            backgroundWorkerFormMain = new BackgroundWorker();
            //backgroundWorkerFormMain.DoWork += TestDoWorkEvent;
            //backgroundWorkerFormMain.RunWorkerCompleted += new RunWorkerCompletedEventHandler(TestEvent);
            //backgroundWorkerFormMain.RunWorkerAsync("2323");

        }

        public void ItemLabelBoxListInitation<T>(List<T> para) where T : ItemUse
        {
            if (para == null)
                throw new NullReferenceException("para为空");

            //ItemListBox.DataSource = DataEnity.ItemUseModel;
            //ItemListBox.DisplayMember = "Desc";


            //Thread.Sleep(1000);
            DataEnity.ItemUseModel.Insert(0, new ItemUse { Desc = "222".ToString() });

            ItemListBox.DataSource = null;
            ItemListBox.DataSource = DataEnity.ItemUseModel;
            ItemListBox.DisplayMember = "Desc";


            //foreach (var item in para)
            //{
            //    var Desc = item.Desc.GetLenthRe(20, " ");
            //    //ItemListBox.Items.Add(item.Desc.GetLenthRe(14," ")+"|"+item.ID.GetLenth(6));
            //    ItemListBox.Items.Add(item.Desc + "|" + item.ID);
            //}
        }

        private void TestDoWorkEvent(object sender, DoWorkEventArgs e)
        {
            DataEnity.ItemUseModel.Insert(0, new ItemUse { Desc = "222".ToString() });
            e.Result = "1111";
        }

        private void TestEvent(object sender, RunWorkerCompletedEventArgs e)
        {
            DataEnity.ItemUseModel.Insert(0, new ItemUse { Desc = "222".ToString() });
            //ItemListBox.DataSource = null;
            //ItemListBox.DataSource = DataEnity.ItemUseModel;
            //ItemListBox.DisplayMember = "Desc";
        }

        private void ItemListBox_MouseClick(object sender, MouseEventArgs e)
        {
            int index = ItemListBox.IndexFromPoint(e.X, e.Y);
            ItemListBox.SelectedIndex = index;
            if (ItemListBox.SelectedIndex != -1)
            {
                //MessageBox.Show(ItemListBox.SelectedItem.ToString());
                BgService.ItemBlindToLabelTextBox(ItemFormLabelList, ItemListBox.SelectedItem);
            }
        }

        /// <summary>
        /// 找到所有的labelTextBox
        /// </summary>
        /// <param name="tabControl"></param>
        public void FindAllLabelAndTextBox(TabPage tabControl)
        {
            if (tabControl==null || tabControl.Controls==null || tabControl.Controls.Count==0)
            {
                return;
            }

            foreach (var item in tabControl.Controls)
            {
                //this.Controls.cont
                if (item is LabelTextBox)
                {
                    var t = (LabelTextBox)item;
                    t.textBoxContent.DoubleClick += TLB_Click;

                    //ItemFormLabelList.Add((LabelTextBox)item);
                    ItemFormLabelList.Add(t);
                }
            }
            ItemFormLabelList = ItemFormLabelList.OrderBy(x => x.TabIndex).ToList();
        }

        private void btn_Item_Search_Click(object sender, EventArgs e)
        {
            var keyword = this.TB_Item_Search.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword))
                return;

            var list = BgService.ItemSearch(keyword, DataEnity);
            if (list != null && list.Count > 0)
            {
                ItemListBox.ListBoxBlindData(list, "Desc", ItemFormLabelList);
            }
            else {
                ItemListBox.DataSource = null;
            }

        }

        /// <summary>
        /// 双击名称添加进富文本编辑框内
        /// <Property ID='1623' ResultItem='JY_0006,1,1; S_Drug_003C,10,1' Count='2'/>
        /// </summary>
        private void TLB_Click(object sender, EventArgs e)
        {
            var itemCount = Convert.ToInt32(TB_ITEM_count.Text);
            var tlb = (TextBox)sender;
            var tx = tlb.Text;
            if (tx.ToLower().Contains("drug"))
            {
                ResultItem += string.Format("{0},{1},1;", tx, 10);
            }
            else
            {
                ResultItem += string.Format("{0},{1},1;", tx, itemCount);
            }
            count += 1;
           var temp=string.Format( "<Property ID='1623' ResultItem='{0}' Count='{1}'/>",ResultItem,count);
            this.RTB_Item1.Text = temp.Replace('\'','"');
            TB_ITEM_count.Text = "1";

        }

        public string ResultItem;
        public int count;

        /// <summary>
        /// 清空按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_richClear_Click(object sender, EventArgs e)
        {
            ResultItem = "";
            count = 0;
            this.RTB_Item1.Text = "";
        }

        /// <summary>
        /// listboxItem重新绑定数据源后发生的事件
        /// </summary>
        [Obsolete("暂时废弃")]
        private void ListBoxItemReBlindData(object sender,EventArgs e)
        {
            var listboxItem = (ListBox)sender;
            if (listboxItem.DataSource!=null )
            {
                listboxItem.SelectedIndex = 0;
                BgService.ItemBlindToLabelTextBox(ItemFormLabelList, listboxItem.SelectedItem);
            }
        }

        private void button_ItemAddGold_Click(object sender, EventArgs e)
        {
            var itemCount = "50000";
            var tx = "add_money_item0";
            ResultItem += string.Format("{0},{1},1;", tx, itemCount);
            count += 1;
            var temp = string.Format("<Property ID='1623' ResultItem='{0}' Count='{1}'/>", ResultItem, count);
            this.RTB_Item1.Text = temp.Replace('\'', '"');
            TB_ITEM_count.Text = "1";
        }
    }
}
