using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WP.Models
{
    public class tblCompanyTestimonials
    {
        public int inTestimonialID { get; set; }
        public int inCompanyID { get; set; }
        public string stTestimonialName { get; set; }
        public string stTestimonialDescription { get; set; }
        public string stTestimonialImagePath { get; set; }
        public DateTime? dtCreatedOn { get; set; }
    }
}
