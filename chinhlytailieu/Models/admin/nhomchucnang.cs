using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.admin
{
    public class nhomchucnang
    {
        private int id;
        private int modulaid;
        private string tennhom;
        private string icon;
        private int thutu;

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

        public int Modulaid
        {
            get
            {
                return modulaid;
            }

            set
            {
                modulaid = value;
            }
        }

        public string Tennhom
        {
            get
            {
                return tennhom;
            }

            set
            {
                tennhom = value;
            }
        }

        public string Icon
        {
            get
            {
                return icon;
            }

            set
            {
                icon = value;
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
    }
}