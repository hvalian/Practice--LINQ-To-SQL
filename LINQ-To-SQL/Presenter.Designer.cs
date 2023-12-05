namespace LINQ_To_SQL
{
    partial class Presenter
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
            this.comboBox_Customer = new System.Windows.Forms.ComboBox();
            this.button_View = new System.Windows.Forms.Button();
            this.listView = new System.Windows.Forms.ListView();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_File_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_Option = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_Option_LINQ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_Option_SQL = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox_Customer
            // 
            this.comboBox_Customer.FormattingEnabled = true;
            this.comboBox_Customer.Location = new System.Drawing.Point(8, 38);
            this.comboBox_Customer.Name = "comboBox_Customer";
            this.comboBox_Customer.Size = new System.Drawing.Size(448, 21);
            this.comboBox_Customer.TabIndex = 10;
            // 
            // button_View
            // 
            this.button_View.Location = new System.Drawing.Point(487, 38);
            this.button_View.Name = "button_View";
            this.button_View.Size = new System.Drawing.Size(75, 23);
            this.button_View.TabIndex = 8;
            this.button_View.Text = "View";
            this.button_View.UseVisualStyleBackColor = true;
            this.button_View.Click += new System.EventHandler(this.button_View_Click);
            // 
            // listView
            // 
            this.listView.GridLines = true;
            this.listView.Location = new System.Drawing.Point(12, 67);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(902, 156);
            this.listView.TabIndex = 6;
            this.listView.UseCompatibleStateImageBehavior = false;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_File,
            this.menuItem_Option});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1093, 24);
            this.menuStrip.TabIndex = 12;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuItem_File
            // 
            this.menuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_File_Exit});
            this.menuItem_File.Name = "menuItem_File";
            this.menuItem_File.Size = new System.Drawing.Size(37, 20);
            this.menuItem_File.Text = "File";
            // 
            // menuItem_File_Exit
            // 
            this.menuItem_File_Exit.Name = "menuItem_File_Exit";
            this.menuItem_File_Exit.Size = new System.Drawing.Size(92, 22);
            this.menuItem_File_Exit.Text = "Exit";
            // 
            // menuItem_Option
            // 
            this.menuItem_Option.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Option_LINQ,
            this.menuItem_Option_SQL});
            this.menuItem_Option.Name = "menuItem_Option";
            this.menuItem_Option.Size = new System.Drawing.Size(56, 20);
            this.menuItem_Option.Text = "Option";
            // 
            // menuItem_Option_LINQ
            // 
            this.menuItem_Option_LINQ.Name = "menuItem_Option_LINQ";
            this.menuItem_Option_LINQ.Size = new System.Drawing.Size(123, 22);
            this.menuItem_Option_LINQ.Text = "Use LINQ";
            this.menuItem_Option_LINQ.Click += new System.EventHandler(this.menuItem_Option_LINQ_Click);
            // 
            // menuItem_Option_SQL
            // 
            this.menuItem_Option_SQL.Name = "menuItem_Option_SQL";
            this.menuItem_Option_SQL.Size = new System.Drawing.Size(123, 22);
            this.menuItem_Option_SQL.Text = "use SQL";
            this.menuItem_Option_SQL.Click += new System.EventHandler(this.menuItem_Option_SQL_Click);
            // 
            // Presenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 693);
            this.Controls.Add(this.comboBox_Customer);
            this.Controls.Add(this.button_View);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Presenter";
            this.Text = "Presenter";
            this.Load += new System.EventHandler(this.Presenter_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Customer;
        private System.Windows.Forms.Button button_View;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuItem_File;
        private System.Windows.Forms.ToolStripMenuItem menuItem_File_Exit;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Option;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Option_LINQ;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Option_SQL;
    }
}