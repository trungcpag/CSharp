using QuanLyQuanCaFe.DAO;
using QuanLyQuanCaFe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaFe
{
    public partial class fAdmin : Form
    {
        BindingSource foodList = new BindingSource();
        BindingSource accountList = new BindingSource();

        public Account loginAccount;
        public fAdmin()
        {
            InitializeComponent();
            Load();
        }

        void Load()
        {
            dtgvFood.DataSource = foodList;
            dtgvAccount.DataSource = accountList;
            LoadDateTimePickerBill();
            LoadListFood();
            LoadAccount();
            AddAccountBinding();
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadCategoryIntoComboBox(cbFoodCategory);
            AddFoodBinding();
        }

        void AddAccountBinding()
        {
            txbUser.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "Username" ,true , DataSourceUpdateMode.Never));
            txbDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true , DataSourceUpdateMode.Never));
            nmType.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));
        }
        void LoadAccount() {
            accountList.DataSource = AccountDAO.Instance.GetListAccount();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            LoadListFood();
        }

        private void tcBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tpFood_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tpFoodCategory_Click(object sender, EventArgs e)
        {

        }

        private void dtgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region method
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpkFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = BillDAO.Instance.GetBillListByDate(checkIn, checkOut);
        }
        void LoadListFood()
        {
            foodList.DataSource = FoodDAO.Instance.GetListFood();
        }

        void AddFoodBinding()
        {
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price", true, DataSourceUpdateMode.Never));

        }

        void LoadCategoryIntoComboBox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }

        #endregion

        #region events
        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }
        #endregion

        private void txbFoodID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvFood.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                    Category category = CategoryDAO.Instance.GetCategoryByID(id);
                    cbFoodCategory.SelectedItem = category;
                    int index = -1;
                    int i = 0;
                    foreach (Category item in cbFoodCategory.Items)
                    {
                        if (item.ID == category.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cbFoodCategory.SelectedIndex = index;
                }
            }
            catch { }
            
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            if(FoodDAO.Instance.InsertFood(name, categoryID, price))
            {
                MessageBox.Show("Thêm thành công");
                LoadListFood();
                if (insertFood != null)
                {
                    insertFood(this, new EventArgs());
                }
            } else
            {
                MessageBox.Show("Lỗi thêm thức ăn");
            }

        }

        private void btnUpdateFood_Click(object sender, EventArgs e)
        {
            string name = txbFoodName.Text;
            int categoryID = (cbFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txbFoodID.Text);
            if (FoodDAO.Instance.UpdateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa thành công");
                LoadListFood();
                if(updateFood != null)
                {
                    updateFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Lỗi sửa thức ăn");
            }
        }

        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txbFoodID.Text);
            if (FoodDAO.Instance.DeleteFood(id))
            {
                MessageBox.Show("Xoá món thành công");
                LoadListFood();
                if (deleteFood != null)
                {
                    deleteFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Lỗi xóa món thức ăn");
            }
        }

        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }

        List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = new List<Food>();
            listFood = FoodDAO.Instance.SearchFoodByName(name);
            return listFood;
        }
        void AddAccount(string username, string displayName, int type)
        {
            if (AccountDAO.Instance.InsertAccount(username, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Lỗi thêm tài khoản!");
            }
            LoadAccount();
        }

        void UpdateAccount(string username, string displayName, int type)
        {
            if (AccountDAO.Instance.UpdateAccount(username, displayName, type))
            {
                MessageBox.Show("Cập nhật tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Lỗi cập nhật tài khoản!");
            }
            LoadAccount();

        }

        void DeleteAccount(string username)
        {
            if (loginAccount.Username.Equals(username))
            {
                MessageBox.Show("Vui lòng không có chính chủ");
                return;
            }
            if (AccountDAO.Instance.DeleteAccount(username))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Lỗi xóa tài khoản!");
            }
            LoadAccount();

        }

        private void btnSearchFood_Click(object sender, EventArgs e)
        {
             foodList.DataSource =  SearchFoodByName(txbSearchFoodName.Text);
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string username = txbUser.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)nmType.Value;

            AddAccount(username, displayName, type);

        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string username = txbUser.Text;
            DeleteAccount(username);
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string username = txbUser.Text;
            string displayName = txbDisplayName.Text;
            int type = (int)nmType.Value;

            UpdateAccount(username, displayName, type);
        }

        void ResetPass(string username)
        {
            if (AccountDAO.Instance.ResetPass(username))
            {
                MessageBox.Show("Đặt lại tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Lỗi đặt lại tài khoản!");
            }
     
        }

        private void btnResetPassWord_Click(object sender, EventArgs e)
        {
            string username = txbUser.Text;
            ResetPass(username);
        }
    }
}
