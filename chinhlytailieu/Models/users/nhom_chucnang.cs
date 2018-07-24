using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.users
{
    public class nhom_chucnang
    {
        private int id;
        private string manhom;
        private int chucnangid;
        private bool allaction;
        private bool xem;
        private bool sua;
        private bool them;
        private bool xoa;

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

        public string Manhom
        {
            get
            {
                return manhom;
            }

            set
            {
                manhom = value;
            }
        }

        public int Chucnangid
        {
            get
            {
                return chucnangid;
            }

            set
            {
                chucnangid = value;
            }
        }

        public bool Allaction
        {
            get
            {
                return allaction;
            }

            set
            {
                allaction = value;
            }
        }

        public bool Xem
        {
            get
            {
                return xem;
            }

            set
            {
                xem = value;
            }
        }

        public bool Sua
        {
            get
            {
                return sua;
            }

            set
            {
                sua = value;
            }
        }

        public bool Them
        {
            get
            {
                return them;
            }

            set
            {
                them = value;
            }
        }

        public bool Xoa
        {
            get
            {
                return xoa;
            }

            set
            {
                xoa = value;
            }
        }
    }
}