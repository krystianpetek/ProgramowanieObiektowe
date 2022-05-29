using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqXMLZadanie1
{
    public class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public List<Orders> Orders { get; set; }

        public override string ToString()
        {
            return $"{CustomerID} {CompanyName} {City} {Country}";
        }
    }
}
