using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.users
{
    public class truycaptailieu
    {
        private int id;
        private string manhom;
        private int phongid;
        private int mamucluc;
        private bool xem;
        private bool sua;
        private bool them;

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

        public int Phongid
        {
            get
            {
                return phongid;
            }

            set
            {
                phongid = value;
            }
        }

        public int Mamucluc
        {
            get
            {
                return mamucluc;
            }

            set
            {
                mamucluc = value;
            }
        }

        public bool Xem
        {
            get
            {
                return xem;
            }

            set
            {
                xem = value;
            }
        }

        public bool Sua
        {
            get
            {
                return sua;
            }

            set
            {
                sua = value;
            }
        }

        public bool Them
        {
            get
            {
                return them;
            }

            set
            {
                them = value;
            }
        }
    }
}