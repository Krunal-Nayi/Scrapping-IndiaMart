using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP
{
    public class CompanyViewModel
    {
        public int inCompanyID { get; set; }
        public string stCompanyName { get; set; }
        public string stCompanyHostURL { get; set; }
    }

    public class CompanyContactViewModel
    {
        public int inCompanyContactID { get; set; }
        public int inCompanyID { get; set; }
        public string stContactName { get; set; }
        public string stAddress { get; set; }
        public string stLatitude { get; set; }
        public string stLongitude { get; set; }
        public string stCallUsNumber { get; set; }
        public string stMobileNos { get; set; }
        public string stTelephoneNos { get; set; }
        public string stFaxNos { get; set; }
        public bool flgIsBranch { get; set; }
    }
}
