using QuanLyQuanCaFe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaFe.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;
        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return instance; }
            private set { instance = value; }
        }
        private FoodDAO() { }

        public List<Food> GetFoodByCategory(int id)
        {
            List<Food> listFood = new List<Food>();
            string query = "select * from food where idCategory = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }
            return listFood;
        }
        public List<Food> GetListFood()
        {
            List<Food> listFood = new List<Food>();
            string query = "select * from food";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }
            return listFood;
        }

        public List<Food> SearchFoodByName(string name)
        {
            List<Food> listFood = new List<Food>();
            string query = string.Format("select * from food where dbo.fChuyenCoDauThanhKhongDau(name) '%{0}%'", name);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Food food = new Food(item);
                listFood.Add(food);
            }
            return listFood;
        }

        public bool InsertFood(string name, int id, float price)
        {
            string query = string.Format("insert dbo.Food(name, idCategory, price) values (N'{0}', {1} , {2}  )", name, id, price);
            int res = DataProvider.Instance.ExecuteNonQuery(query);
            return res > 0;
        }

        public bool UpdateFood(int idfood, string name, int id, float price)
        {
            string query = string.Format("update Food set Name = N'{0}' , idCategory = {1} , price = {2} where id = {3} ", name, id, price, idfood);
            int res = DataProvider.Instance.ExecuteNonQuery(query);
            return res > 0;
        }
        public bool DeleteFood(int idfood)
        {
            BillInfoDAO.Instance.DeleteBillInfoByFoodID(idfood);
            string query = string.Format("Delete food where id = {0} ", idfood);
            int res = DataProvider.Instance.ExecuteNonQuery(query);
            return res > 0;
        }
    }
}
