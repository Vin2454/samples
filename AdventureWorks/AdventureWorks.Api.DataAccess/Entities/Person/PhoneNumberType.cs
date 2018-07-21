using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("PhoneNumberType", Schema="Person")]
        public partial class PhoneNumberType : AbstractEntity
        {
                public PhoneNumberType()
                {
                }

                public virtual void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        int phoneNumberTypeID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.PhoneNumberTypeID = phoneNumberTypeID;
                }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Name")]
                public string Name { get; private set; }

                [Key]
                [Column("PhoneNumberTypeID")]
                public int PhoneNumberTypeID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0c29036170dbe2efc387e9b31b59f6bb</Hash>
</Codenesium>*/