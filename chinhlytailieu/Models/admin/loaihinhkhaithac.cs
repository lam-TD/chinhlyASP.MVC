using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.admin
{
    public class loaihinhkhaithac
    {
        private int id;
        private string loaiqt;
        private string tenloaiqt;
        private bool giaotl;
        private bool nhantra;
        private bool xemtt;
        private bool goiemail;

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

        public string Loaiqt
        {
            get
            {
                return loaiqt;
            }

            set
            {
                loaiqt = value;
            }
        }

        public string Tenloaiqt
        {
            get
            {
                return tenloaiqt;
            }

            set
            {
                tenloaiqt = value;
            }
        }

        public bool Giaotl
        {
            get
            {
                return giaotl;
            }

            set
            {
                giaotl = value;
            }
        }

        public bool Nhantra
        {
            get
            {
                return nhantra;
            }

            set
            {
                nhantra = value;
            }
        }

        public bool Xemtt
        {
            get
            {
                return xemtt;
            }

            set
            {
                xemtt = value;
            }
        }

        public bool Goiemail
        {
            get
            {
                return goiemail;
            }

            set
            {
                goiemail = value;
            }
        }
    }
}