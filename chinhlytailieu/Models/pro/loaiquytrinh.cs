using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.pro
{
    public class loaiquytrinh
    {
        private string maloai;
        private string tenloai;
        private bool thuphi;
        private int songay;

        public string Maloai
        {
            get
            {
                return maloai;
            }

            set
            {
                maloai = value;
            }
        }

        public string Tenloai
        {
            get
            {
                return tenloai;
            }

            set
            {
                tenloai = value;
            }
        }

        public bool Thuphi
        {
            get
            {
                return thuphi;
            }

            set
            {
                thuphi = value;
            }
        }

        public int Songay
        {
            get
            {
                return songay;
            }

            set
            {
                songay = value;
            }
        }
    }
}