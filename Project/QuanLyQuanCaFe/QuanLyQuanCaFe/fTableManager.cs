using QuanLyQuanCaFe.DAO;
using QuanLyQuanCaFe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCaFe
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
        }

        #region Method
        void LoadTable() {
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
            //Console.WriteLine(listBillInfo.ToString());
            foreach(DTO.Menu item in listBillInfo)
            {
                //Console.WriteLine("Hello " + item.FoodID.ToString());
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                lsvBill.Items.Add(lsvItem);
            }


        }
        #endregion

        #region Events
        void btn_Click(object sender, EventArgs e) {
            int tableID = ((sender as Button).Tag as Table).ID;
            Console.WriteLine(tableID+ "baclajskj");
            showBill(tableID);
        }


        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.ShowDialog();
        }
        #endregion

        private void fTableManager_Load(object sender, EventArgs e)
        {

        }
    }
}
