using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Models.admin
{
    public class module
    {
        private int id;
        private string modulename;
        private string imagepath;
        private string description;
        private int numoder;
        private string links;

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

        public string Modulename
        {
            get
            {
                return modulename;
            }

            set
            {
                modulename = value;
            }
        }

        public string Imagepath
        {
            get
            {
                return imagepath;
            }

            set
            {
                imagepath = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public int Numoder
        {
            get
            {
                return numoder;
            }

            set
            {
                numoder = value;
            }
        }

        public string Links
        {
            get
            {
                return links;
            }

            set
            {
                links = value;
            }
        }
    }
}