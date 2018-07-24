using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.admin
{
    public class chucnang
    {
        private int id;
        private int nhomid;
        private string tenchucnang;
        private string links;
        private int thutu;

        

        public int Nhomid
        {
            get
            {
                return nhomid;
            }

            set
            {
                nhomid = value;
            }
        }

        public string Tenchucnang
        {
            get
            {
                return tenchucnang;
            }

            set
            {
                tenchucnang = value;
            }
        }

        public string Links
        {
            get
            {
                return links;
            }

            set
            {
                links = value;
            }
        }

        public int Thutu
        {
            get
            {
                return thutu;
            }

            set
            {
                thutu = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }
}