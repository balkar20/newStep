using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuctionDIandLoc.Models
{
    public class MembersRepository:IMembersRepository
    {
        public void AddMember(Member member)
        {
            /* Реализуй меня */
        }
        public Member FetchByLoginName(string loginName)
        {
            /* Реализуй меня */
            return null;
        }

        public void SubmitChanges()
        {
            /* Реализуй меня */
        }
    }
    public class ItemsRepository
    {
        public void AddItem(Item item)
        {
            /* Реализуй меня */
        }
        public Item FetchByID(int itemID)
        {
            /* Реализуй меня */
            return null;
        }
        public IList<Item> ListItems(int pageSize, int pageIndex)
        {
            /* Реализуй меня */
            return null;
        }
        public void SubmitChanges()
        {
            /* Реализуй меня */
        }
    }
}