using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaFe.DTO
{
    public class BillInfo
    {

        public BillInfo(int id, int billID, int foodID, int count)
        {
            this.iD = id;
            this.billID = billID;
            this.foodID = foodID;
            this.count = count;
        }

        public BillInfo(DataRow row)
        {
            this.iD = (int)row["id"];
            this.billID = (int)row["idBill"];
            this.foodID= (int)row["idFood"];
            this.count= (int)row["count"];
        }

        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private int billID;

        public int BillID
        {
            get { return billID; }
            set { billID = value; }
        }

        private int foodID;

        public int FoodID
        {
            get { return foodID; }
            set { foodID = value; }
        }

        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

    }
}
