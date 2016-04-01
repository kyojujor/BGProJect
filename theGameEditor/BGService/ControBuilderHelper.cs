using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompositeControllerDemo;
using System.ComponentModel;

namespace BGService
{
    /// <summary>
    /// 组件操作类
    /// </summary>
    public static class ControBuilderHelper
    {
        /// <summary>
        /// Listbox需要重新绑数据源的方法
        /// </summary>
        /// <param name="con">listbox控件</param>
        /// <param name="obj">所绑定的数据源,必须实现迭代接口</param>
        /// <param name="desc">需要展示的项的名字</param>
        public static void ListBoxBlindData<T>(this ListBox con, List<T> obj, string desc, List<LabelTextBox> listBox)
        {
            if (obj == null || string.IsNullOrWhiteSpace(desc) || obj == null)
            {
                return;
            }
            con.DataSource = null;
            con.DataSource = obj;
            con.DisplayMember = desc;
            if (obj.Count > 0)
            {
                con.SelectedIndex = 0;
                BgService.ItemBlindToLabelTextBox(listBox, con.SelectedItem);
            }

            //con.SelectedItem
        }

        public static void GirdViewBlindData<T>(this DataGridView con, List<T> obj,bool hideLastColumn=false) where T : new()
        {
            if (con != null && obj != null && obj.Count > 0)
            {
                con.DataSource = new BindingList<T>();
                con.DataSource = new BindingList<T>(obj);
                var dropCount = con.ColumnCount;
                if (dropCount > 0 && hideLastColumn)
                    con.Columns[dropCount - 1].Visible = false;
                con.AutoSizeColumn();
            }
        }

        /// <summary>
        /// 使DataGridView的列自适应宽度
        /// </summary>
        /// <param name="dgViewFiles"></param>
        public static void AutoSizeColumn(this DataGridView dgViewFiles)
        {
            int width = 0;
            //使列自使用宽度
            //对于DataGridView的每一个列都调整
            for (int i = 0; i < dgViewFiles.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                dgViewFiles.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                //记录整个DataGridView的宽度
                width += dgViewFiles.Columns[i].Width;
            }
            //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
            //则将DataGridView的列自动调整模式设置为显示的列即可，
            //如果是小于原来设定的宽度，将模式改为填充。
            if (width > dgViewFiles.Size.Width)
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            //冻结某列 从左开始 0，1，2
            //dgViewFiles.Columns[1].Frozen = true;
        }
    }
}
