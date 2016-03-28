using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CompositeControllerDemo
{
    public partial class LabelTextBox: UserControl
    {
        /// <summary>
        /// string labelTextId,string textBoxId,string labelRelateId
        /// </summary>
        public LabelTextBox()
        {
            InitializeComponent();
            //if(LabelText.labelt)
        }

        public Label LabelText
        {
            get { return label_Text; }
            set { label_Text = value; }
        }

        public delegate void LabelTextdelegate(object sender, EventArgs e);

        public Label LabelRelate
        {
            get { return label_Relate; }
            set { label_Relate = value; }
        }

        public TextBox textBoxContent
        {
            get { return textBox_Content; }
            set { textBox_Content = value; }
        }

        private void label_Relate_Click(object sender, EventArgs e)
        {

        }
    }
}
