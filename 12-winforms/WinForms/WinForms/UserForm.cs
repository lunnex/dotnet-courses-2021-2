using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        User user;

        public UserForm()
        {
            InitializeComponent();

            string[] prizeNames = new string[Data.prizes.Count]; 

            for (int i = 0; i < Data.prizes.Count; i++)
            {
                prizeNames[i] = Data.prizes[i].Title;
            }

            clbUsers.Items.AddRange(prizeNames);
        }

        public UserForm(User user)
        {
            InitializeComponent();
            this.FirstNameOfUser = user.FirstName;
            this.SecondNameOfUser = user.LastName;
            this.DOBOfUser = user.DateOfBirth.ToString();
            this.user = user;

            string[] prizeNames = new string[Data.prizes.Count];

            for (int i = 0; i < user.ListOfPrize.Count; i++)
            {
                CheckedPrizes.Add(user.ListOfPrize[i]);
            }

            for (int i = 0; i < Data.prizes.Count; i++)
            {
                clbUsers.Items.Add(Data.prizes[i].Title);
                textBoxFirstName.Text = FirstNameOfUser;
                textBoxSecondName.Text = SecondNameOfUser;
                dateTimePickerDOB.Value = DateTime.Parse(DOBOfUser).Date;
            }
        
            for (int i = 0; i < Data.prizes.Count; i++)
            {
                for (int j = 0; j < CheckedPrizes.Count; j++)
                {
                    if (Data.prizes[i].Title == CheckedPrizes[j])
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
                ErrorForm errorForm = new ErrorForm("Name sholdn't be empty!");
                errorForm.ShowDialog();
                return;
            }

            if (textBoxSecondName.Text == "")
            {
                ErrorForm errorForm = new ErrorForm("Second name sholdn't be empty!");
                errorForm.ShowDialog();
                return;
            }

            if (dateTimePickerDOB.Value > DateTime.Today)
            {
                ErrorForm errorForm = new ErrorForm("Date is incorrect!");
                errorForm.ShowDialog();
                return;
            }

            if (User.AgeCalculation(dateTimePickerDOB.Value) > 150)
            {
                ErrorForm errorForm = new ErrorForm("User couldn't be older then 150 y.o.");
                errorForm.ShowDialog();
                return;
            }

            User newUser;
            if (this.user == null)
            {
                newUser = new User(Data.users.Count, textBoxFirstName.Text, textBoxSecondName.Text, dateTimePickerDOB.Value.Date.ToString(), checkedPrizes);
            }
            else
            {
                newUser = new User(this.user.ID, textBoxFirstName.Text, textBoxSecondName.Text, dateTimePickerDOB.Value.Date.ToString(), checkedPrizes);
            }

            for (int i = 0; i < Data.users.Count; i++)
            {
                if (Data.users[i].IsIDEquals(newUser))
                {
                    Data.users.Remove(user);
                }
            }


            if (this.user == null)
            {
                Data.users.Add(newUser);
            }
            else
            {
                Data.users.Insert(this.user.ID, newUser);
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
