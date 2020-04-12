using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectDataAccess
{
    public class FuelQuoteForm
    {
        public int OrderId { get; set; }

        public short UserId { get; set; }

        public int GallonsRequested { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public int SuggestedPrice { get; set; }

        public int TotalAmountDue { get; set; }

    }
}