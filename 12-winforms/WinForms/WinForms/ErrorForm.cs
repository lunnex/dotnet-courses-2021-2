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
        User user;
        Prize prize;

        public ErrorForm(string labelText)
        {
            InitializeComponent();
            ErrorText.Text = labelText;
        }

        public ErrorForm(string labelText, User user)
        {
            InitializeComponent();
            this.user = user;
            ErrorText.Text = labelText;
        }

        public ErrorForm(string labelText, Prize prize)
        {
            InitializeComponent();
            this.prize = prize;
            ErrorText.Text = labelText;
        }

        private void OKbtn_Click(object sender, EventArgs e)
        {
            if (this.user != null)
            {
                Data.users.Remove(user);
            }

            if (this.prize != null)
            {
                Data.prizes.Remove(prize);
            }
            Close();
        }

        private void ErrorText_Click(object sender, EventArgs e)
        {

        }
    }
}
