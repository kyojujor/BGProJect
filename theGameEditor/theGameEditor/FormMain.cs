﻿using System;
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
        static readonly string path = @"C:\学习\gitHub-kyo\BG_ini\ini\";
        static readonly string pathItem = path + @"Item\";
        //static readonly string pathDrop = @"F:\study\GitHub\BG_ini\ini\Drop\";
        static readonly string pathTest1 = pathItem + @"ItemUse.xml";
        static readonly string pathTest2 = pathItem + @"Weapon.xml";
        static readonly string pathTest3 = pathItem + @"Equipment.xml";
        static readonly string pathTest4 = pathItem + @"EnergyShield.xml";
        static readonly string pathTest5 = pathItem + @"Rune.xml";
        static readonly string pathTest6 = pathItem + @"Material.xml";
        static readonly string pathTest7 = pathItem + @"ItemMountUse.xml";

        static readonly string pathDrop = path + @"Drop\";
        static readonly string pathDropWorld = pathDrop + @"World_Drop_Complex.xml";
        static readonly string pathDropTeam = pathDrop + @"Drop_Team.xml";
        static readonly string pathDropItem = pathDrop + @"Drop_Item.xml";

        private static DataEnity _DataEnity;
        public static DataEnity DataEnity { get { return _DataEnity; } set { _DataEnity = value; } }
        /// <summary>
        /// 存放所有物品实体
        /// </summary>
        public static List<bg_ItemBaseModel> DataModelList { get; set; }

        public List<LabelTextBox> ItemFormLabelList { get; set; }

        public FormMain()
        {
            InitializeComponent();
            #region 初始化控件集合
            ItemFormLabelList = new List<LabelTextBox>();
            DataModelList = new List<bg_ItemBaseModel>();
            //FindAllLabelAndTextBox(this.tabCommonItem);

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

            Task.Run(() => { InitateItemModel<ItemUse>(pathTest1, ref _DataEnity); });
            Task.Run(() => { InitateItemModel<Weapon>(pathTest2, ref _DataEnity); });
            Task.Run(() => { InitateItemModel<Equipment>(pathTest3, ref _DataEnity); });
            Task.Run(() => { InitateItemModel<EnergyShield>(pathTest4, ref _DataEnity); });
            Task.Run(() => { InitateItemModel<Rune>(pathTest5, ref _DataEnity); });
            Task.Run(() => { InitateItemModel<Material>(pathTest6, ref _DataEnity); });
            Task.Run(() => { InitateItemModel<ItemMountUse>(pathTest7, ref _DataEnity); });
            //InitateItemModel<ItemUse>(pathTest1, ref _DataEnity);
            //InitateItemModel<Weapon>(pathTest2, ref _DataEnity);
            //InitateItemModel<Equipment>(pathTest3, ref _DataEnity);
            //InitateItemModel<EnergyShield>(pathTest4, ref _DataEnity);


            //DataEnity.ItemWeapon = XmlHelper.GetModelObjectListByPath<Weapon>(pathTest2);
            //DataEnity.ItemEquipment = XmlHelper.GetModelObjectListByPath<Equipment>(pathTest3);
            //DataEnity.ItemEnergyShield = XmlHelper.GetModelObjectListByPath<EnergyShield>(pathTest4);

            #region 掉落相关

            WorldShowData = new List<Drop_TeamByWorld>();
            TeamShowData = new List<Drop_ItemByTeam>();
            ItemShowData = new List<Drop_ItemByModel>();

            //BgService.WorldDropDea(WorldDrop, TeamDrop, pathDropWorld);
            dropSearchList = new List<World_Drop_Complex>();

            //Task.Run(() => { WorldDrop = XmlHelper.GetModelObjectListByPath<World_Drop_Complex>(pathDropWorld); });
            //Task.Run(() => { WorldDrop = XmlHelper.GetModelObjectListByPath<World_Drop_Complex>(pathDropWorld); });

            WorldDrop = XmlHelper.GetModelObjectListByPath<World_Drop_Complex>(pathDropWorld);
            TeamDrop = XmlHelper.GetModelObjectListByPath<Drop_Team>(pathDropTeam);
            ItemDrop = XmlHelper.GetModelObjectListByPath<Drop_Item>(pathDropItem);

            //world_TeamRelaList = new List<FstTeamItem>();
            //this.TabMainContorler.SelectedTab = this.TabDrop;//debug 
            DGVDrop_World.GirdViewBlindData(WorldDrop, true);

            //DGV_Team.GirdViewBlindData(TeamDrop, true);

            #endregion


            //ItemListBox.DataSource = DataEnity.ItemUseModel;
            //ItemListBox.DisplayMember = "Desc";

            Task.Run(() =>
            {
                FindAllLabelAndTextBox(this.tabCommonItem);
                ItemListBox.ListBoxBlindData(DataModelList, "Desc", ItemFormLabelList);
            });



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
            if (tabControl == null || tabControl.Controls == null || tabControl.Controls.Count == 0)
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

            var list = BgService.ItemSearch(keyword, DataModelList);
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
            //if (tx.ToLower().Contains("drug"))
            //{
            //    ResultItem += string.Format("{0},{1},1;", tx, 10);
            //}
            //else
            {
                ResultItem += string.Format("{0},{1};", tx, itemCount);
            }
            count += 1;
            var temp = string.Format("<Property ID='{2}' ItemTeamID='' TeamName='' ItemID='{0}' Count='{1}'/>", ResultItem, count,tb_idt.Text);
            this.RTB_Item1.Text = temp.Replace('\'', '"');
            TB_ITEM_count.Text = "1";
            //tb_idt.Text = (int.Parse(tb_idt.Text) + 1).ToString();
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

            tb_idt.Text = (int.Parse(tb_idt.Text) + 1).ToString();
        }

        /// <summary>
        /// listboxItem重新绑定数据源后发生的事件
        /// </summary>
        [Obsolete("暂时废弃")]
        private void ListBoxItemReBlindData(object sender, EventArgs e)
        {
            var listboxItem = (ListBox)sender;
            if (listboxItem.DataSource != null)
            {
                listboxItem.SelectedIndex = 0;
                BgService.ItemBlindToLabelTextBox(ItemFormLabelList, listboxItem.SelectedItem);
            }
        }

        private void button_ItemAddGold_Click(object sender, EventArgs e)
        {
            var itemCount = "50000";

            var id = int.Parse(tb_idt.Text);
            var tx = "add_money_item0";
            ResultItem += string.Format("{0},{1},1;", tx, itemCount);
            count += 1;
            var temp = string.Format("<Property ID='{2}' ResultItem='{0}' Count='{1}'/>", ResultItem, count,id);
            this.RTB_Item1.Text = temp.Replace('\'', '"');
            TB_ITEM_count.Text = "1";
        }

        #region 初始的异步

        public void InitateItemModel<T>(string path, ref DataEnity data) where T : new()
        {
            if (data == null)
            {
                return;
            }

            var dataItem = XmlHelper.GetModelObjectListByPath<T>(path);
            var propDataList = data.GetType().GetProperties();
            foreach (var propItem in propDataList)
            {
                if (propItem.PropertyType == typeof(List<T>))
                {
                    propItem.SetValue(data, dataItem);
                    break;
                }
            }

            var tem = new T() as bg_ItemBaseModel;
            if (tem != null)
            {
                var baseItem = dataItem.Select(x => x as bg_ItemBaseModel).ToList();
                lock (DataModelList)
                {
                    DataModelList.AddRange(baseItem);
                }
            }
        }

        #endregion

        private void SelectTabIndex(int index)
        {
            var diction = new Dictionary<int,TabPage>();
            diction.Add(0, tabCommonItem);
            diction.Add(1, TabDrop);
           if(diction.ContainsKey(index))
            this.TabMainContorler.SelectedTab = diction[index];
        }
    }
}
