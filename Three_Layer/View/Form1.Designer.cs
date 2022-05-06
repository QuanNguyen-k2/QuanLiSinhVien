namespace Three_Layer.View

{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxLopSh = new System.Windows.Forms.ComboBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.showBt = new System.Windows.Forms.Button();
            this.addBt = new System.Windows.Forms.Button();
            this.updateBt = new System.Windows.Forms.Button();
            this.deleteBt = new System.Windows.Forms.Button();
            this.sortBt = new System.Windows.Forms.Button();
            this.seacrhBt = new System.Windows.Forms.Button();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lop SH";
            // 
            // comboBoxLopSh
            // 
            this.comboBoxLopSh.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.comboBoxLopSh.FormattingEnabled = true;
            this.comboBoxLopSh.Location = new System.Drawing.Point(77, 6);
            this.comboBoxLopSh.Name = "comboBoxLopSh";
            this.comboBoxLopSh.Size = new System.Drawing.Size(172, 24);
            this.comboBoxLopSh.TabIndex = 1;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.textBoxSearch.Location = new System.Drawing.Point(530, 6);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(163, 26);
            this.textBoxSearch.TabIndex = 2;
            // 
            // showBt
            // 
            this.showBt.Location = new System.Drawing.Point(39, 404);
            this.showBt.Name = "showBt";
            this.showBt.Size = new System.Drawing.Size(75, 35);
            this.showBt.TabIndex = 3;
            this.showBt.Text = "Show";
            this.showBt.UseVisualStyleBackColor = true;
            this.showBt.Click += new System.EventHandler(this.showBt_Click);
            // 
            // addBt
            // 
            this.addBt.Location = new System.Drawing.Point(157, 404);
            this.addBt.Name = "addBt";
            this.addBt.Size = new System.Drawing.Size(75, 35);
            this.addBt.TabIndex = 4;
            this.addBt.Text = "Add";
            this.addBt.UseVisualStyleBackColor = true;
            this.addBt.Click += new System.EventHandler(this.addBt_Click);
            // 
            // updateBt
            // 
            this.updateBt.Location = new System.Drawing.Point(279, 404);
            this.updateBt.Name = "updateBt";
            this.updateBt.Size = new System.Drawing.Size(75, 35);
            this.updateBt.TabIndex = 5;
            this.updateBt.Text = "Update";
            this.updateBt.UseVisualStyleBackColor = true;
            this.updateBt.Click += new System.EventHandler(this.updateBt_Click);
            // 
            // deleteBt
            // 
            this.deleteBt.Location = new System.Drawing.Point(407, 404);
            this.deleteBt.Name = "deleteBt";
            this.deleteBt.Size = new System.Drawing.Size(75, 35);
            this.deleteBt.TabIndex = 6;
            this.deleteBt.Text = "Delete";
            this.deleteBt.UseVisualStyleBackColor = true;
            this.deleteBt.Click += new System.EventHandler(this.deleteBt_Click);
            // 
            // sortBt
            // 
            this.sortBt.Location = new System.Drawing.Point(530, 404);
            this.sortBt.Name = "sortBt";
            this.sortBt.Size = new System.Drawing.Size(75, 35);
            this.sortBt.TabIndex = 7;
            this.sortBt.Text = "Sort";
            this.sortBt.UseVisualStyleBackColor = true;
            this.sortBt.Click += new System.EventHandler(this.sortBt_Click);
            // 
            // seacrhBt
            // 
            this.seacrhBt.Location = new System.Drawing.Point(709, 6);
            this.seacrhBt.Name = "seacrhBt";
            this.seacrhBt.Size = new System.Drawing.Size(75, 26);
            this.seacrhBt.TabIndex = 8;
            this.seacrhBt.Text = "Search";
            this.seacrhBt.UseVisualStyleBackColor = true;
            this.seacrhBt.Click += new System.EventHandler(this.seacrhBt_Click_1);
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "MSSV",
            "DTB",
            "NAME"});
            this.comboBoxSort.Location = new System.Drawing.Point(612, 410);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(172, 24);
            this.comboBoxSort.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(769, 322);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 460);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBoxSort);
            this.Controls.Add(this.seacrhBt);
            this.Controls.Add(this.sortBt);
            this.Controls.Add(this.deleteBt);
            this.Controls.Add(this.updateBt);
            this.Controls.Add(this.addBt);
            this.Controls.Add(this.showBt);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.comboBoxLopSh);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Quan Li Sinh Vien";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLopSh;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button showBt;
        private System.Windows.Forms.Button addBt;
        private System.Windows.Forms.Button updateBt;
        private System.Windows.Forms.Button deleteBt;
        private System.Windows.Forms.Button sortBt;
        private System.Windows.Forms.Button seacrhBt;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

