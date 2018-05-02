using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionDIandLoc.Models
{
    public class Member
    {
        public string LoginName { get; set; } // Уникальный ключ
        public int ReputationPoints { get; set; }
    }

    public class Item
    {
        public int ItemID { get; private set; } // Уникальный ключ
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AuctionEndDate { get; set; }
        public IList<Bid> Bids { get; set; }
    }

    public class Bid
    {
        public Member Member { get; set; }
        public DateTime DatePlaced { get; set; }
        public decimal BidAmount { get; set; }
    }
}