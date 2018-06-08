using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("WorkOrder", Schema="Production")]
        public partial class WorkOrder: AbstractEntity
        {
                public WorkOrder()
                {
                }

                public void SetProperties(
                        DateTime dueDate,
                        Nullable<DateTime> endDate,
                        DateTime modifiedDate,
                        int orderQty,
                        int productID,
                        short scrappedQty,
                        Nullable<short> scrapReasonID,
                        DateTime startDate,
                        int stockedQty,
                        int workOrderID)
                {
                        this.DueDate = dueDate;
                        this.EndDate = endDate;
                        this.ModifiedDate = modifiedDate;
                        this.OrderQty = orderQty;
                        this.ProductID = productID;
                        this.ScrappedQty = scrappedQty;
                        this.ScrapReasonID = scrapReasonID;
                        this.StartDate = startDate;
                        this.StockedQty = stockedQty;
                        this.WorkOrderID = workOrderID;
                }

                [Column("DueDate", TypeName="datetime")]
                public DateTime DueDate { get; private set; }

                [Column("EndDate", TypeName="datetime")]
                public Nullable<DateTime> EndDate { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("OrderQty", TypeName="int")]
                public int OrderQty { get; private set; }

                [Column("ProductID", TypeName="int")]
                public int ProductID { get; private set; }

                [Column("ScrappedQty", TypeName="smallint")]
                public short ScrappedQty { get; private set; }

                [Column("ScrapReasonID", TypeName="smallint")]
                public Nullable<short> ScrapReasonID { get; private set; }

                [Column("StartDate", TypeName="datetime")]
                public DateTime StartDate { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("StockedQty", TypeName="int")]
                public int StockedQty { get; private set; }

                [Key]
                [Column("WorkOrderID", TypeName="int")]
                public int WorkOrderID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c3723da1281ab7325d1bf1e0020b8f5f</Hash>
</Codenesium>*/