using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetStoreNS.Api.DataAccess
{
        [Table("Pet", Schema="dbo")]
        public partial class Pet : AbstractEntity
        {
                public Pet()
                {
                }

                public virtual void SetProperties(
                        DateTime acquiredDate,
                        int breedId,
                        string description,
                        int id,
                        int penId,
                        decimal price,
                        int speciesId)
                {
                        this.AcquiredDate = acquiredDate;
                        this.BreedId = breedId;
                        this.Description = description;
                        this.Id = id;
                        this.PenId = penId;
                        this.Price = price;
                        this.SpeciesId = speciesId;
                }

                [Column("acquiredDate")]
                public DateTime AcquiredDate { get; private set; }

                [Column("breedId")]
                public int BreedId { get; private set; }

                [Column("description")]
                public string Description { get; private set; }

                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                [Column("id")]
                public int Id { get; private set; }

                [Column("penId")]
                public int PenId { get; private set; }

                [Column("price")]
                public decimal Price { get; private set; }

                [Column("speciesId")]
                public int SpeciesId { get; private set; }

                [ForeignKey("BreedId")]
                public virtual Breed Breed { get; set; }

                [ForeignKey("PenId")]
                public virtual Pen Pen { get; set; }

                [ForeignKey("SpeciesId")]
                public virtual Species Species { get; set; }
        }
}

/*<Codenesium>
    <Hash>266d5d115b479019da5f0ab7ab356a5e</Hash>
</Codenesium>*/