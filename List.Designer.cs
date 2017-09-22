namespace DynamicList
{
    partial class List
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mListView = new System.Windows.Forms.ListView();
            this.checkBox = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // mListView
            // 
            this.mListView.AutoArrange = false;
            this.mListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mListView.CheckBoxes = true;
            this.mListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.checkBox});
            this.mListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mListView.FullRowSelect = true;
            this.mListView.Location = new System.Drawing.Point(0, 0);
            this.mListView.Name = "mListView";
            this.mListView.OwnerDraw = true;
            this.mListView.Size = new System.Drawing.Size(800, 600);
            this.mListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.mListView.TabIndex = 0;
            this.mListView.UseCompatibleStateImageBehavior = false;
            this.mListView.View = System.Windows.Forms.View.Details;
            this.mListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.mListView_ColumnClick);
            this.mListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.mListView_DrawColumnHeader);
            this.mListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.mListView_DrawItem);
            this.mListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.mListView_DrawSubItem);
            this.mListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.mListView_ItemChecked);
            // 
            // checkBox
            // 
            this.checkBox.Text = "";
            this.checkBox.Width = 20;
            // 
            // List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.mListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "List";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Dynamic List";
            this.ResumeLayout(false);

        }
        #endregion

        public System.Windows.Forms.ListView mListView;
        private System.Windows.Forms.ColumnHeader checkBox;
    }
}

