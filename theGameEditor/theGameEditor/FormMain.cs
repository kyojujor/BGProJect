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

namespace theGameEditor
{
    public partial class FormMain : Form
    {
        private BackgroundWorker backgroundWorkerFormMain;
        //static readonly string pathTest =@"C:\game\blackGold\resServer\ini\Item\ItemUse.xml";
        static readonly string pathTest = @"F:\服务端合集\resServer\ini\Item\ItemUse.xml";
        public DataEnity DataEnity { get; set; }

        public List<Label> ItemFormLabelList { get; set; }

        public List<TextBox> ItemFormTextBoxList { get; set; }

        public FormMain()
        {
            InitializeComponent();
            #region 初始化控件集合
            ItemFormLabelList = new List<Label>();
            ItemFormTextBoxList = new List<TextBox>();

            FindAllLabelAndTextBox(this.TabMainContorler);

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

            #region


            #endregion

            DataEnity.ItemUseModel = XmlHelper.GetModelObjectListByPath<ItemUse>(pathTest);
         
            //ItemListBox.DataSource = DataEnity.ItemUseModel;
            //ItemListBox.DisplayMember = "Desc";
            ItemListBox.ListBoxBlindData(DataEnity.ItemUseModel, "Desc");

            backgroundWorkerFormMain = new BackgroundWorker();
            backgroundWorkerFormMain.DoWork += TestDoWorkEvent;
            backgroundWorkerFormMain.RunWorkerCompleted += new RunWorkerCompletedEventHandler(TestEvent);
            backgroundWorkerFormMain.RunWorkerAsync("2323");

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

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    ItemLabelBoxListInitation(DataEnity.ItemUseModel);
        //}

        private void ItemListBox_MouseClick(object sender, MouseEventArgs e)
        {
            int index = ItemListBox.IndexFromPoint(e.X, e.Y);
            ItemListBox.SelectedIndex = index;
            if (ItemListBox.SelectedIndex != -1)
            {
                MessageBox.Show(ItemListBox.SelectedItem.ToString());
            }
        }

        public void FindAllLabelAndTextBox(TabControl tabControl)
        {
            if (tabControl==null || tabControl.Controls==null || tabControl.Controls.Count==0)
            {
                return;
            }

            foreach (var item in tabControl.Controls)
            {
                //this.Controls.cont
                if (item is Label)
                {
                    ItemFormLabelList.Add((Label)item);
                }
                if (item is TextBox)
                {
                    ItemFormTextBoxList.Add((TextBox)item);
                }
            }
        }

        public void TestSelfConClick(object sender,EventArgs e)
        {
            MessageBox.Show("asdasdasd11");
        }
    }
}
