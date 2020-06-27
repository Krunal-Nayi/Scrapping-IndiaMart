using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Models
{
    public class tblProductItems
    {
        [Key]
        public int inProductItemID { get; set; }
        public int inCompanyID { get; set; }
        public int inCategoryID { get; set; }
        public string stProductName { get; set; }
        public string stProductDescription { get; set; }
        public string stImagePath { get; set; }
        public string stFeatures { get; set; }
        public string stSpecification { get; set; }
        public string stTechnicalSpecification { get; set; }
        public string stOtherInformationList { get; set; }
        public string stAdditionalInformation { get; set; }
        public string stOtherDescription { get; set; }
        public string stPrice { get; set; }
        public string stAccessories { get; set; }
        public DateTime? dtCreatedOn { get; set; }
    }
}
