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

        public fAdmin()
        {
            InitializeComponent();
            Load();
        }

        void Load()
        {
            dtgvFood.DataSource = foodList;
            LoadDateTimePickerBill();
            LoadListFood();
            LoadListBillByDate(dtpkFromDate.Value, dtpkToDate.Value);
            LoadCategoryIntoComboBox(cbFoodCategory);
            AddFoodBinding();
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
            txbFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "Name"));
            txbFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID"));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "Price"));

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
            if(dtgvFood.SelectedCells.Count > 0)
            {
                int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;

                Category category = CategoryDAO.Instance.GetCategoryByID(id);
                cbFoodCategory.SelectedItem = category;
                int index = -1;
                int i = 0;
                foreach(Category item in cbFoodCategory.Items)
                {
                    if(item.ID == category.ID)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbFoodCategory.SelectedIndex = index;
            }

            
        }
    }
}
