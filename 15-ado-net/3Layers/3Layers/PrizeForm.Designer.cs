
namespace WinForms
{
    partial class PrizeForm
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
            this.textBoxNameOfPrize = new System.Windows.Forms.TextBox();
            this.textBoxOfDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.doneBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNameOfPrize
            // 
            this.textBoxNameOfPrize.Location = new System.Drawing.Point(88, 12);
            this.textBoxNameOfPrize.Name = "textBoxNameOfPrize";
            this.textBoxNameOfPrize.Size = new System.Drawing.Size(184, 23);
            this.textBoxNameOfPrize.TabIndex = 0;
            this.textBoxNameOfPrize.TextChanged += new System.EventHandler(this.textBoxNameOfPrize_TextChanged);
            // 
            // textBoxOfDescription
            // 
            this.textBoxOfDescription.Location = new System.Drawing.Point(88, 41);
            this.textBoxOfDescription.Multiline = true;
            this.textBoxOfDescription.Name = "textBoxOfDescription";
            this.textBoxOfDescription.Size = new System.Drawing.Size(184, 122);
            this.textBoxOfDescription.TabIndex = 1;
            this.textBoxOfDescription.TextChanged += new System.EventHandler(this.textBoxOfDescription_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description:";
            // 
            // doneBtn
            // 
            this.doneBtn.Location = new System.Drawing.Point(12, 169);
            this.doneBtn.Name = "doneBtn";
            this.doneBtn.Size = new System.Drawing.Size(260, 42);
            this.doneBtn.TabIndex = 4;
            this.doneBtn.Text = "Done";
            this.doneBtn.UseVisualStyleBackColor = true;
            this.doneBtn.Click += new System.EventHandler(this.doneBtn_Click);
            // 
            // PrizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 223);
            this.Controls.Add(this.doneBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOfDescription);
            this.Controls.Add(this.textBoxNameOfPrize);
            this.Name = "PrizeForm";
            this.Text = "PrizeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNameOfPrize;
        private System.Windows.Forms.TextBox textBoxOfDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button doneBtn;
    }
}