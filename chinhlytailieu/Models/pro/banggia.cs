using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.pro
{
    public class banggia
    {
        private int id;
        private int phongid;
        private int loaitl;
        private double dongia;
        private int donvitinh;
        private string ngayapdung;
        private string ngayhuy;

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

        public int Phongid
        {
            get
            {
                return phongid;
            }

            set
            {
                phongid = value;
            }
        }

        public int Loaitl
        {
            get
            {
                return loaitl;
            }

            set
            {
                loaitl = value;
            }
        }

        public double Dongia
        {
            get
            {
                return dongia;
            }

            set
            {
                dongia = value;
            }
        }

        public int Donvitinh
        {
            get
            {
                return donvitinh;
            }

            set
            {
                donvitinh = value;
            }
        }

        public string Ngayapdung
        {
            get
            {
                return ngayapdung;
            }

            set
            {
                ngayapdung = value;
            }
        }

        public string Ngayhuy
        {
            get
            {
                return ngayhuy;
            }

            set
            {
                ngayhuy = value;
            }
        }
    }
}