using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.users
{
    public class chucvu
    {
        private string machucvu;
        private string tenchucvu;

        public string Machucvu
        {
            get
            {
                return machucvu;
            }

            set
            {
                machucvu = value;
            }
        }

        public string Tenchucvu
        {
            get
            {
                return tenchucvu;
            }

            set
            {
                tenchucvu = value;
            }
        }
    }
}