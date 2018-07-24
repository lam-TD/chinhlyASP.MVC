using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.admin
{
    public class danhmuc
    {
        private int id;
        private string loaidm;
        private string code;
        private string valuename;

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

        public string Code
        {
            get
            {
                return code;
            }

            set
            {
                code = value;
            }
        }

        public string Valuename
        {
            get
            {
                return valuename;
            }

            set
            {
                valuename = value;
            }
        }
    }
}