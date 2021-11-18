using Entities;
using Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinForms
{
    public partial class ErrorForm : Form
    {
        private readonly User _user;
        private readonly Prize _prize;

        private readonly IUserBL _userBL;
        private readonly IPrizeBL _prizeBL;

        public ErrorForm(string labelText, IPrizeBL prizeBL, IUserBL userBL)
        {
            InitializeComponent();
            _prizeBL = prizeBL;
            _userBL = userBL;
            ErrorText.Text = labelText;
        }

        public ErrorForm(string labelText, User user, IPrizeBL prizeBL, IUserBL userBL)
        {
            InitializeComponent();
            _prizeBL = prizeBL;
            _userBL = userBL;
            this._user = user;
            ErrorText.Text = labelText;
        }

        public ErrorForm(string labelText, Prize prize, IPrizeBL prizeBL, IUserBL userBL)
        {
            InitializeComponent();
            _prizeBL = prizeBL;
            _userBL = userBL;
            this._prize = prize;
            ErrorText.Text = labelText;
        }

        private void OKbtn_Click(object sender, EventArgs e)
        {
            if (this._user != null)
            {
                _userBL.Delete(_user);
            }

            if (this._prize != null)
            {
                _prizeBL.Delete(_prize);
            }
            Close();
        }

        private void ErrorText_Click(object sender, EventArgs e)
        {

        }
    }
}
