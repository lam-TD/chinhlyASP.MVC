using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.chinhly
{
    public class hop
    {
        private int id;
        private string mahop;
        private int muclucid;
        private int nganid;
        private int slmax;
        private int slhoso;

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

        public string Mahop
        {
            get
            {
                return mahop;
            }

            set
            {
                mahop = value;
            }
        }

        public int Muclucid
        {
            get
            {
                return muclucid;
            }

            set
            {
                muclucid = value;
            }
        }

        public int Nganid
        {
            get
            {
                return nganid;
            }

            set
            {
                nganid = value;
            }
        }

        public int Slmax
        {
            get
            {
                return slmax;
            }

            set
            {
                slmax = value;
            }
        }

        public int Slhoso
        {
            get
            {
                return slhoso;
            }

            set
            {
                slhoso = value;
            }
        }
    }
}