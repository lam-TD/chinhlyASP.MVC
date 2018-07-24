using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.admin
{
    public class loaidanhmuc
    {
        private string loaidm;
        private string tendm;
        private int dmhethong;

        public string Loaidm
        {
            get
            {
                return loaidm;
            }

            set
            {
                loaidm = value;
            }
        }

        public string Tendm
        {
            get
            {
                return tendm;
            }

            set
            {
                tendm = value;
            }
        }

        public int Dmhethong
        {
            get
            {
                return dmhethong;
            }

            set
            {
                dmhethong = value;
            }
        }
    }
}