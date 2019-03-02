using System.Collections.Generic;
using CouponAPI.Models;
using Newtonsoft.Json;

namespace CouponAPI.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context){
            _context = context;
        }

        public void Seeddata(){
            var couponsdata = System.IO.File.ReadAllText("Data/Seed.json");
            var coupons = JsonConvert.DeserializeObject<List<Couponcode>>(couponsdata);
            foreach(var coupon in coupons){
                _context.CouponCodes.Add(coupon);
            }
            _context.SaveChanges();
        }
    }
}