using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.users
{
    public class coquan
    {
        private string macoquan;
        private string tencoquan;
        private string cqquanly;

        public string Macoquan
        {
            get
            {
                return macoquan;
            }

            set
            {
                macoquan = value;
            }
        }

        public string Tencoquan
        {
            get
            {
                return tencoquan;
            }

            set
            {
                tencoquan = value;
            }
        }

        public string Cqquanly
        {
            get
            {
                return cqquanly;
            }

            set
            {
                cqquanly = value;
            }
        }
    }
}