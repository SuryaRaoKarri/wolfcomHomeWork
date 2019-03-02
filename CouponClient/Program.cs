using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CouponClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            Runclient();
        }

        static void Runclient(){
            using(var client = new HttpClient()){
                client.BaseAddress = new Uri("http://localhost:5000/restaurant/bill/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
            Console.WriteLine("Number of Customer");
            var Numcus = Console.ReadLine();
            Console.WriteLine("Bill per Person");
            var billPerPerson = Console.ReadLine();
            Console.WriteLine("Coupon Code");
            var Couponcode = Console.ReadLine();
                GetDetails(client, Numcus, billPerPerson, Couponcode ).Wait();
            }
        }

        static async Task GetDetails(HttpClient client, string Numcus, string billPerPerson, string Couponcode){
            try{
                HttpResponseMessage response = await client.GetAsync(Numcus+"/"+billPerPerson+"/"+Couponcode);
                response.EnsureSuccessStatusCode();

                Billdetails emp = await response.Content.ReadAsAsync<Billdetails>();
                Console.WriteLine("Price: {0} \nDiscount: {1} \nTotal Price: {2}", emp.Totalprice, emp.Discountprice, emp.Price);
                Console.WriteLine("Press N to Exit OR Y to add other bill:");
                var userDecision = Console.ReadLine();
                if(userDecision.ToLower() == "y"){
                    Runclient();
                }
            }
            catch(HttpRequestException e){
                Console.WriteLine("{0}", e.Message);
            }

        }
    }
}
