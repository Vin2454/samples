using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductModel", Schema="Production")]
        public partial class ProductModel : AbstractEntity
        {
                public ProductModel()
                {
                }

                public virtual void SetProperties(
                        string catalogDescription,
                        string instruction,
                        DateTime modifiedDate,
                        string name,
                        int productModelID,
                        Guid rowguid)
                {
                        this.CatalogDescription = catalogDescription;
                        this.Instruction = instruction;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ProductModelID = productModelID;
                        this.Rowguid = rowguid;
                }

                [Column("CatalogDescription")]
                public string CatalogDescription { get; private set; }

                [Column("Instructions")]
                public string Instruction { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Key]
                [Column("ProductModelID")]
                public int ProductModelID { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8afb9165f0dd2621504c18235713910d</Hash>
</Codenesium>*/