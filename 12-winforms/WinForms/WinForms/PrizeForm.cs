using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForms
{
    public partial class PrizeForm : Form
    {
        Prize prize;

        public PrizeForm()
        {
            InitializeComponent();
        }

        public PrizeForm(Prize prize)
        {
            InitializeComponent();
            this.prize = prize;
            textBoxNameOfPrize.Text = prize.Title;
            textBoxOfDescription.Text = prize.Description;
        }
        private void doneBtn_Click(object sender, EventArgs e)
        {
            Prize newPrize;

            if (textBoxNameOfPrize.Text == "")
            {
                ErrorForm errorForm = new ErrorForm("Name sholdn't be empty!");
                errorForm.ShowDialog();
                return;
            }

            if (this.prize == null)
            {
                newPrize = new Prize(Data.prizes.Count, textBoxNameOfPrize.Text, textBoxOfDescription.Text);
            }
            else
            {
                newPrize = new Prize(this.prize.ID, textBoxNameOfPrize.Text, textBoxOfDescription.Text);

                foreach (User user in Data.users)
                {
                    user.EditPrize(this.prize.Title, newPrize.Title);
                }
            }

            for (int i = 0; i < Data.prizes.Count; i++)
            {
                if (Data.prizes[i].IsIDEquals(newPrize))
                {
                    Data.prizes.Remove(prize);
                }
            }

            if (this.prize == null)
            {
                Data.prizes.Add(newPrize);
            }
            else
            {
                Data.prizes.Insert(this.prize.ID, newPrize);
            }
            
            Close();
        }

        private void textBoxNameOfPrize_TextChanged(object sender, EventArgs e)
        {
            if (textBoxNameOfPrize.Text.Length > 50)
            {
                textBoxOfDescription.Focus();
                string str = textBoxNameOfPrize.Text;
                str = str.Remove(str.Length - 1);
                textBoxNameOfPrize.Text = str;
            }
        }

        private void textBoxOfDescription_TextChanged(object sender, EventArgs e)
        {
            if (textBoxOfDescription.Text.Length > 250)
            {
                doneBtn.Focus();
                string str = textBoxOfDescription.Text;
                str = str.Remove(str.Length - 1);
                textBoxOfDescription.Text = str;
            }
        }
    }
}
