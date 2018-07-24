using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.users
{
    public class bophan
    {
        private string maphong;
        private string tenphong;
        private string dvquanly;
        private string madonvi;

        public string Maphong
        {
            get
            {
                return maphong;
            }

            set
            {
                maphong = value;
            }
        }

        public string Tenphong
        {
            get
            {
                return tenphong;
            }

            set
            {
                tenphong = value;
            }
        }

        public string Dvquanly
        {
            get
            {
                return dvquanly;
            }

            set
            {
                dvquanly = value;
            }
        }

        public string Madonvi
        {
            get
            {
                return madonvi;
            }

            set
            {
                madonvi = value;
            }
        }
    }
}