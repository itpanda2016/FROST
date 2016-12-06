using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationAuction.Models {
    public class Bid {
        public Member Member { set; get; }
        public DateTime DatePlaced { set; get; }
        public decimal BidAmount { set; get; }
    }
}