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
    public partial class UserForm : Form
    {
        string FirstNameOfUser;
        string SecondNameOfUser;
        string DOBOfUser;
        IList<string> CheckedPrizes = new List<string>();

        private readonly User _user;
        private readonly Prize _prize;

        private readonly IPrizeBL _prizeBL;
        private readonly IUserBL _userBL;

        public UserForm(IPrizeBL prizeBL, IUserBL userBL)
        {
            InitializeComponent();
            _prizeBL = prizeBL;
            _userBL = userBL;

            string[] prizeNames = new string[_prizeBL.GetAll().Count]; 

            for (int i = 0; i < _prizeBL.GetAll().Count; i++)
            {
                prizeNames[i] = _prizeBL.GetAll()[i].Title;
            }

            clbUsers.Items.AddRange(prizeNames);
        }

        public UserForm(User user, IPrizeBL prizeBL, IUserBL userBL)
        {
            InitializeComponent();
            _prizeBL = prizeBL;
            _userBL = userBL;

            this.FirstNameOfUser = user.FirstName;
            this.SecondNameOfUser = user.LastName;
            this.DOBOfUser = user.DateOfBirth.ToString();
            _user = user;

            string[] prizeNames = new string[_prizeBL.GetAll().Count()];

            for (int i = 0; i < user.ListOfPrize.Count; i++)
            {
                CheckedPrizes.Add(user.ListOfPrize[i]);
            }

            for (int i = 0; i < _prizeBL.GetAll().Count(); i++)
            {
                clbUsers.Items.Add(new List<Prize>(_prizeBL.GetAll())[i].Title);
                textBoxFirstName.Text = FirstNameOfUser;
                textBoxSecondName.Text = SecondNameOfUser;
                dateTimePickerDOB.Value = DateTime.Parse(DOBOfUser).Date;
            }
        
            for (int i = 0; i < _prizeBL.GetAll().Count(); i++)
            {
                for (int j = 0; j < CheckedPrizes.Count; j++)
                {
                    if (new List<Prize>(_prizeBL.GetAll())[i].Title == CheckedPrizes[j])
                    {
                        clbUsers.SetItemCheckState(i, CheckState.Checked);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IList<string>checkedPrizes = new List<string>();
            for(int i = 0; i < clbUsers.CheckedItems.Count; i++)
            {
                checkedPrizes.Add(clbUsers.CheckedItems[i].ToString());
            }

            if (textBoxFirstName.Text == "")
            {
                ErrorForm errorForm = new ErrorForm("Name sholdn't be empty!", _prizeBL, _userBL);
                errorForm.ShowDialog();
                return;
            }

            if (textBoxSecondName.Text == "")
            {
                ErrorForm errorForm = new ErrorForm("Second name sholdn't be empty!", _prizeBL, _userBL);
                errorForm.ShowDialog();
                return;
            }

            if (dateTimePickerDOB.Value > DateTime.Today)
            {
                ErrorForm errorForm = new ErrorForm("Date is incorrect!", _prizeBL, _userBL);
                errorForm.ShowDialog();
                return;
            }

            if (User.AgeCalculation(dateTimePickerDOB.Value) > 150)
            {
                ErrorForm errorForm = new ErrorForm("User couldn't be older then 150 y.o.", _prizeBL, _userBL);
                errorForm.ShowDialog();
                return;
            }

            List<int> listOfId = new List<int>();
            foreach (User user in _userBL.GetAll())
            {
                listOfId.Add(user.ID);
            }

            User newUser;
            if (_user == null)
            {
                newUser = new User(listOfId.Max()+1, textBoxFirstName.Text, textBoxSecondName.Text, dateTimePickerDOB.Value.Date.ToString(), checkedPrizes);
            }
            else
            {
                newUser = new User(_user.ID, textBoxFirstName.Text, textBoxSecondName.Text, dateTimePickerDOB.Value.Date.ToString(), checkedPrizes);
            }

            for (int i = 0; i < _userBL.GetAll().Count(); i++)
            {
                if (new List<User>(_userBL.GetAll())[i].IsIDEquals(newUser))
                {
                    _userBL.Delete(_user);
                }
            }


            if (_user == null)
            {
                _userBL.Add(newUser);
            }
            else
            {
                _userBL.Edit(newUser);
            }
            Close();
        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            if(textBoxFirstName.Text.Length > 50)
            {
                textBoxSecondName.Focus();
                string str = textBoxFirstName.Text;
                str = str.Remove(str.Length-1);
                textBoxFirstName.Text = str;
            }
        }

        private void textBoxSecondName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxSecondName.Text.Length > 50)
            {
                dateTimePickerDOB.Focus();
                string str = textBoxSecondName.Text;
                str = str.Remove(str.Length - 1);
                textBoxSecondName.Text = str;
            }
        }
    }
}
