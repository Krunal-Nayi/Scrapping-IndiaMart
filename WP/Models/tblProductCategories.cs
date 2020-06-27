using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Models
{
    public class tblProductCategories
    {
        [Key]
        public int inProductCategoryID { get; set; }
        public string stProductCategoryName { get; set; }
        public int? inCompanyID { get; set; }
        public DateTime? dtCreatedOn { get; set; }
    }
}
