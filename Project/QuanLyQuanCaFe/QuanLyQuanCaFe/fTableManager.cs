using QuanLyQuanCaFe.DAO;
using QuanLyQuanCaFe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaFe
{
    public partial class fTableManager : Form
    {
        private Account loginAccount;

        public Account LoginAccount 
        { 
            get
            {
                return loginAccount;
            }
            set 
            { 
                loginAccount = value;
                
            }
        }

        public fTableManager(Account acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            changeAccount(loginAccount.Type);
            LoadTable();
            loadCategory();
            LoadComboBoxTable(cbSwitchTable);
        }

        #region Method

        void changeAccount(int type)
        {
            adminToolStripMenuItem.Enabled= type == 1;
            thôngTinCáNhânToolStripMenuItem.Text += "("+ loginAccount.DisplayName+")";
            thoongToolStripMenuItem.Text += "(" + loginAccount.DisplayName + ")";
        }
            
        void loadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.GetListCategory();
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Name";
        }

        void LoadFoodListByCategoryID(int id)
        {
            List<Food> ListFood = FoodDAO.Instance.GetFoodByCategory(id);
            cbFood.DataSource = ListFood;
            cbFood.DisplayMember = "Name";
        }
        void LoadTable() {
            flpTable.Controls.Clear();
            List<Table> tableList =  TableDAO.Instance.LoadTableList();
            foreach(Table item in tableList)
            {
                
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case
                        "Trống":{
                            btn.BackColor = Color.Aqua;
                            break; }
                    default:
                        btn.BackColor = Color.Pink;
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }

        void showBill(int id) {
            lsvBill.Items.Clear();
            List<DTO.Menu> listBillInfo = MenuDAO.Instance.GetListMenuByTable(id);
            float totalPrice = 0.0f;
            //Console.WriteLine(listBillInfo.ToString());
            foreach(DTO.Menu item in listBillInfo)
            {
                //Console.WriteLine("Hello " + item.FoodID.ToString());
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                lsvBill.Items.Add(lsvItem);
            }

            txbtotalPrice.Text = totalPrice.ToString("c",new CultureInfo("vi-VN"));
            
        }

        public void LoadComboBoxTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }

        #endregion

        #region Events
        void btn_Click(object sender, EventArgs e) {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;
            showBill(tableID);
        }


        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(loginAccount);
            f.UpdateEventAccount += f_UpdateEventAccount;
            f.ShowDialog();

        }

        private void f_UpdateEventAccount(object sender, AccountEvent e)
        {
            thoongToolStripMenuItem.Text = "Thông tin tài khoản " + e.Acc.DisplayName;
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }
        

        private void fTableManager_Load(object sender, EventArgs e)
        {

        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) return;
            Category selected = cb.SelectedItem as Category;

            id = selected.ID;

            LoadFoodListByCategoryID(id);
        }
        
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int idFood = (cbFood.SelectedItem as Food).ID;
            int count = (int)nmFoodCount.Value;
            if(idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.ID);
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxBill(), idFood, count);

            } else
            {
                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxBill(), idFood, count);
            }
            showBill(table.ID);
            LoadTable();
        }
     

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            Table table = lsvBill.Tag as Table;
            int idBill = BillDAO.Instance.GetUncheckBillIDByTableID(table.ID);
            int discount = (int)nmDiscount.Value;
            double totalPrice = Convert.ToDouble(txbtotalPrice.Text.Split(',')[0]);
            double finalPrice = totalPrice - (totalPrice / 100) * discount;
            if(idBill != -1)
            {
                if(MessageBox.Show(string.Format("Bạn có muốn thanh toán bàn {0} \n tổng tiền: giá - giảm giá  \n {1} - {1}*{2} = {3}  ",table.Name, totalPrice, discount, finalPrice), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    BillDAO.Instance.CheckOut(idBill, discount, (float)finalPrice);
                    showBill(table.ID);
                    LoadTable();
                }
            }
        }
      

        private void btnSwitchTable_Click(object sender, EventArgs e)
        {
            int id1 = (lsvBill.Tag as Table).ID;
            int id2 = (cbSwitchTable.SelectedItem as Table).ID;
            if (MessageBox.Show(string.Format("Bạn có muốn chuyển bản{0} sang {1}", (lsvBill.Tag as Table).Name, (cbSwitchTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.SwitchTable(id1, id2);
                LoadTable();
            }
        }
        #endregion
    }
}
