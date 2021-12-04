using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinForms
{
    public partial class PrizeForm : Form
    {
        private readonly Prize _prize;
        private readonly User _user;

        private readonly IPrizeBL _prizeBL;
        private readonly IUserBL _userBL;

        public PrizeForm(IPrizeBL prizeBL, IUserBL userBL)
        { 
            InitializeComponent();
            _prizeBL = prizeBL;
            _userBL = userBL;
        }

        public PrizeForm(Prize prize, IPrizeBL prizeBL, IUserBL userBL)
        {
            InitializeComponent();
            _prizeBL = prizeBL;
            _userBL = userBL;
            _prize = prize;

            textBoxNameOfPrize.Text = prize.Title;
            textBoxOfDescription.Text = prize.Description;
        }
        private void doneBtn_Click(object sender, EventArgs e)
        {
            Prize newPrize;

            if (textBoxNameOfPrize.Text == "")
            {
                ErrorForm errorForm = new ErrorForm("Name sholdn't be empty!", _prizeBL, _userBL);
                errorForm.ShowDialog();
                return;
            }

            if (_prize == null)
            {
                newPrize = new Prize(_prizeBL.GetAll().Count(), textBoxNameOfPrize.Text, textBoxOfDescription.Text);
            }
            else
            {
                newPrize = new Prize(_prize.ID, textBoxNameOfPrize.Text, textBoxOfDescription.Text);

                foreach (User user in _userBL.GetAll())
                {
                    user.EditPrize(_prize.Title, newPrize.Title);
                }
            }

            for (int i = 0; i < _prizeBL.GetAll().Count(); i++)
            {
                if (new List<Prize>(_prizeBL.GetAll())[i].IsIDEquals(newPrize))
                {
                    _prizeBL.Delete(_prize);
                }
            }

            if (_prize == null)
            {
                _prizeBL.Add(newPrize);
            }
            else
            {
                _prizeBL.Edit(newPrize);
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
