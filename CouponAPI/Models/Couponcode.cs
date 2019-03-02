using System.ComponentModel.DataAnnotations;

namespace CouponAPI.Models
{
    public class Couponcode
    {
        [Key]
        public int CoupounId {get; set;}
        public string Code {get; set;}
        public long? Totalamount {get; set;}
        public int? Noofcustomer {get; set;}
        public int? Paynoofcustomer {get; set;}
        public int? Discount {get; set;}
    }
}