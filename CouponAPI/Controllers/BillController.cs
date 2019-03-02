using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CouponAPI.Data;
using CouponAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CouponAPI.Controllers
{
    [Route("restaurant/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly DataContext _context;
        public BillController(DataContext context){
            _context = context;
        }

        [HttpGet("{noofperson}/{price}/{code}")]
        public async Task<IActionResult> Get(int noofperson, int price, string code)
        {
            //var couponrules = await _context.CouponCodes.SingleOrDefaultAsync(x => x.Code == code);
            var couponrules = await _context.CouponCodes.ToListAsync();
            var maxdisval=0.0; var Discounttemp=0.0;
            int totalprice = price * noofperson;
            foreach(var couponrule in couponrules){
                if(couponrule.Code == code && !couponrule.Totalamount.HasValue && !couponrule.Noofcustomer.HasValue) {
                    Discounttemp = 0.01*(float)(totalprice*couponrule.Discount);
                    if(maxdisval < Discounttemp) maxdisval = Discounttemp;
                    Console.WriteLine(maxdisval);
                }
                else if((couponrule.Totalamount.HasValue && totalprice >= couponrule.Totalamount) || (noofperson >= couponrule.Noofcustomer &&  couponrule.Discount.HasValue)){
                    Discounttemp = 0.01*(float)(totalprice*couponrule.Discount);
                    if(maxdisval < Discounttemp) maxdisval = Discounttemp;
                    Console.WriteLine(maxdisval);
                }

                else if(couponrule.Paynoofcustomer.HasValue && noofperson >= couponrule.Noofcustomer){
                        Discounttemp = (float)(price*(couponrule.Noofcustomer-couponrule.Paynoofcustomer));
                        if(maxdisval < Discounttemp) maxdisval = Discounttemp;
                        Console.WriteLine(maxdisval);
                }
  
                
            }
            
            var DiscountVal = new Discountvalue();
            DiscountVal.Discountprice = (int)maxdisval;
            DiscountVal.Totalprice = totalprice;
            DiscountVal.Price = totalprice-(int)maxdisval;
            return Ok(DiscountVal);
        }

        // GET api/values/5
      /*  [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        } */

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
