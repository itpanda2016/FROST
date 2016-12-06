using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationAuction.Models {
    public class Item {
        public int ItemID { private set; get; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AuctionEndDate { set; get; }
        public IList<Bid> Bids { set; get; }
        public Item() {
            Bids = new List<Bid>();
        }
        public void AddBid(Member memberParam,decimal amountParam) {
            //除非没有报价，或是报价高于已有报价中的最高值才会真正报价
            if (Bids.Count == 0 || amountParam > Bids.Max(e => e.BidAmount)) {
                Bids.Add(new Bid() {
                    Member = memberParam,
                    BidAmount = amountParam,
                    DatePlaced = DateTime.Now
                });
            }
            else {
                throw new InvalidOperationException("报价太低了。");
            }
        }
    }
}