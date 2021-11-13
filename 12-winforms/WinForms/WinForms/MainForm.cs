using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    
    public partial class MainForm : Form
    {
        private BindingList<User> _bindingListUser;
        private BindingList<Prize> _bindingListPrize;
        private bool _userPageIsActive = false;
        private bool _prizePageIsActive = false;
        public MainForm()
        {
            InitializeComponent();
            _userPageIsActive = true;
            _bindingListUser = new BindingList<User>(Data.users);
            dataGridView.DataSource = _bindingListUser;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.ReadOnly = true;

            addUserBtn.Visible = true;
            editUserBtn.Visible = true;
            deleteUserBtn.Visible = true;

            addPrizeBtn.Visible = false;
            editPrizeBtn.Visible = false;
            deletePrizeBtn.Visible = false;
        }

        private void addUserBtn_Click(object sender, EventArgs e)
        {
            var addUserForm = new UserForm();
            addUserForm.ShowDialog();
            _bindingListUser.ResetBindings();
        }

        private void editUserBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                User user = (User)dataGridView.SelectedCells[0].OwningRow.DataBoundItem;

                var form = new UserForm(user);
                form.ShowDialog();
                _bindingListUser.ResetBindings();
            }
        }

        private void deleteUserBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                User user = (User)dataGridView.SelectedCells[0].OwningRow.DataBoundItem;
                var warningForm = new ErrorForm("The information about this user will be deleted!", user);
                warningForm.ShowDialog();
                _bindingListUser.ResetBindings();

            }
        }

        private void sortGridView(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_userPageIsActive && !_prizePageIsActive)
            {
                IList<User> allux = new List<User>();
                if (e.ColumnIndex == 0)
                {
                    allux = Data.users.OrderBy(user => user.ID).ToList();
                }
                else if (e.ColumnIndex == 1)
                {
                    allux = Data.users.OrderBy(user => user.FirstName).ToList();
                }
                else if (e.ColumnIndex == 2)
                {
                    allux = Data.users.OrderBy(user => user.LastName).ToList();
                }
                else if (e.ColumnIndex == 3)
                {
                    allux = Data.users.OrderBy(user => user.DateOfBirth).ToList();
                }
                else if (e.ColumnIndex == 4)
                {
                    allux = Data.users.OrderBy(user => user.Age).ToList();
                }
                else if (e.ColumnIndex == 5)
                {
                    allux = Data.users.OrderBy(user => user.PrizeStr).ToList();
                }
                Data.users.Clear();

                for (int i = 0; i < allux.Count; i++)
                {
                    Data.users.Add(allux[i]);
                }
                _bindingListUser.ResetBindings();
            }

            else if (!_userPageIsActive && _prizePageIsActive)
            {
                IList<Prize> allux = new List<Prize>();
                if (e.ColumnIndex == 0)
                {
                    allux = Data.prizes.OrderBy(prize => prize.ID).ToList();
                }
                else if (e.ColumnIndex == 1)
                {
                    allux = Data.prizes.OrderBy(prize => prize.Title).ToList();
                }
                else if (e.ColumnIndex == 2)
                {
                    allux = Data.prizes.OrderBy(prize => prize.Description).ToList();
                }
                Data.prizes.Clear();

                for (int i = 0; i < allux.Count; i++)
                {
                    Data.prizes.Add(allux[i]);
                }
                _bindingListPrize.ResetBindings();

            }
            
        }

        private void prizesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _prizePageIsActive = true;
            _userPageIsActive = false;
            _bindingListPrize = new BindingList<Prize>(Data.prizes);
            dataGridView.DataSource = _bindingListPrize;

            addUserBtn.Visible = false;
            editUserBtn.Visible = false;
            deleteUserBtn.Visible = false;

            addPrizeBtn.Visible = true;
            editPrizeBtn.Visible = true;
            deletePrizeBtn.Visible = true;
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _prizePageIsActive = false;
            _userPageIsActive = true;
            _bindingListUser = new BindingList<User>(Data.users);
            dataGridView.DataSource = _bindingListUser;

            addUserBtn.Visible = true;
            editUserBtn.Visible = true;
            deleteUserBtn.Visible = true;

            addPrizeBtn.Visible = false;
            editPrizeBtn.Visible = false;
            deletePrizeBtn.Visible = false;
        }

        private void addPrizeBtn_Click(object sender, EventArgs e)
        {
            var addPrizeForm = new PrizeForm();
            
            addPrizeForm.ShowDialog();
            _bindingListPrize.ResetBindings();
        }

        private void editPrizeBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                Prize prize = (Prize)dataGridView.SelectedCells[0].OwningRow.DataBoundItem;

                var form = new PrizeForm(prize);
                form.ShowDialog();
                _bindingListPrize.ResetBindings();
                _bindingListUser.ResetBindings();

            }
        }

        private void deletePrizeBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                Prize prize = (Prize)dataGridView.SelectedCells[0].OwningRow.DataBoundItem;
                var warningForm = new ErrorForm("The information about this prize will be deleted!", prize);
                warningForm.ShowDialog();
                AgeementPrizesAndUsers();
                _bindingListPrize.ResetBindings();
                
            }
        }

        public void AgeementPrizesAndUsers()
        {
            string[] prizeNames = new string[Data.prizes.Count];
            for (int i = 0; i < Data.prizes.Count; i++)
            {
                prizeNames[i] = Data.prizes[i].Title;
            }

            for (int i = 0; i < Data.users.Count; i++)
            {
                Data.users[i].RemovePrizeIfItHasBeenDeleted(prizeNames);
            }
        }
    }
}
