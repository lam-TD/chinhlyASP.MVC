using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.users
{
    public class nhom_users
    {
        private int id;
        private string username;
        private string manhom;

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
    }
}