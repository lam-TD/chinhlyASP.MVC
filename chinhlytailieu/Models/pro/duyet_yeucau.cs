using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.pro
{
    public class duyet_yeucau
    {
        private int id;
        private int quytrinhid;
        private int yeucauid;
        private string userduyet;
        private string ngayduyet;
        private int duyet;
        private int mastt;
        private string ykien;
        private int idnext;

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

        public int Quytrinhid
        {
            get
            {
                return quytrinhid;
            }

            set
            {
                quytrinhid = value;
            }
        }

        public int Yeucauid
        {
            get
            {
                return yeucauid;
            }

            set
            {
                yeucauid = value;
            }
        }

        public string Userduyet
        {
            get
            {
                return userduyet;
            }

            set
            {
                userduyet = value;
            }
        }

        public string Ngayduyet
        {
            get
            {
                return ngayduyet;
            }

            set
            {
                ngayduyet = value;
            }
        }

        public int Duyet
        {
            get
            {
                return duyet;
            }

            set
            {
                duyet = value;
            }
        }

        public int Mastt
        {
            get
            {
                return mastt;
            }

            set
            {
                mastt = value;
            }
        }

        public string Ykien
        {
            get
            {
                return ykien;
            }

            set
            {
                ykien = value;
            }
        }

        public int Idnext
        {
            get
            {
                return idnext;
            }

            set
            {
                idnext = value;
            }
        }
    }
}