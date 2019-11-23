using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaFe.DTO
{
    public class Bill
    {

        public Bill(int iD, DateTime? dateCheckIn, DateTime? dataCheckOut, int status, int discount = 0)
        {
            this.iD = iD;
            this.dateCheckIn = dateCheckIn;
            this.DateCheckOut = dataCheckOut;
            this.status = status;
            this.discount = discount;
        }
        public Bill(DataRow row)
        {
            this.iD = (int)row["id"];
            this.dateCheckIn = (DateTime?)row["DataCheckIn"];
            var datatimeTemp = row["DataCheckOut"];
            if(datatimeTemp.ToString() != "")
            {
                this.dateCheckOut = (DateTime?)datatimeTemp;
            }
            this.status = (int)row["status"];
            this.discount = (int)row["discount"];
        }
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int status;   
        private int iD;
        private int discount;

        public int Discount
        {
            get { return discount; }
            set { discount = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
        }

        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }
        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }
    }
}
