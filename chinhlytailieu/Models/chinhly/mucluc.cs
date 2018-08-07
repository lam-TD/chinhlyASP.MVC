using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.chinhly
{
    public class mucluc
    {
        private int id;
        private int phongid;
        private string mamucluc;
        private string tenmucluc;
        private string mota;
        private string ghichu;

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

        public string Mamucluc
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

        public string Tenmucluc
        {
            get
            {
                return tenmucluc;
            }

            set
            {
                tenmucluc = value;
            }
        }

        public string Mota
        {
            get
            {
                return mota;
            }

            set
            {
                mota = value;
            }
        }

        public string Ghichu
        {
            get
            {
                return ghichu;
            }

            set
            {
                ghichu = value;
            }
        }
    }
}