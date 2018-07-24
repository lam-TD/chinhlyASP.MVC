using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace chinhlytailieu.Controllers.hethong
{
    public class qlnguoidung
    {
        public string load()
        {
            return dataAsset.data.outputdata("ht_qlnguoidung_qlnguoidung_load");
        }
    }
}