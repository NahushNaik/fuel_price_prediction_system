using ProjectDataAccess;
using System.Data.Entity.ModelConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinTech.Authentication.Data.Mappings
{ 
    public class FuelQuoteFormMap : EntityTypeConfiguration<FuelQuoteForm>
    {
        public FuelQuoteFormMap()
        {
            ToTable("FuelQuoteForm", "UserManagementMaster");
            HasKey(x => x.OrderId);

            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.GallonsRequested).HasColumnName("GallonRequested");
            this.Property(t => t.DeliveryDate).HasColumnName("DeliveryDate");
            this.Property(t => t.SuggestedPrice).HasColumnName("SuggesetedPrice");
            this.Property(t => t.TotalAmountDue).HasColumnName("TotalAmountDue");
        }
    }
}