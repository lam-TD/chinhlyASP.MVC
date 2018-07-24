using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.chinhly
{
    public class lapkehoachchinhly
    {
        private int id;
        private string nam;
        private string mucdich;
        private int phongid;
        private string tenphong;
        private string giaidoan;
        private string ghichu;
        private int trangthai;
        private int thamdinh;

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

        public string Nam
        {
            get
            {
                return nam;
            }

            set
            {
                nam = value;
            }
        }

        public string Mucdich
        {
            get
            {
                return mucdich;
            }

            set
            {
                mucdich = value;
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

        public string Giaidoan
        {
            get
            {
                return giaidoan;
            }

            set
            {
                giaidoan = value;
            }
        }

        public string Ghichu
        {
            get
            {
                return ghichu;
            }

            set
            {
                ghichu = value;
            }
        }

        public int Trangthai
        {
            get
            {
                return trangthai;
            }

            set
            {
                trangthai = value;
            }
        }

        public int Thamdinh
        {
            get
            {
                return thamdinh;
            }

            set
            {
                thamdinh = value;
            }
        }
    }
}