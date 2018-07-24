using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.admin
{
    public class vitriluutru
    {
        private int id;
        private string tenluutru;
        private string duongdan;

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

        public string Tenluutru
        {
            get
            {
                return tenluutru;
            }

            set
            {
                tenluutru = value;
            }
        }

        public string Duongdan
        {
            get
            {
                return duongdan;
            }

            set
            {
                duongdan = value;
            }
        }
    }
}