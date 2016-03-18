namespace theGameEditor
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.TabMainContorler = new System.Windows.Forms.TabControl();
            this.tabCommonItem = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ItemListBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TabMainContorler.SuspendLayout();
            this.tabCommonItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabMainContorler
            // 
            this.TabMainContorler.Controls.Add(this.tabCommonItem);
            this.TabMainContorler.Controls.Add(this.tabPage2);
            this.TabMainContorler.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TabMainContorler.Location = new System.Drawing.Point(1, 2);
            this.TabMainContorler.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TabMainContorler.Name = "TabMainContorler";
            this.TabMainContorler.SelectedIndex = 0;
            this.TabMainContorler.Size = new System.Drawing.Size(1053, 591);
            this.TabMainContorler.TabIndex = 0;
            // 
            // tabCommonItem
            // 
            this.tabCommonItem.Controls.Add(this.textBox1);
            this.tabCommonItem.Controls.Add(this.ItemListBox);
            this.tabCommonItem.Location = new System.Drawing.Point(4, 26);
            this.tabCommonItem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCommonItem.Name = "tabCommonItem";
            this.tabCommonItem.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabCommonItem.Size = new System.Drawing.Size(1045, 561);
            this.tabCommonItem.TabIndex = 0;
            this.tabCommonItem.Text = "物品栏";
            this.tabCommonItem.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(244, 41);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 23);
            this.textBox1.TabIndex = 1;
            // 
            // ItemListBox
            // 
            this.ItemListBox.FormattingEnabled = true;
            this.ItemListBox.ItemHeight = 17;
            this.ItemListBox.Location = new System.Drawing.Point(11, 41);
            this.ItemListBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ItemListBox.Name = "ItemListBox";
            this.ItemListBox.Size = new System.Drawing.Size(195, 514);
            this.ItemListBox.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPage2.Size = new System.Drawing.Size(1045, 561);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 597);
            this.Controls.Add(this.TabMainContorler);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.TabMainContorler.ResumeLayout(false);
            this.tabCommonItem.ResumeLayout(false);
            this.tabCommonItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabMainContorler;
        private System.Windows.Forms.TabPage tabCommonItem;
        private System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.ListBox ItemListBox;
        private System.Windows.Forms.TextBox textBox1;
    }
}

