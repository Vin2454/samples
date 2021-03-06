using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOProductSubcategory : AbstractBusinessObject
	{
		public AbstractBOProductSubcategory()
			: base()
		{
		}

		public virtual void SetProperties(int productSubcategoryID,
		                                  DateTime modifiedDate,
		                                  string name,
		                                  int productCategoryID,
		                                  Guid rowguid)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ProductCategoryID = productCategoryID;
			this.ProductSubcategoryID = productSubcategoryID;
			this.Rowguid = rowguid;
		}

		public DateTime ModifiedDate { get; private set; }

		public string Name { get; private set; }

		public int ProductCategoryID { get; private set; }

		public int ProductSubcategoryID { get; private set; }

		public Guid Rowguid { get; private set; }
	}
}

/*<Codenesium>
    <Hash>47f8846264c3d549090c56d653940ea3</Hash>
</Codenesium>*/