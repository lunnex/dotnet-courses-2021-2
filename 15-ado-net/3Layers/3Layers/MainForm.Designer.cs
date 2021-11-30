
namespace WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.addUserBtn = new System.Windows.Forms.Button();
            this.usersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prizesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editUserBtn = new System.Windows.Forms.Button();
            this.deleteUserBtn = new System.Windows.Forms.Button();
            this.addPrizeBtn = new System.Windows.Forms.Button();
            this.editPrizeBtn = new System.Windows.Forms.Button();
            this.deletePrizeBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 27);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(1043, 452);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.sortGridView);
            // 
            // addUserBtn
            // 
            this.addUserBtn.Location = new System.Drawing.Point(325, 485);
            this.addUserBtn.Name = "addUserBtn";
            this.addUserBtn.Size = new System.Drawing.Size(117, 103);
            this.addUserBtn.TabIndex = 1;
            this.addUserBtn.Text = "Add User";
            this.addUserBtn.UseVisualStyleBackColor = true;
            this.addUserBtn.Click += new System.EventHandler(this.addUserBtn_Click);
            // 
            // usersToolStripMenuItem
            // 
            this.usersToolStripMenuItem.Name = "usersToolStripMenuItem";
            this.usersToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.usersToolStripMenuItem.Text = "Users";
            this.usersToolStripMenuItem.Click += new System.EventHandler(this.usersToolStripMenuItem_Click);
            // 
            // prizesToolStripMenuItem
            // 
            this.prizesToolStripMenuItem.Name = "prizesToolStripMenuItem";
            this.prizesToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.prizesToolStripMenuItem.Text = "Prizes";
            this.prizesToolStripMenuItem.Click += new System.EventHandler(this.prizesToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usersToolStripMenuItem,
            this.prizesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1067, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editUserBtn
            // 
            this.editUserBtn.Location = new System.Drawing.Point(448, 485);
            this.editUserBtn.Name = "editUserBtn";
            this.editUserBtn.Size = new System.Drawing.Size(117, 103);
            this.editUserBtn.TabIndex = 3;
            this.editUserBtn.Text = "Edit User";
            this.editUserBtn.UseVisualStyleBackColor = true;
            this.editUserBtn.Click += new System.EventHandler(this.editUserBtn_Click);
            // 
            // deleteUserBtn
            // 
            this.deleteUserBtn.Location = new System.Drawing.Point(571, 485);
            this.deleteUserBtn.Name = "deleteUserBtn";
            this.deleteUserBtn.Size = new System.Drawing.Size(117, 103);
            this.deleteUserBtn.TabIndex = 4;
            this.deleteUserBtn.Text = "Delete User";
            this.deleteUserBtn.UseVisualStyleBackColor = true;
            this.deleteUserBtn.Click += new System.EventHandler(this.deleteUserBtn_Click);
            // 
            // addPrizeBtn
            // 
            this.addPrizeBtn.Location = new System.Drawing.Point(325, 485);
            this.addPrizeBtn.Name = "addPrizeBtn";
            this.addPrizeBtn.Size = new System.Drawing.Size(117, 103);
            this.addPrizeBtn.TabIndex = 5;
            this.addPrizeBtn.Text = "Add Prize";
            this.addPrizeBtn.UseVisualStyleBackColor = true;
            this.addPrizeBtn.Click += new System.EventHandler(this.addPrizeBtn_Click);
            // 
            // editPrizeBtn
            // 
            this.editPrizeBtn.Location = new System.Drawing.Point(448, 485);
            this.editPrizeBtn.Name = "editPrizeBtn";
            this.editPrizeBtn.Size = new System.Drawing.Size(117, 103);
            this.editPrizeBtn.TabIndex = 6;
            this.editPrizeBtn.Text = "Edit Prize";
            this.editPrizeBtn.UseVisualStyleBackColor = true;
            this.editPrizeBtn.Click += new System.EventHandler(this.editPrizeBtn_Click);
            // 
            // deletePrizeBtn
            // 
            this.deletePrizeBtn.Location = new System.Drawing.Point(571, 485);
            this.deletePrizeBtn.Name = "deletePrizeBtn";
            this.deletePrizeBtn.Size = new System.Drawing.Size(117, 103);
            this.deletePrizeBtn.TabIndex = 7;
            this.deletePrizeBtn.Text = "Delete Prize";
            this.deletePrizeBtn.UseVisualStyleBackColor = true;
            this.deletePrizeBtn.Click += new System.EventHandler(this.deletePrizeBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 600);
            this.Controls.Add(this.deletePrizeBtn);
            this.Controls.Add(this.editPrizeBtn);
            this.Controls.Add(this.addPrizeBtn);
            this.Controls.Add(this.deleteUserBtn);
            this.Controls.Add(this.editUserBtn);
            this.Controls.Add(this.addUserBtn);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button addUserBtn;
        private System.Windows.Forms.ToolStripMenuItem usersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prizesToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button editUserBtn;
        private System.Windows.Forms.Button deleteUserBtn;
        private System.Windows.Forms.Button addPrizeBtn;
        private System.Windows.Forms.Button editPrizeBtn;
        private System.Windows.Forms.Button deletePrizeBtn;
    }
}

