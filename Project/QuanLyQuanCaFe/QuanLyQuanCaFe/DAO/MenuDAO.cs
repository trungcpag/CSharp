using QuanLyQuanCaFe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaFe.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;
        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return instance; }
            private set { instance = value; }
        }
        private MenuDAO() { }

        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();
            DataTable data = DataProvider.Instance.ExecuteQuery("select f.name, bi.count, f.price, f.price*bi.count as totalPrice from billInfo as bi, bill as b, Food as f where bi.idBill = b.id and bi.idFood = f.id and b.idTable = "+id);
           
            foreach(DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }
            
            return listMenu;
        }
    }
}
