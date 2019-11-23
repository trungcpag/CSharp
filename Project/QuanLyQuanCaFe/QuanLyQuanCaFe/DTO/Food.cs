using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaFe.DTO
{
    public class Food
    {
        public Food(int id, string name, int categoryID, float price)
        {
            this.iD = id;
            this.name = name;
            this.categoryID = categoryID;
            this.price = price;
        }

        public Food(DataRow row)
        {
            this.iD = (int)row["id"];
            this.name = row["Name"].ToString();
            this.categoryID = (int)row["idCategory"];
            this.price = (float)Convert.ToDouble(row["price"].ToString());
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int categoryID;

        public int CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }

        private float price;

        public float Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
