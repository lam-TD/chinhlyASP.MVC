using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.users
{
    public class nguoidung
    {
        private string id;
        private string username;
        private string password;
        private string holot;
        private string ten;
        private string ngaytao;
        private bool khoa;
        private string chucvu;
        private string bophan;
        private string uyquyen;
        private string ngayuyquyen;
        private string ketthucuyquyen;
        private bool hanche;
        private string fileanh;
        private string email;

        public string Id
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

        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Holot
        {
            get
            {
                return holot;
            }

            set
            {
                holot = value;
            }
        }

        public string Ten
        {
            get
            {
                return ten;
            }

            set
            {
                ten = value;
            }
        }

        public string Ngaytao
        {
            get
            {
                return ngaytao;
            }

            set
            {
                ngaytao = value;
            }
        }

        public bool Khoa
        {
            get
            {
                return khoa;
            }

            set
            {
                khoa = value;
            }
        }

        public string Chucvu
        {
            get
            {
                return chucvu;
            }

            set
            {
                chucvu = value;
            }
        }

        public string Bophan
        {
            get
            {
                return bophan;
            }

            set
            {
                bophan = value;
            }
        }

        public string Uyquyen
        {
            get
            {
                return uyquyen;
            }

            set
            {
                uyquyen = value;
            }
        }

        public string Ngayuyquyen
        {
            get
            {
                return ngayuyquyen;
            }

            set
            {
                ngayuyquyen = value;
            }
        }

        public string Ketthucuyquyen
        {
            get
            {
                return ketthucuyquyen;
            }

            set
            {
                ketthucuyquyen = value;
            }
        }

        public bool Hanche
        {
            get
            {
                return hanche;
            }

            set
            {
                hanche = value;
            }
        }

        public string Fileanh
        {
            get
            {
                return fileanh;
            }

            set
            {
                fileanh = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }
    }
}