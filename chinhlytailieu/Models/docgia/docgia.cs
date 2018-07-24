using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.docgia
{
    public class docgia
    {
        private string id;
        private int idyeucau;
        private string madocgia;
        private string username;
        private string email;
        private string holot;
        private string ten;
        private string ngaysinh;
        private string socmnd;

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

        public int Idyeucau
        {
            get
            {
                return idyeucau;
            }

            set
            {
                idyeucau = value;
            }
        }

        public string Madocgia
        {
            get
            {
                return madocgia;
            }

            set
            {
                madocgia = value;
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

        public string Ngaysinh
        {
            get
            {
                return ngaysinh;
            }

            set
            {
                ngaysinh = value;
            }
        }

        public string Socmnd
        {
            get
            {
                return socmnd;
            }

            set
            {
                socmnd = value;
            }
        }
    }
}