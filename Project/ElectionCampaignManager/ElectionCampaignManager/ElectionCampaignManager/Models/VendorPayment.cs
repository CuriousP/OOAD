using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectionCampaignManager.Models
{
    public class VendorPayment
    {
        public int ID { get; set; }
        public string Vendor_Name { get; set; }
        public System.DateTime Payment_Date { get; set; }
        public int Amount { get; set; }
    }
}