namespace DynamicList
{
    partial class DynamicList
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
            listView = new System.Windows.Forms.ListView();
            SuspendLayout();
            // 
            // listView
            // 
            listView.Dock = System.Windows.Forms.DockStyle.Fill;
            listView.FullRowSelect = true;
            listView.Location = new System.Drawing.Point(0, 0);
            listView.Name = "listView";
            listView.Size = new System.Drawing.Size(1014, 677);
            listView.TabIndex = 0;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = System.Windows.Forms.View.Details;
            // 
            // DynamicList
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1014, 677);
            Controls.Add(listView);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "DynamicList";
            Text = "Dynamic List";
            ResumeLayout(false);
        }
        #endregion

        public System.Windows.Forms.ListView listView;
    }
}

