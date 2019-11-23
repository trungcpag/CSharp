using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCaFe.DTO
{
    public class Category
    {

        public Category(int iD, string name)
        {
            this.iD = iD;
            this.name = name;
        }

        public Category(DataRow row)
        {
            this.iD = (int)row["id"];
            this.name = row["Name"].ToString(); 
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
    }
}
