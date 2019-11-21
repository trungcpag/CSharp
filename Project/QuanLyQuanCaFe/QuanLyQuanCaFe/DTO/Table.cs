using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaFe.DTO
{
    public class Table
    {
        public Table(int id, string name, string status)
        {
            this.iD = id;
            this.name = name;
            this.status = status;
        }

        public Table(DataRow row)
        {
            this.iD = (int)row["id"];
            this.name = row["name"].ToString();
            this.status = row["status"].ToString();
        }

        private string status;

        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int iD; 
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
