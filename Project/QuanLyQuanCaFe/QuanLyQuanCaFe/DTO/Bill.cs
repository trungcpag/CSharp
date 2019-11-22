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

        public Bill(int iD, DateTime? dateCheckIn, DateTime? dataCheckOut, int status)
        {
            this.iD = iD;
            this.dateCheckIn = dateCheckIn;
            this.DateCheckOut = dataCheckOut;
            this.status = status;
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
        }
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int status;   
        private int iD;

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
