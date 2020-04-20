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

        public double? GallonsRequested { get; set; }

        public string DeliveryDate { get; set; }

        public string DeliveryAddress { get; set; }

        public double SuggestedPrice { get; set; }

        public double TotalAmountDue { get; set; }

    }
}