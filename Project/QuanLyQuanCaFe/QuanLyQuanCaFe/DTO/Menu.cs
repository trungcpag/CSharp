using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaFe.DTO
{
    public class Menu
    {
        public Menu(string foodName, int count, float price, float totalPrice = 0)
        {
            this.foodName = foodName;
            this.count = count;
            this.price = price;
            this.totalPrice = totalPrice;
        }

        public Menu(DataRow row)
        {
            this.foodName = row["name"].ToString();
            this.count = (int)row["count"];
            this.price = (float)Convert.ToDouble(row["price"].ToString());
            this.totalPrice = (float)Convert.ToDouble(row["totalPrice"].ToString());
        }
        private string foodName;
        public string FoodName
        {
            get { return foodName; }
            set { foodName = value; }
        }

        private int count;
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
        private float price;
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        private float totalPrice;
        public float TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; }
        }
    }
}
