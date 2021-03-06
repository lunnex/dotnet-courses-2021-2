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
        Data data;

        public PrizeForm(Data data)
        {
            this.data = data;
            InitializeComponent();
        }

        public PrizeForm(Prize prize, Data data)
        {
            InitializeComponent();
            this.prize = prize;
            this.data = data;
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
                newPrize = new Prize(data.prizes.Count, textBoxNameOfPrize.Text, textBoxOfDescription.Text);
            }
            else
            {
                newPrize = new Prize(this.prize.ID, textBoxNameOfPrize.Text, textBoxOfDescription.Text);

                foreach (User user in data.users)
                {
                    user.EditPrize(this.prize.Title, newPrize.Title);
                }
            }

            for (int i = 0; i < data.prizes.Count; i++)
            {
                if (data.prizes[i].IsIDEquals(newPrize))
                {
                    data.prizes.Remove(prize);
                }
            }

            if (this.prize == null)
            {
                data.prizes.Add(newPrize);
                for(int i = 0; i <data.prizes.Count; i++)
                {
                    data.prizes[i].ID = i;
                }
            }
            else
            {
                data.prizes.Insert(this.prize.ID, newPrize);
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
