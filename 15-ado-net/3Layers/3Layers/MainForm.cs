using Entities;
using Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class MainForm : Form
    {
        private readonly IPrizeBL _prizeBL;
        private readonly IUserBL _userBL;

        private BindingList<User> _bindingListUser;
        private BindingList<Prize> _bindingListPrize;
        private bool _userPageIsActive = false;
        private bool _prizePageIsActive = false;
        public MainForm(IPrizeBL prizeBL, IUserBL userBL)
        {
            InitializeComponent();

            _prizeBL = prizeBL;
            _userBL = userBL;

            _userPageIsActive = true;
            _bindingListUser = new BindingList<User>(_userBL.GetAll());
            _bindingListPrize = new BindingList<Prize>(_prizeBL.GetAll());
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
            var addUserForm = new UserForm(_prizeBL, _userBL);
            addUserForm.ShowDialog();
            _bindingListUser = new BindingList<User>(_userBL.GetAll());
            dataGridView.DataSource = _bindingListUser;
        }

        private void editUserBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                User user = (User)dataGridView.SelectedCells[0].OwningRow.DataBoundItem;

                var form = new UserForm(user, _prizeBL,_userBL);
                form.ShowDialog();
                _bindingListUser = new BindingList<User>(_userBL.GetAll());
                dataGridView.DataSource = _bindingListUser;
            }
        }

        private void deleteUserBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                User user = (User)dataGridView.SelectedCells[0].OwningRow.DataBoundItem;
                var warningForm = new ErrorForm("The information about this user will be deleted!", user, _prizeBL, _userBL);
                warningForm.ShowDialog();
                _bindingListUser = new BindingList<User>(_userBL.GetAll());
                dataGridView.DataSource = _bindingListUser;
            }
        }

        private void sortGridView(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (_userPageIsActive && !_prizePageIsActive)
            {
                IList<User> allux = new List<User>();
                if (e.ColumnIndex == 0)
                {
                    allux = _userBL.GetAll().OrderBy(user => user.ID).ToList();
                }
                else if (e.ColumnIndex == 1)
                {
                    allux = _userBL.GetAll().OrderBy(user => user.FirstName).ToList();
                }
                else if (e.ColumnIndex == 2)
                {
                    allux = _userBL.GetAll().OrderBy(user => user.LastName).ToList();
                }
                else if (e.ColumnIndex == 3)
                {
                    allux = _userBL.GetAll().OrderBy(user => user.DateOfBirth).ToList();
                }
                else if (e.ColumnIndex == 4)
                {
                    allux = _userBL.GetAll().OrderBy(user => user.Age).ToList();
                }
                else if (e.ColumnIndex == 5)
                {
                    allux = _userBL.GetAll().OrderBy(user => user.PrizeStr).ToList();
                }
                //_userBL.Clear();

                //for (int i = 0; i < allux.Count; i++)
                //{
                //    _userBL.Add(allux[i]);
                //}
                _bindingListUser = new BindingList<User>(allux);
                dataGridView.DataSource = _bindingListUser;
            }

            else if (!_userPageIsActive && _prizePageIsActive)
            {
                IList<Prize> allux = new List<Prize>();
                if (e.ColumnIndex == 0)
                {
                    allux = _prizeBL.GetAll().OrderBy(prize => prize.ID).ToList();
                }
                else if (e.ColumnIndex == 1)
                {
                    allux = _prizeBL.GetAll().OrderBy(prize => prize.Title).ToList();
                }
                else if (e.ColumnIndex == 2)
                {
                    allux = _prizeBL.GetAll().OrderBy(prize => prize.Description).ToList();
                }

                _bindingListPrize = new BindingList<Prize>(allux);
                dataGridView.DataSource = _bindingListPrize;

            }
            
        }

        private void prizesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _prizePageIsActive = true;
            _userPageIsActive = false;
            _bindingListPrize = new BindingList<Prize>(_prizeBL.GetAll());
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
            _bindingListUser = new BindingList<User>(new List<User>(_userBL.GetAll()));
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
            var addPrizeForm = new PrizeForm(_prizeBL, _userBL);
            
            addPrizeForm.ShowDialog();
            //_bindingListPrize.
            _bindingListPrize = new BindingList<Prize>(_prizeBL.GetAll());
            dataGridView.DataSource = _bindingListPrize;
            dataGridView.Refresh();
        }

        private void editPrizeBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                Prize prize = (Prize)dataGridView.SelectedCells[0].OwningRow.DataBoundItem;

                var form = new PrizeForm(prize, _prizeBL, _userBL);
                form.ShowDialog();
                _bindingListPrize = new BindingList<Prize>(_prizeBL.GetAll());
                dataGridView.DataSource = _bindingListPrize;
                _bindingListUser = new BindingList<User>(_userBL.GetAll());

            }
        }

        private void deletePrizeBtn_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                Prize prize = (Prize)dataGridView.SelectedCells[0].OwningRow.DataBoundItem;
                var warningForm = new ErrorForm("The information about this prize will be deleted!", prize, _prizeBL, _userBL);
                warningForm.ShowDialog();
                AgeementPrizesAndUsers();
                _bindingListPrize = new BindingList<Prize>(_prizeBL.GetAll());
                dataGridView.DataSource = _bindingListPrize;

            }
        }

        public void AgeementPrizesAndUsers()
        {
            string[] prizeNames = new string[_prizeBL.GetAll().Count()];
            for (int i = 0; i < _prizeBL.GetAll().Count(); i++)
            {
                prizeNames[i] = _prizeBL.GetAll().ElementAt(i).Title;
            }

            //for (int i = 0; i < _prizeBL.GetAll().Count(); i++)
            //{
            //    _userBL.GetAll().ElementAt(i).RemovePrizeIfItHasBeenDeleted(prizeNames);
            //}
        }
    }
}
