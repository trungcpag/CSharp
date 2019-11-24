using QuanLyQuanCaFe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaFe.DAO
{
    class CategoryDAO
    {
        private static CategoryDAO instance;
        public static CategoryDAO Instance
        {
            get { if (instance == null) instance = new CategoryDAO(); return instance; }
            private set { instance = value; }
        }
        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            List<Category> listCategory = new List<Category>();
            string query = "select * from FoodCategory";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                Category cate = new Category(item);
                listCategory.Add(cate);
            }
            return listCategory;
        }

        public Category GetCategoryByID(int id)
        {
            Category category = null;
            string query = "select * from FoodCategory where id = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }
            return category;
        }
    }
}
