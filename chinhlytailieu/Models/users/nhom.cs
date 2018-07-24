using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.users
{
    public class nhom
    {
        private string manhom;
        private string tennhom;

        public string Manhom
        {
            get
            {
                return manhom;
            }

            set
            {
                manhom = value;
            }
        }

        public string Tennhom
        {
            get
            {
                return tennhom;
            }

            set
            {
                tennhom = value;
            }
        }
    }
}